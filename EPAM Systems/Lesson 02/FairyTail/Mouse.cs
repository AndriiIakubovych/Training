using System;

namespace FairyTail
{
    class Mouse : Character
    {
        public Mouse()
        {
            Random rand = new Random();
            Name = "mouse";
            Weight = rand.Next(1, 10);
        }
    }
}