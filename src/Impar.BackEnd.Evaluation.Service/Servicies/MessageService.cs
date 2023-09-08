using Impar.BackEnd.Evaluation.Core.Interfaces.Repositories;
using Impar.BackEnd.Evaluation.Core.Interfaces.Services;

namespace Impar.BackEnd.Evaluation.Service.Servicies
{
    internal class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageService;
        private readonly IUserService _userService;

        public MessageService(
            IMessageRepository messageService,
            IUserService userService)
        {
            this._messageService = messageService;
            this._userService = userService;
        }

        public async Task SendMessageToAllAsync(string messageContent)
        {
            var users = await this._userService
                .GetAllAsync()
                .ConfigureAwait(false);
        }
    }
}
