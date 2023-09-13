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

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var users =  await this.dbset
                .ToListAsync()
                .ConfigureAwait(false);

            return users;
        }
    }
}
