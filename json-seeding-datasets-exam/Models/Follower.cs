using System;

namespace json_seeding_datasets_exam.Models
{
    public class Follower
    {
        public string Id { get; set; }
        public string FollowerId { get; set; }
        public string FollowingId { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public User FollowerUser { get; set; }
        public User FollowingUser { get; set; }
    }
}