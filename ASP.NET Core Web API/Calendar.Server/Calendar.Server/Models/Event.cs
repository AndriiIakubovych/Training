using System;

namespace Calendar.Server.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int TypeId { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public EventType EventType { get; set; }
        public User User { get; set; }
    }
}