using System;

namespace json_seeding_datasets_exam.DTOs
{
    public class PostDto
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}