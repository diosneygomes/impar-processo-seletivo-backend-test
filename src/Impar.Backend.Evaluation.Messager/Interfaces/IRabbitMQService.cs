using Impar.BackEnd.Evaluation.Core.Entities;

namespace Impar.Backend.Evaluation.Messager.Interfaces
{
    public interface IRabbitMQService
    {
        Task SendMessageToQueueAsync(Message message);

        Task ReceiveMessageToQueueAsync(Action<Message> onMessage);
    }
}
