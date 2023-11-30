using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dal.Configuration
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.MessageContent).HasMaxLength(100).IsRequired();
            
            // Mesaj gönderen kullanıcı ve alıcı kullanıcı ilişkileri
            builder.HasOne(m => m.SenderUser)
                   .WithMany(u => u.SentMessages)
                   .HasForeignKey(m => m.SenderUserId);

            builder.HasOne(m => m.ReceiverUser)
                   .WithMany(u => u.ReceivedMessages)
                   .HasForeignKey(m => m.ReceiverUserId);


        }
    }
}
