using System.Collections.Generic;

namespace MiniChat.Models
{
    public class User
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public List<Message> MessagesList { get; set; }
    }
}