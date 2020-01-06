using System.Collections.Generic;

namespace Calendar.Server.Models
{
    enum EventsTypes { SHORT, MIDDLE, LONG }

    public class EventType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DefaultColor { get; set; }
        public List<Event> Events { get; set; }
        public List<UserEventTypeColor> UserEventTypeColors { get; set; }
    }
}