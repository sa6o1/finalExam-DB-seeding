using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using json_seeding_datasets_exam.Models;
using json_seeding_datasets_exam.DTOs;
using System.Text.Json;
using System.IO;
using System.Linq;

namespace json_seeding_datasets_exam.Configurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.SenderId).IsRequired();
            builder.Property(m => m.ReceiverId).IsRequired();
            builder.Property(m => m.Content).IsRequired().HasMaxLength(1000);
            builder.Property(m => m.CreatedAt).IsRequired();
            builder.Property(m => m.Read).IsRequired();

            builder.HasOne(m => m.Sender)
                   .WithMany()
                   .HasForeignKey(m => m.SenderId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(m => m.Receiver)
                   .WithMany()
                   .HasForeignKey(m => m.ReceiverId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Seed data
            var messagesJson = File.ReadAllText("json-seeding-datasets-exam/messages.json");
            var messageDtos = JsonSerializer.Deserialize<List<MessageDto>>(messagesJson);
            var messages = messageDtos.Select(dto => new Message
            {
                Id = dto.Id,
                SenderId = dto.SenderId,
                ReceiverId = dto.ReceiverId,
                Content = dto.Content,
                CreatedAt = dto.CreatedAt,
                Read = dto.Read
            }).ToArray();

            builder.HasData(messages);
        }
    }
}