using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace FootballGameModel
{
    class Program
    {
        private enum RefereePreferences { NEUTRAL, FIRST_TEAM, SECOND_TEAM }
        private enum GameEvents { FIRST_TEAM_GOAL, SECOND_TEAM_GOAL, FIRST_TEAM_YELLOW_CARD, SECOND_TEAM_YELLOW_CARD, FIRST_TEAM_RED_CARD, SECOND_TEAM_RED_CARD }

        static void Main(string[] args)
        {
            try
            {
                XDocument document = XDocument.Load("football.xml");
                List<Player> playersList = new List<Player>();
                List<Referee> refereesList = new List<Referee>();
                Team team;
                List<Team> teamsList = new List<Team>();
                Game game = new Game();
                Random rand = new Random();
                int skillLevel, minSkillLevel = 0, maxSkillLevel = 100, results = 2, firstTeamGoalsCount = 0, secondTeamGoalsCount = 0, maxGoalsCount = 5, yellowCardsCount = 4, redCardsCount = 1;
                double luckLevel, minLuckLevel = 0.5, maxLuckLevel = 1.5, overallSkillLevel, difference;
                List<int> eventsList = new List<int>();
                Console.Title = "Football game model";
                foreach (XElement teamElement in document.Element("membership").Element("teams").Elements("team"))
                {
                    playersList.Clear();
                    luckLevel = rand.NextDouble() * (maxLuckLevel - minLuckLevel) + minLuckLevel;
                    overallSkillLevel = 0;
                    foreach (XElement playerElement in teamElement.Element("players").Elements("player"))
                    {
                        skillLevel = rand.Next(minSkillLevel, maxSkillLevel + 1);
                        playersList.Add(new Player() { Name = playerElement.Element("name").Value, Age = Convert.ToInt32(playerElement.Element("age").Value), SkillLevel = skillLevel });
                        overallSkillLevel += skillLevel * luckLevel;
                    }
                    team = new Team() { Name = teamElement.Attribute("name").Value, Coach = new Coach() { Name = teamElement.Element("coach").Value, LuckLevel = luckLevel }, OverallSkillLevel = overallSkillLevel };
                    foreach (Player p in playersList)
                        team.AddPlayer(p);
                    team.SortPlayersBySkillLevel();
                    teamsList.Add(team);
                }
                foreach (XElement refereeElement in document.Element("membership").Element("referees").Elements("referee"))
                    refereesList.Add(new Referee() { Name = refereeElement.Value, Preferences = rand.Next((int)RefereePreferences.NEUTRAL, (int)RefereePreferences.SECOND_TEAM + 1) });
                game.FirstTeam = teamsList[rand.Next(0, teamsList.Count)];
                do
                    game.SecondTeam = teamsList[rand.Next(0, teamsList.Count)];
                while (game.SecondTeam == game.FirstTeam);
                if (game.FirstTeam.PlayersList.Count != game.SecondTeam.PlayersList.Count)
                    throw new GameException();
                game.Referee = refereesList[rand.Next(0, refereesList.Count)];
                Console.WriteLine("List of FC \"" + game.FirstTeam.Name + "\" players:");
                game.FirstTeam.PrintPlayers();
                Console.WriteLine("Coach: " + game.FirstTeam.Coach.Name);
                Console.WriteLine("\nList of FC \"" + game.SecondTeam.Name + "\" players:");
                game.SecondTeam.PrintPlayers();
                Console.WriteLine("Coach: " + game.SecondTeam.Coach.Name);
                Console.WriteLine("\nReferee: " + game.Referee.Name);
                Console.WriteLine("\nGame has started!");
                if (game.Referee.Preferences == (int)RefereePreferences.FIRST_TEAM)
                    game.FirstTeam.OverallSkillLevel += game.FirstTeam.OverallSkillLevel * 10 / 100;
                else
                    if (game.Referee.Preferences == (int)RefereePreferences.SECOND_TEAM)
                        game.SecondTeam.OverallSkillLevel += game.SecondTeam.OverallSkillLevel * 10 / 100;
                if (game.FirstTeam.OverallSkillLevel > game.SecondTeam.OverallSkillLevel)
                {
                    difference = 100 - game.SecondTeam.OverallSkillLevel / game.FirstTeam.OverallSkillLevel * 100;
                    if (difference > 10)
                        results = 0;
                }
                else
                {
                    difference = 100 - game.FirstTeam.OverallSkillLevel / game.SecondTeam.OverallSkillLevel * 100;
                    if (difference > 10)
                        results = 1;
                }
                switch (results)
                {
                    case 0:
                        firstTeamGoalsCount = rand.Next(1, maxGoalsCount + 1);
                        secondTeamGoalsCount = rand.Next(0, firstTeamGoalsCount);
                        break;
                    case 1:
                        secondTeamGoalsCount = rand.Next(1, maxGoalsCount + 1);
                        firstTeamGoalsCount = rand.Next(0, secondTeamGoalsCount);
                        break;
                    case 2:
                        firstTeamGoalsCount = rand.Next(0, maxGoalsCount + 1);
                        secondTeamGoalsCount = firstTeamGoalsCount;
                        break;
                }
                for (int i = 0; i < firstTeamGoalsCount; i++)
                    eventsList.Add((int)GameEvents.FIRST_TEAM_GOAL);
                for (int i = 0; i < secondTeamGoalsCount; i++)
                    eventsList.Add((int)GameEvents.SECOND_TEAM_GOAL);
                for (int i = 0; i < rand.Next(0, yellowCardsCount + 1); i++)
                    eventsList.Add((int)GameEvents.FIRST_TEAM_YELLOW_CARD);
                for (int i = 0; i < rand.Next(0, yellowCardsCount + 1); i++)
                    eventsList.Add((int)GameEvents.SECOND_TEAM_YELLOW_CARD);
                for (int i = 0; i < rand.Next(0, redCardsCount + 1); i++)
                    eventsList.Add((int)GameEvents.FIRST_TEAM_RED_CARD);
                for (int i = 0; i < rand.Next(0, redCardsCount + 1); i++)
                    eventsList.Add((int)GameEvents.SECOND_TEAM_RED_CARD);
                for (int i = eventsList.Count - 1, j = 0, k = 0; i >= 1; i--)
                {
                    j = rand.Next(i + 1);
                    k = eventsList[j];
                    eventsList[j] = eventsList[i];
                    eventsList[i] = k;
                }
                for (int i = 0; i < eventsList.Count; i++)
                    switch (eventsList[i])
                    {
                        case (int)GameEvents.FIRST_TEAM_GOAL:
                            game.FirstTeam.GenerateGoalEvent();
                            break;
                        case (int)GameEvents.SECOND_TEAM_GOAL:
                            game.SecondTeam.GenerateGoalEvent();
                            break;
                        case (int)GameEvents.FIRST_TEAM_YELLOW_CARD:
                            game.FirstTeam.GenerateYellowCardEvent();
                            break;
                        case (int)GameEvents.SECOND_TEAM_YELLOW_CARD:
                            game.SecondTeam.GenerateYellowCardEvent();
                            break;
                        case (int)GameEvents.FIRST_TEAM_RED_CARD:
                            game.FirstTeam.GenerateRedCardEvent();
                            break;
                        case (int)GameEvents.SECOND_TEAM_RED_CARD:
                            game.SecondTeam.GenerateRedCardEvent();
                            break;
                    }
                Console.WriteLine("Game has finished!\n\nScore: " + firstTeamGoalsCount + " " + secondTeamGoalsCount);
                if (results == 0)
                    Console.WriteLine("FC \"" + game.FirstTeam.Name + "\" wins!");
                else
                {
                    if (results == 1)
                        Console.WriteLine("FC \"" + game.SecondTeam.Name + "\" wins!");
                    else
                        Console.WriteLine("Tie!");
                }
                Console.ReadKey();
            }
            catch (GameException)
            {
                Console.WriteLine("Error: Wrong players count on the football field!");
                Console.ReadKey();
            }
            catch (Exception)
            {
                Console.WriteLine("Error: Can't find the file!");
                Console.ReadKey();
            }
        }
    }
}