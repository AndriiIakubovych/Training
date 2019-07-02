using System;
using System.Collections.Generic;

namespace FairyTail
{
    class House
    {
        public List<Character> CharactersList { get; set; }
        public int Capacity { get; set; }
        public int Fullness { get; set; }

        public House()
        {
            Random rand = new Random();
            CharactersList = new List<Character>();
            Capacity = rand.Next(80, 100);
            Fullness = 0;
        }

        public void Description()
        {
            Console.WriteLine("There stood a small wooden house (teremok) in the open field.");
        }

        public void Answer()
        {
            if (CharactersList.Count > 0)
            {
                foreach (Character c in CharactersList)
                    c.Answer();
                Console.WriteLine("- Let's live together!\nSo they began living together.");
            }
            else
                Console.WriteLine("Nobody answered. So it went into the house and began to live there.");
        }

        public void Add(Character character)
        {
            CharactersList.Add(character);
            Fullness += character.Weight;
            if (Fullness > Capacity)
                Console.WriteLine("But the house cracked and collapsed! All of the scared animals ran away in different directions!");
        }
    }
}