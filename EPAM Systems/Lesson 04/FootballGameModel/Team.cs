using System;
using System.Collections.Generic;

namespace FootballGameModel
{
    class Team
    {
        public string Name { get; set; }
        public List<Player> PlayersList { get; set; }
        public Coach Coach { get; set; }
        public double OverallSkillLevel { get; set; }

        public delegate void GameEvent();

        public event GameEvent Goal;
        public event GameEvent YellowCard;
        public event GameEvent RedCard;

        public Team()
        {
            PlayersList = new List<Player>();
            Goal += ShowGoalMessage;
            YellowCard += ShowYellowCardMessage;
            RedCard += ShowRedCardMessage;
        }

        public void AddPlayer(Player player)
        {
            PlayersList.Add(player);
        }

        public void PrintPlayers()
        {
            foreach (Player p in PlayersList)
                Console.WriteLine(p.Name + ", " + p.Age + " years old");
        }

        public void SortPlayersBySkillLevel()
        {
            PlayersList.Sort(delegate (Player p1, Player p2)
            {
                int comparer = p2.SkillLevel.CompareTo(p1.SkillLevel);
                return comparer;
            });
        }

        public void GenerateGoalEvent()
        {
            Goal();
        }

        public void GenerateYellowCardEvent()
        {
            YellowCard();
        }

        public void GenerateRedCardEvent()
        {
            RedCard();
        }

        private void ShowGoalMessage()
        {
            Console.WriteLine("Goal from \"" + Name + "\"!");
        }

        private void ShowYellowCardMessage()
        {
            Console.WriteLine("Yellow card for player of \"" + Name + "\"!");
        }

        private void ShowRedCardMessage()
        {
            Console.WriteLine("Red card for player of \"" + Name + "\"!");
        }
    }
}