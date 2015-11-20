using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Models
{
    class Score
    {
        private int homeTeamGoals;
        private int awayTeamGoals;
        
        public Score(int homeTeamsGoals, int awayTeamGoals)
        {
            this.HomeTeamGoals = homeTeamGoals;
            this.AwayTeamGoals = awayTeamGoals;
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
                    throw new ArgumentException("Goals cannot be a negative number!");
                }
                this.homeTeamGoals = value;
            }
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
                    throw new ArgumentException("Goals cannot be a negative number!");
                }
                this.awayTeamGoals = value;
            }
        }
    }
}
