using System;

namespace Calendar.Server.ViewModels
{
    public class EventViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
    }
}