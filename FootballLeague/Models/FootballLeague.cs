using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballLeague.Models;

namespace FootballLeague
{
    public static class FootballLeague
    {
        private static List<Team> teams = new List<Team>();
        private static List<Match> matches = new List<Match>();

        public static IEnumerable<Team> Teams
        {
            get {  return teams;}
        }

        public static IEnumerable<Match> Matches
        {
            get { return matches; }
        }

        public static void AddTeams(Team team )
        {
            if (TeamExistInLeague(team))
            {
                throw new InvalidOperationException("Team already exist");
            }
            teams.Add(team);
        }

        public static void AddMatches(Match match)
        {
            if (MatchExist(match))
            {
                throw new InvalidOperationException("Match already exist");
            }

            matches.Add(match);
        }

        private static bool TeamExistInLeague(Team team)
        {
            return teams.Any(t => t.Name == team.Name);
        }

        private static bool MatchExist(Match match)
        {
            return matches.Any(m => m.Id == match.Id);
        }
    }
}
