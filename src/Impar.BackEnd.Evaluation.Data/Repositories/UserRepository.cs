using Impar.BackEnd.Evaluation.Core.Entities;
using Impar.BackEnd.Evaluation.Core.Interfaces.Repositories;
using Impar.BackEnd.Evaluation.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Impar.BackEnd.Evaluation.Data.Repositories
{
    internal class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(MessagesDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<User>> GetBatchAsync(
            int skip,
            int take)
        {
            var users = await this.dbset
                .AsNoTracking()
                .Skip(skip)
                .Take(take)
                .ToListAsync()
                .ConfigureAwait(false);

            return users;
        }

        public async Task<int> GetTotalUsersAsync()
        {
            var total = await this.dbset
                .AsNoTracking()
                .CountAsync()
                .ConfigureAwait(false);

            return total;
        }
    }
}
