using System;

namespace json_seeding_datasets_exam.Models
{
    public class Post
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation property
        public User User { get; set; }
    }
}