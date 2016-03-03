
using System.Text;

namespace FootballLeague.Models
{
    public class Match
    {
        private Team homeTeam;
        private Team awayTeam;
        private Score score;
        private int id;
        
        public Match(Team homeTeam, Team awayTeam, Score score, int id)
        {
            this.HomeTeam = homeTeam;
            this.AwayTeam = awayTeam;
            this.Score = score;
            this.Id = id;
        }

        public Team HomeTeam
        {
            get { return this.homeTeam; }
            set { this.homeTeam = value; }
        }

        public Team AwayTeam
        {
            get { return this.awayTeam; }
            set { this.awayTeam = value; }
        }

        public Score Score
        {
            get { return score; }
            set { score = value; }
        }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public Team GetWinner()
        {
            if (this.IsDraw())
            {
                return null;
            }

            return this.Score.AwayTeamGoals > this.Score.HomeTeamGoals
            ? this.HomeTeam
            : AwayTeam;
        }

        private bool IsDraw()
        {
            return this.Score.AwayTeamGoals == this.Score.HomeTeamGoals;
        }
        public override string ToString()
        {
            var matchInfo = new StringBuilder();
            matchInfo.AppendLine(string.Format
                ("{0} - {1} : {2}",
                    this.HomeTeam.Name,
                    this.AwayTeam.Name,
                    this.Score.ToString()
                ));

            return matchInfo.ToString();
        }
    }
}
