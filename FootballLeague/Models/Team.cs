using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballLeague.Models
{
    public class Team
    {
        private string name;
        private string nickName;
        private DateTime dateOfFounding;
        private IList<Player> players;


        public Team(string name, string nickName, DateTime dateOfFounding)
        {
            this.name = name;
            this.nickName = nickName;
            this.DateOfFounding = dateOfFounding;
            this.players = new List<Player>();
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (value.Length < 5)
                {
                    throw new ArgumentOutOfRangeException("Name must be at least 5 letters");
                }
                this.name = value;
            }
        }

        public string NickName
        {
            get { return this.nickName; }
            set
            {
                if (value.Length < 5)
                {
                    throw new ArgumentOutOfRangeException("Nick Name must be at least 5 letters");
                }
                this.nickName = value;
            }
        }

        public DateTime DateOfFounding
        {
            get { return this.dateOfFounding; }
            set
            {
                if (value.Year < 1850)
                {
                    throw new ArgumentOutOfRangeException("Year must be after 1850");
                }
                this.dateOfFounding = value;
            }
        }

        public IEnumerable<Player> Players
        {
            get { return this.players; }
            
        }

        public void AddPlayer(Player player)
        {
            if (CheckIfPlayerExists(player))
            {
                throw new InvalidOperationException("Player already exist");
            }
            this.players.Add(player);
        }

        private bool CheckIfPlayerExists(Player player)
        {
            return this.players.Any(p => p.FirstName == player.FirstName &&
                                         p.LastName == player.LastName);
        }

        public override string ToString()
        {
            return $"{this.Name} ({this.DateOfFounding.Year})";
        }
    }
}
