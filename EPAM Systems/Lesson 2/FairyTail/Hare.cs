using System;

namespace FairyTail
{
    class Hare : Character
    {
        public Hare()
        {
            Random rand = new Random();
            Name = "hare";
            Weight = rand.Next(10, 20);
        }
    }
}