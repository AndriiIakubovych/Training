using System;

namespace HotelEconomy
{
    public class RoomsHiringOut
    {
        public int RoomsHiringOutId { get; set; }
        public int RoomId { get; set; }
        public int ClientId { get; set; }
        public DateTime BeginningDate { get; set; }
        public int DaysCount { get; set; }
        public Room Room { get; set; }
        public Client Client { get; set; }
    }
}