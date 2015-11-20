using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Models
{
    static class LeagueManager
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            while (line != "End")
            {
                try
                {
                    LeagueManager.HandleInput(line);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch(InvalidCastException e)
                {
                    Console.WriteLine(e.Message);
                }
                line = Console.ReadLine();
            }
        }

        public static void HandleInput(string input)
        {
            var inputArgs = input.Split();
            switch (inputArgs[0])
            {
                case "AddTeam":
                    AddTeam(inputArgs[1], inputArgs[2], DateTime.Parse(inputArgs[3]));
                    break;
                case "AddMatch":
                    AddMatch(int.Parse(inputArgs[1]));
                    break;
                case "AddPlayerToTeam":
                    AddPlayerToTeam(
                        inputArgs[1],
                        inputArgs[2],
                        DateTime.Parse(inputArgs[3]),
                        decimal.Parse(inputArgs[4]),
                        inputArgs[5]);
                    break;
                case "ListTeams":
                    ListTeams();
                    break;
                case "ListMatches":
                    ListMatches();
                    break;

            }
        }

        private static void ListMatches()
        {
            foreach (var item in League.Matches)
            {
                Console.WriteLine(item);
            }
        }

        private static void ListTeams()
        {
            foreach (var item in League.Teams)
            {
                Console.WriteLine(item);
            }
        }

        private static void AddPlayerToTeam(
            string firstName, 
            string lastName, 
            DateTime birthDate,
            decimal salary, 
            string team)
        {
            Player player = new Player(
                 firstName, 
                 lastName, 
                 birthDate,
                 salary);

            try
            {
                // TODO
            }
            catch (Exception)
            {

                throw;
            }


        }

        private static void AddMatch(int id)
        {
            Match match = new Match();
            match.Id = id;

            try
            {
                League.AddMatch(match);
                Console.WriteLine("Team successfully created!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void AddTeam(string v1, string v2, DateTime p)
        {
            Team team = new Team(v1, v2, p);
            try
            {
                League.AddTeam(team);
                Console.WriteLine("Team successfully created!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
