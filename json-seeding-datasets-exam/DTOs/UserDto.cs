using System;

namespace json_seeding_datasets_exam.DTOs
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public string Bio { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}