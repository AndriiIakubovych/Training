using System.Collections.Generic;

namespace Calendar.Server.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<EventViewModel> Events { get; set; }
        public List<UserEventTypeColorViewModel> UserEventTypeColors { get; set; }
    }
}