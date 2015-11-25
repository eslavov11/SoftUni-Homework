using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.HumanStudentAndWorker
{
    class Worker : Human
    {
        private decimal weekSalary;
        private byte workHoursPerDay;

        public Worker(string firstName, string lastName, decimal salary, byte workHours)
            : base(firstName, lastName)
        {
            this.WorkHoursPerDay = workHours;
            this.WeekSalary = salary;
        }

        public decimal WeekSalary
        {
            get
            {
                return this.weekSalary;
            }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Salary cannot be a negative number");
                }
                this.weekSalary = value;
            }
        }

        public byte WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Hours cannot be a negative number");
                }
                this.workHoursPerDay = value;
            }
        }

        private decimal MoneyPerHour()
        {
            return this.WeekSalary / this.WorkHoursPerDay;
        }
    }
}
