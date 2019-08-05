using System;

namespace MiniChat.Models
{
    public class Message
    {
        public int MessageId;
        public User User { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
    }
}