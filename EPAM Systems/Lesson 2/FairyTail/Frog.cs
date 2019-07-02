using System;

namespace FairyTail
{
    class Frog : Character
    {
        public Frog()
        {
            Random rand = new Random();
            Name = "frog";
            Weight = rand.Next(5, 15);
        }
    }
}