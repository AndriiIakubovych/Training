using System.Collections.Generic;

namespace Calendar.Server.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Event> Events { get; set; }
        public List<UserEventTypeColor> UserEventTypeColors { get; set; }
    }
}