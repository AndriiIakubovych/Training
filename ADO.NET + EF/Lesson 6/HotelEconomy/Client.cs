using System;
using System.Collections.Generic;

namespace HotelEconomy
{
    public class Client
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string Sex { get; set; }
        public DateTime Birthdate { get; set; }
        public string PassportData { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Nationality { get; set; }
        public virtual ICollection<RoomsHiringOut> RoomsHiringOut { get; set; }
    }
}