
using System;
using System.Text;

namespace FootballLeague.Models
{
    public class Player
    {
        private string firstName;
        private string lastName;
        private DateTime dateOFBirth;
        private decimal salary;
        private Team team;

        public Player(string firstName, string lastName, DateTime dateOfBirth, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.Salary = salary;
            this.Team = team;
        }

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3)
                {
                    throw new ArgumentOutOfRangeException("Firstname should be at least 3 chars long");
                }
                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3)
                {
                    throw new ArgumentOutOfRangeException("Lastname should be at least 3 chars long");
                }
                this.lastName = value;
            }
        }

        public DateTime DateOfBirth
        {
            get { return this.dateOFBirth; }
            set
            {
                if (value.Year < 1980)
                {
                    throw new ArgumentException("Date of birth...");
                }
                dateOFBirth = value;
            }
        }

        public decimal Salary
        {
            get { return salary; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Salary cannot be negative");
                }
                this.salary = value;
            }
        }

        public Team Team
        {
            get { return team; }
            set { team = value; }
        }

        public override string ToString()
        {
            var playerInfo = new StringBuilder();

            playerInfo.AppendLine(string.Format("Player: {0} {1}", this.FirstName, this.LastName));
            playerInfo.AppendLine(string.Format("Born on: {0}", this.DateOfBirth));
      //      playerInfo.AppendLine(string.Format("Currently plays for: {0} with salary: {1}", this.Team.NickName, string.Format("{0:0.00} $", this.Salary)));

            return playerInfo.ToString();
        }
    }
}
