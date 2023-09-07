using Impar.BackEnd.Evaluation.Core.Entities;
using Impar.BackEnd.Evaluation.Core.Interfaces.Repositories;
using Impar.BackEnd.Evaluation.Data.Context;

namespace Impar.BackEnd.Evaluation.Data.Repositories
{
    internal class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(MessagesDbContext context) : base(context)
        {
        }
    }
}
