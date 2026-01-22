using System;

namespace json_seeding_datasets_exam.DTOs
{
    public class FollowerDto
    {
        public string Id { get; set; }
        public string FollowerId { get; set; }
        public string FollowingId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}