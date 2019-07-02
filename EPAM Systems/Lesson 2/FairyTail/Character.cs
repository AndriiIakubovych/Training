using System;

namespace FairyTail
{
    abstract class Character
    {
        public string Name { get; set; }
        public int Weight { get; set; }

        public void ShowAndAsk()
        {
            Console.WriteLine("A " + Name + " ran by and asked: \"Little house, little house! Who lives in the little house?\"");
        }

        public void Answer()
        {
            Console.WriteLine("- I'm a " + Name + "!");
        }
    }
}