using System;

namespace json_seeding_datasets_exam.Models
{
    public class Message
    {
        public string Id { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Read { get; set; }

        // Navigation properties
        public User Sender { get; set; }
        public User Receiver { get; set; }
    }
}