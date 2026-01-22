using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using json_seeding_datasets_exam.Models;
using json_seeding_datasets_exam.DTOs;
using System.Text.Json;
using System.IO;
using System.Linq;

namespace json_seeding_datasets_exam.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.UserId).IsRequired();
            builder.Property(p => p.Content).IsRequired().HasMaxLength(1000);
            builder.Property(p => p.Image).HasMaxLength(200);
            builder.Property(p => p.CreatedAt).IsRequired();

            builder.HasOne(p => p.User)
                   .WithMany()
                   .HasForeignKey(p => p.UserId);

            // Seed data
            var postsJson = File.ReadAllText("json-seeding-datasets-exam/posts.json");
            var postDtos = JsonSerializer.Deserialize<List<PostDto>>(postsJson);
            var posts = postDtos.Select(dto => new Post
            {
                Id = dto.Id,
                UserId = dto.UserId,
                Content = dto.Content,
                Image = dto.Image,
                CreatedAt = dto.CreatedAt
            }).ToArray();

            builder.HasData(posts);
        }
    }
}