namespace FootballLeague.Models
{
    using System;

    public class Score
    {
        private int awayTeamGoals;

        private int homeTeamGoals;

        public Score(int homeTeamGoals, int awayTeamGoals)
        {
            this.HomeTeamGoals = homeTeamGoals;
            this.AwayTeamGoals = awayTeamGoals;
        }

        public int AwayTeamGoals
        {
            get
            {
                return this.awayTeamGoals;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Goals cannot be negative");
                }

                this.awayTeamGoals = value;
            }
        }

        public int HomeTeamGoals
        {
            get
            {
                return this.homeTeamGoals;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Goals cannot be negative");
                }

                this.homeTeamGoals = value;
            }
        }
    }
}