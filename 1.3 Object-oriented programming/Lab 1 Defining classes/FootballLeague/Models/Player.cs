using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Models
{
    public class Player
    {
        private const int MinimalAllowedYear = 1980;
        private string firstName;
        private string lastName;
        private DateTime birthDate;
        private decimal salary;
        private Team team;

        public Player(string fName, string lName, DateTime bd, decimal salary)
        {
            this.FirstName = fName;
            this.LastName = lName;
            this.BirthDate = bd;
            this.Salary = salary;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (value.Length < 3 ||  string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("First name should be no less than 3 characters long!");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (value.Length < 3 || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Last name should be no less than 3 characters long!");
                }
                this.lastName = value;
            }
        }

        public decimal Salary
        {
            get
            {
                return this.salary;
            }

            set
            {
                if (value<0)
                {
                    throw new ArgumentException("Salary should have a positive value!");
                }
                this.salary = value;
            }
        }

        public DateTime BirthDate
        {
            get
            {
                return birthDate;
            }

            set
            {
                if (value.Year < MinimalAllowedYear)
                {
                    throw new ArgumentException("Date of birth cannot be earlier than " + MinimalAllowedYear);
                }

                birthDate = value;
            }
        }

        internal Team Team
        {
            get
            {
                return team;
            }

            set
            {
                team = value;
            }
        }
    }
}
