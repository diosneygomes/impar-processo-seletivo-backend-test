using Impar.BackEnd.Evaluation.Core.Entities;
using Impar.BackEnd.Evaluation.Core.Interfaces.Repositories;
using Impar.BackEnd.Evaluation.Data.Context;

namespace Impar.BackEnd.Evaluation.Data.Repositories
{
    public class MessageRepository : BaseRepository<Message>, IMessageRepository
    {
        public MessageRepository(MessagesDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Message message)
        {
            await this.dbset
                .AddAsync(message)
                .ConfigureAwait(false);

            await this.myDbContext
                .SaveChangesAsync()
                .ConfigureAwait(false);
        }
    }
}
