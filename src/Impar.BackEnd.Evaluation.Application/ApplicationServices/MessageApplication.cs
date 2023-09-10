using Impar.BackEnd.Evaluation.Application.InputModel;
using Impar.BackEnd.Evaluation.Application.Interfaces;
using Impar.BackEnd.Evaluation.Core.Interfaces.Services;

namespace Impar.BackEnd.Evaluation.Application.ApplicationServices
{
    public class MessageApplication : IMessageApplication
    {
        private readonly IMessageService _messageService;

        public MessageApplication(IMessageService messageService)
        {
                this._messageService = messageService;
        }

        public async Task SendMessageToAllAsync()
        {
            await this._messageService
                .SendMessageToAllAsync()
                .ConfigureAwait(false);
        }
    }
}
