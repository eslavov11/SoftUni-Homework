using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Models
{
    public class Team
    {
        private string name;
        private string nickname;
        private DateTime dateFounded;
        private List<Player> players;

        public Team(string name, string nickname, DateTime dateFounded)
        {
            this.Name = name;
            this.Nickname = nickname;
            this.DateFounded = dateFounded;
            this.players = new List<Player>();
        }

        public DateTime DateFounded
        {
            get
            {
                return dateFounded;
            }

            set
            {
                dateFounded = value;
            }
        }

        public string Nickname
        {
            get
            {
                return nickname;
            }

            set
            {
                nickname = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public void AddPlayer(Player player)
        {
            if (PlayerExists(player))
            {
                throw new InvalidOperationException("This player is already in that team");
            }
            this.players.Add(player);
        }

        public IEnumerable<Player> Players
        {
            get { return this.players; }
        }

        private bool PlayerExists(Player player)
        {
            return this.players.Any(p => p.FirstName == player.FirstName && p.LastName == player.LastName);
        }

        public override string ToString()
        {
            return string.Format("Team: {0}\nNickname: {1}\nDate founded: {2}", this.Name, this.Nickname, this.DateFounded);
        }
    }
}
