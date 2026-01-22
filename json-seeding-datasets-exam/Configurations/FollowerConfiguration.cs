using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using json_seeding_datasets_exam.Models;
using json_seeding_datasets_exam.DTOs;
using System.Text.Json;
using System.IO;
using System.Linq;

namespace json_seeding_datasets_exam.Configurations
{
    public class FollowerConfiguration : IEntityTypeConfiguration<Follower>
    {
        public void Configure(EntityTypeBuilder<Follower> builder)
        {
            builder.HasKey(f => f.Id);
            builder.Property(f => f.FollowerId).IsRequired();
            builder.Property(f => f.FollowingId).IsRequired();
            builder.Property(f => f.CreatedAt).IsRequired();

            builder.HasOne(f => f.FollowerUser)
                   .WithMany()
                   .HasForeignKey(f => f.FollowerId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(f => f.FollowingUser)
                   .WithMany()
                   .HasForeignKey(f => f.FollowingId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Seed data
            var followersJson = File.ReadAllText("json-seeding-datasets-exam/followers.json");
            var followerDtos = JsonSerializer.Deserialize<List<FollowerDto>>(followersJson);
            var followers = followerDtos.Select(dto => new Follower
            {
                Id = dto.Id,
                FollowerId = dto.FollowerId,
                FollowingId = dto.FollowingId,
                CreatedAt = dto.CreatedAt
            }).ToArray();

            builder.HasData(followers);
        }
    }
}