using System;

namespace FairyTail
{
    class Fox : Character
    {
        public Fox()
        {
            Random rand = new Random();
            Name = "fox";
            Weight = rand.Next(15, 25);
        }
    }
}