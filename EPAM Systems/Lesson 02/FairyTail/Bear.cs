using System;

namespace FairyTail
{
    class Bear : Character
    {
        public Bear()
        {
            Random rand = new Random();
            Name = "bear";
            Weight = Weight = rand.Next(25, 35);
        }
    }
}