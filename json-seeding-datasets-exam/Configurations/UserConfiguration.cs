using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using json_seeding_datasets_exam.Models;
using json_seeding_datasets_exam.DTOs;
using System.Text.Json;
using System.IO;

namespace json_seeding_datasets_exam.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Username).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Avatar).HasMaxLength(200);
            builder.Property(u => u.Bio).HasMaxLength(500);
            builder.Property(u => u.CreatedAt).IsRequired();

            // Seed data
            var usersJson = File.ReadAllText("json-seeding-datasets-exam/users.json");
            var userDtos = JsonSerializer.Deserialize<List<UserDto>>(usersJson);
            var users = userDtos.Select(dto => new User
            {
                Id = dto.Id,
                Username = dto.Username,
                Email = dto.Email,
                Avatar = dto.Avatar,
                Bio = dto.Bio,
                CreatedAt = dto.CreatedAt
            }).ToArray();

            builder.HasData(users);
        }
    }
}