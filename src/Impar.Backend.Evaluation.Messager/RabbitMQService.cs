using Impar.Backend.Evaluation.Messager.Exceptions;
using Impar.Backend.Evaluation.Messager.Interfaces;
using Impar.BackEnd.Evaluation.Core.Entities;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace Impar.Backend.Evaluation.Messager
{
    public class RabbitMQService : IRabbitMQService
    {
        public async Task SendMessageToQueueAsync(Message message)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using var connection = factory
                .CreateConnection();

            using var channel = connection
                .CreateModel();

            await Task.Run(() => {

                channel
                    .QueueDeclare(
                        queue: "orderQueue",
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

                string messageSerializer = JsonSerializer
                    .Serialize(message);

                var messageBytes = Encoding.UTF8
                    .GetBytes(messageSerializer);

                channel
                    .BasicPublish(
                        exchange: "",
                        routingKey: "orderQueue",
                        basicProperties: null,
                        body: messageBytes);
            })
            .ConfigureAwait(false);
        }

        public async Task ReceiveMessageToQueueAsync(Action<Message> onMessage)
        {
            var factory = new ConnectionFactory { 
                HostName = "localhost",
                Ssl =
                {
                    ServerName = "localhost",
                }
            };

            var connection = factory
                .CreateConnection();

            var channel = connection
                .CreateModel();

            channel
                .QueueDeclare(
                    queue: "orderQueue",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += async (model, ea) =>
            {
                try
                {
                    var body = ea.Body
                        .ToArray();
                    
                    var message = Encoding.UTF8
                        .GetString(body);

                    var messageDeserialize = JsonSerializer
                        .Deserialize<Message>(message);

                    onMessage(messageDeserialize);

                    await Task.Yield();

                    channel
                        .BasicAck(
                            ea.DeliveryTag,
                            false);
                }
                catch (RabbitMQErrorServerException e)
                {
                    channel
                        .BasicNack(
                            ea.DeliveryTag,
                            false,
                            true);

                    throw new RabbitMQErrorServerException($"Erro ao receber mensagem - {e.Message}");
                }
            };

            channel
                .BasicConsume(
                    queue: "orderQueue",
                    autoAck: false,
                    consumer: consumer);

            await Task.Yield();
        }
    }
}
