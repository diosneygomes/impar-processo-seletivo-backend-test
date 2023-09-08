using Impar.BackEnd.Evaluation.Application.InputModel;

namespace Impar.BackEnd.Evaluation.Application.Interfaces
{
    public interface IMessageApplication
    {
        Task SendMessageToAllAsync(string message);
    }
}
