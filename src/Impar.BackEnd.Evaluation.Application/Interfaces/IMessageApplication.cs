namespace Impar.BackEnd.Evaluation.Application.Interfaces
{
    public interface IMessageApplication
    {
        Task SendMessageToAllAsync();

        Task ReceiveMessageAsync();
    }
}
