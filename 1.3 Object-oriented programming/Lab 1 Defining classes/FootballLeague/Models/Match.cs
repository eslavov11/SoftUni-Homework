using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Models
{
    public class Match
    {
        private Team homeTeam;
        private Team awayTeam;
        private Score score;
        private int id;

        internal Score Score
        {
            get
            {
                return this.score;
            }

            set
            {
                this.score = value;
            }
        }

        internal Team AwayTeam
        {
            get
            {
                return awayTeam;
            }

            set
            {
                awayTeam = value;
            }
        }

        internal Team HomeTeam
        {
            get
            {
                return homeTeam;
            }

            set
            {
                homeTeam = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        private Team GetWinner()
        {
            if (MatchIsDraw())
            {
                return null;
            }

            return this.Score.AwayTeamGoals > this.Score.HomeTeamGoals 
                ? this.AwayTeam
                : this.HomeTeam;
        }


        private bool MatchIsDraw()
        {
            return this.Score.AwayTeamGoals == this.Score.HomeTeamGoals;
        }

        public override string ToString()
        {
            return string.Format("Match ID: {0}\nMatch score: {1}", this.Id, this.Score);
        }
    }
}
