using Impar.BackEnd.Evaluation.Core.Interfaces.Repositories;
using Impar.BackEnd.Evaluation.Core.Interfaces.Services;
using Impar.Backend.Evaluation.Messager.Interfaces;

namespace Impar.BackEnd.Evaluation.Service.Servicies
{
    internal class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageService;
        private readonly IUserService _userService;
        private readonly IRabbitMQService _queue;

        public MessageService(
            IMessageRepository messageService,
            IUserService userService,
            IRabbitMQService queue)
        {
            this._messageService = messageService;
            this._userService = userService;
            this._queue = queue;
        }

        public async Task SendMessageToAllAsync()
        {
            var users = await this._userService
                .GetAllAsync()
                .ConfigureAwait(false);

            foreach (var user in users) 
            { 
                
            }
        }
    }
}
