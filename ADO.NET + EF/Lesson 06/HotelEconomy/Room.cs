using System.Collections.Generic;

namespace HotelEconomy
{
    public class Room
    {
        public int RoomId { get; set; }
        public int RoomNumber { get; set; }
        public int Floor { get; set; }
        public string Category { get; set; }
        public int PlacesCount { get; set; }
        public double Price { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public virtual ICollection<RoomsHiringOut> RoomsHiringOut { get; set; }
    }
}