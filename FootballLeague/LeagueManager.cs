using System;
using System.Linq;
using System.Text.RegularExpressions;
using FootballLeague.Models;
using Match = FootballLeague.Models.Match;

namespace FootballLeague
{
    public static class LeagueManager
    {
        public static void HandleInput(string input)
        {
            var inputTokens = input.Split();
            switch (inputTokens[0])
            {
                case "AddTeam":
                    AddTeam(inputTokens[1], inputTokens[2], DateTime.Parse(inputTokens[3]));
                    break;
                case "AddMatch":
                    AddMatch(int.Parse(inputTokens[1]), inputTokens[2], inputTokens[3], int.Parse(inputTokens[4]), int.Parse(inputTokens[5]));
                    break;
                case "AddPlayerToTeam":
                    AddPlayerToTeam(inputTokens[1], inputTokens[2], DateTime.Parse(inputTokens[3]), decimal.Parse(inputTokens[4]), inputTokens[5]);
                    break;
                case "ListTeams":
                    ListTeams();
                    break;
                case "ListMatches":
                    ListMatches();
                    break;
            }
        }

        private static void AddTeam(string teamName, string nickName, DateTime timeFounded)
        {
            var currentTeam = new Team(teamName, nickName, timeFounded);
            FootballLeague.AddTeams(currentTeam);

            Console.WriteLine(string.Format("{0} team successfull added to league", currentTeam));
        }

        private static void AddMatch(int matchId, string homeTeamName, string awayTeamName, int homeTeamGoals,
            int awayTeamGoals)
        {
            var homeTeam = FootballLeague.Teams.First(team => team.Name == homeTeamName);
            var awayTeam = FootballLeague.Teams.First(team => team.Name == awayTeamName);
            var curScores = new Score(homeTeamGoals, awayTeamGoals);
            var curMatch = new Match(homeTeam, awayTeam, curScores, matchId);
        }

        private static void AddPlayerToTeam(string playerFirstName, string playerLastName, DateTime playerBirthDate, decimal playerSalary, string playerTeam)
        {

            Team taemToaddTo = FootballLeague.Teams.FirstOrDefault(t => t.Name == playerTeam);
            if (taemToaddTo == null)
                throw new ArgumentException(" thi team does not exists in this league.");

            Player newPlayer = new Player(playerFirstName, playerLastName, playerBirthDate, playerSalary);
            taemToaddTo.AddPlayer(newPlayer);
            Console.WriteLine("Player {0} added successfully to team {1}", newPlayer, playerTeam);
        }

        private static void ListMatches()
        {
            FootballLeague.Matches.ToList().ForEach(Console.WriteLine);
        }

        private static void ListTeams()
        {
            FootballLeague.Teams.ToList().ForEach(Console.WriteLine);
        }

    }
}
