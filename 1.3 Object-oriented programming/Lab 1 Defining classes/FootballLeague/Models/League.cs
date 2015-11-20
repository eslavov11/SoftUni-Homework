using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Models
{
    public static class League
    {
        private static List<Team> teams = new List<Team>();
        private static List<Match> matches = new List<Match>();

        public static IEnumerable<Team> Teams
        {
            get { return teams; }
        }

        public static IEnumerable<Match> Matches
        {
            get { return matches;  }
        }

        public static void AddTeam(Team team)
        {
            if (TeamExists(team))
            {
                throw new InvalidOperationException("This team is already in that league.");
            }
            teams.Add(team);
        }

        private static bool TeamExists(Team team)
        {
            return teams.Any(t => t.Name == team.Name);
        }

        public static void AddMatch(Match match)
        {
            if (MatchExists(match))
            {
                throw new InvalidOperationException("This match is already in that league.");
            }
            matches.Add(match);
        }

        private static bool MatchExists(Match match)
        {
            return matches.Any(m => m.Id == match.Id);
        }
    }
}
