using Impar.BackEnd.Evaluation.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Impar.BackEnd.Evaluation.Data.EntityMappingConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(user => user.Id);

            builder
                .Property(user => user.Name)
                .IsRequired();

            builder
                .Property(user => user.Email)
                .IsRequired();

            builder
                .Property(user => user.Phone)
                .IsRequired();

            builder
                .HasMany(messager => messager.Messages)
                  .WithOne(user => user.User);
        }
    }
}
