using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.Configuration
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.MessageContent).HasMaxLength(100).IsRequired();


            builder.HasOne(p => p.UserFk).WithMany(p => p.Messages).HasForeignKey(p => p.UserId);

        }
    }
}
