namespace Calendar.Server.Models
{
    public class UserEventTypeColor
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TypeId { get; set; }
        public string Color { get; set; }
        public User User { get; set; }
        public EventType EventType { get; set; }
    }
}