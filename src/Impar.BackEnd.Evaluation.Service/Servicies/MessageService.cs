using Impar.BackEnd.Evaluation.Core.Interfaces.Repositories;
using Impar.BackEnd.Evaluation.Core.Interfaces.Services;
using Impar.Backend.Evaluation.Messager.Interfaces;
using Impar.BackEnd.Evaluation.Core.Entities;
using Impar.BackEnd.Evaluation.Service.Exceptions;

namespace Impar.BackEnd.Evaluation.Service.Servicies
{
    internal class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IUserService _userService;
        private readonly IRabbitMQService _rabbitMQService;
        private readonly SemaphoreSlim _semaphore = new(1);

        public MessageService(
            IMessageRepository messageRepository,
            IUserService userService,
            IRabbitMQService rabbitMQService)
        {
            this._messageRepository = messageRepository;
            this._userService = userService;
            this._rabbitMQService = rabbitMQService;
        }

        public async Task SendMessageToAllAsync()
        {
            var users = await this._userService
                .GetAllAsync()
                .ConfigureAwait(false);

            foreach (var user in users)
            {
                var message = new Message(
                    $"User: {user.Name}",
                    $"Esta é uma mensagem enviada para {user.Name} ({user.Email})",
                    user.Id);

                await this._rabbitMQService
                    .SendMessageToQueueAsync(message)
                    .ConfigureAwait(false);
            }
        }

        public async Task ReceiveMessageAsync()
        {
            await this._rabbitMQService
                .ReceiveMessageToQueueAsync(async message =>
            {
                await _semaphore
                    .WaitAsync()
                    .ConfigureAwait(false);

                try
                {
                    await this._messageRepository
                        .AddAsync(message)
                        .ConfigureAwait(false);
                }
                catch (Exception)
                {
                    throw new AddEntityException($"Não foi possível enviar a mensagem");
                }
                finally
                {
                    _semaphore.Release();
                }
            });
        }
    }
}
