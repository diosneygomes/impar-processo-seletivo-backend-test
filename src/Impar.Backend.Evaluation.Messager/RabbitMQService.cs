using Impar.Backend.Evaluation.Messager.Exceptions;
using Impar.Backend.Evaluation.Messager.Interfaces;
using Impar.BackEnd.Evaluation.Core.Entities;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace Impar.Backend.Evaluation.Messager
{
    internal class RabbitMQService : IRabbitMQService
    {

        public void SendMessageToQueue(Message message)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using var connection = factory
                .CreateConnection();

            using var channel = connection
                .CreateModel();

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
        }

        public Message ReceiveMessageToQueue()
        {
            var factory = new ConnectionFactory { HostName = "localhost" };

            using var connection = factory
                .CreateConnection();
            
            using var channel = connection
                .CreateModel();

            channel
                .QueueDeclare(
                    queue: "orderQueue",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

            var consumer = new EventingBasicConsumer(channel);

            var messageDeserialize = new Message();

            consumer.Received += (model, ea) =>
            {
                try
                {
                    var body = ea.Body
                        .ToArray();
                    
                    var message = Encoding.UTF8
                        .GetString(body);

                    messageDeserialize = JsonSerializer
                        .Deserialize<Message>(message);

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

            return messageDeserialize;
        }
    }
}
