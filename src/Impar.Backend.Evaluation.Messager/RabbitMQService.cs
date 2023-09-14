using Impar.Backend.Evaluation.Messager.Configurations;
using Impar.Backend.Evaluation.Messager.Exceptions;
using Impar.Backend.Evaluation.Messager.Interfaces;
using Impar.BackEnd.Evaluation.Core.Entities;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace Impar.Backend.Evaluation.Messager
{
    public class RabbitMQService : IRabbitMQService
    {
        private readonly RabbitMQSetting _rabbitMQSetting;

        public RabbitMQService(IOptions<RabbitMQSetting> rabbitMQSetting)
        {
            this._rabbitMQSetting = rabbitMQSetting.Value;
        }

        public async Task SendMessageToQueueAsync(Message message)
        {
            var factory = new ConnectionFactory() { HostName = this._rabbitMQSetting.HostName };

            using var connection = factory
                .CreateConnection();

            using var channel = connection
                .CreateModel();

            await Task.Run(() => {

                channel
                    .QueueDeclare(
                        queue: this._rabbitMQSetting.Queue,
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
                        routingKey: this._rabbitMQSetting.Queue,
                        basicProperties: null,
                        body: messageBytes);
            })
            .ConfigureAwait(false);
        }

        public async Task ReceiveMessageToQueueAsync(Action<Message> onMessage)
        {
            var factory = new ConnectionFactory { 
                HostName = this._rabbitMQSetting.HostName,
                Ssl =
                {
                    ServerName = this._rabbitMQSetting.ServerName,
                }
            };

            var connection = factory
                .CreateConnection();

            var channel = connection
                .CreateModel();

            channel
                .QueueDeclare(
                    queue: this._rabbitMQSetting.Queue,
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
                    queue: this._rabbitMQSetting.Queue,
                    autoAck: false,
                    consumer: consumer);

            await Task.Yield();
        }
    }
}
