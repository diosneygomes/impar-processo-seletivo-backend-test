using Impar.BackEnd.Evaluation.Core.Entities;

namespace Impar.BackEnd.Evaluation.Core.Interfaces.Services
{
    public interface IMessageService
    {
        Task SendMessageToAllAsync(string messageContent);
    }
}
