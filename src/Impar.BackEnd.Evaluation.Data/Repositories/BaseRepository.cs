using Impar.BackEnd.Evaluation.Core.Interfaces.Repositories;
using Impar.BackEnd.Evaluation.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Impar.BackEnd.Evaluation.Data.Repositories
{
    public class BaseRepository<Entity> : IBaseRepository<Entity> where Entity : class
    {
        protected readonly MessagesDbContext myDbContext;
        protected readonly DbSet<Entity> dbset;

        public BaseRepository(MessagesDbContext context)
        {
            this.myDbContext = context;
            this.dbset = context.Set<Entity>();
        }
    }
}
