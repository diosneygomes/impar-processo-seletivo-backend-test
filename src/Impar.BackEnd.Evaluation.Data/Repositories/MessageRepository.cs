using Impar.BackEnd.Evaluation.Core.Entities;
using Impar.BackEnd.Evaluation.Core.Interfaces.Repositories;
using Impar.BackEnd.Evaluation.Data.Context;

namespace Impar.BackEnd.Evaluation.Data.Repositories
{
    internal class MessageRepository : BaseRepository<Message>, IMessageRepository
    {
        public MessageRepository(MessagesDbContext context) : base(context)
        {
        }

        public async Task AddRangeAsync(IEnumerable<Message> entities)
        {
            await this.dbset
                .AddRangeAsync(entities)
                .ConfigureAwait(false);

            await this.myDbContext
                .SaveChangesAsync()
                .ConfigureAwait(false);
        }
    }
}
