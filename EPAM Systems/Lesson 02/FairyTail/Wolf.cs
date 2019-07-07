using System;

namespace FairyTail
{
    class Wolf : Character
    {
        public Wolf()
        {
            Random rand = new Random();
            Name = "wolf";
            Weight = rand.Next(20, 30);
        }
    }
}