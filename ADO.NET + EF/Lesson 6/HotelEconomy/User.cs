﻿namespace HotelEconomy
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public bool AdminRights { get; set; }
    }
}