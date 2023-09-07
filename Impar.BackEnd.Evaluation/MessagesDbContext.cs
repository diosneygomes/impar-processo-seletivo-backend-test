using Microsoft.EntityFrameworkCore;

namespace Impar.BackEnd.Evaluation
{
    public class MessagesDbContext : DbContext
    {
        public MessagesDbContext()
        {
        }

        public MessagesDbContext(DbContextOptions options)
            : base(options)
        {

        }
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Message> Messages { get; set; } = null!;
    }
}
