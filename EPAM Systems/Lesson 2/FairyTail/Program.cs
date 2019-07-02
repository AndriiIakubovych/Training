using System;
using System.Collections.Generic;

namespace FairyTail
{
    class Program
    {
        static void Main(string[] args)
        {
            House house = new House();
            List<Character> charactersList = new List<Character>();
            Console.Title = "Teremok (Russian folktale)";
            house.Description();
            charactersList.Add(new Mouse());
            charactersList.Add(new Frog());
            charactersList.Add(new Hare());
            charactersList.Add(new Fox());
            charactersList.Add(new Wolf());
            charactersList.Add(new Bear());
            foreach (Character c in charactersList)
            {
                c.ShowAndAsk();
                house.Answer();
                house.Add(c);
                if (house.Fullness > house.Capacity)
                    break;
            }
            Console.ReadKey();
        }
    }
}