using Impar.BackEnd.Evaluation.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Impar.BackEnd.Evaluation.Data.EntityMappingConfigurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder
                .HasKey(message => message.Id);

            builder
                .Property(message => message.Subject)
                .IsRequired();

            builder
                .Property(message => message.MessageContent)
                .IsRequired();

            builder
                .Property(message => message.SentAt)
                .IsRequired();
        }
    }
}
