using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capitalism.Employees
{
    public abstract class Employee
    {
        private decimal salary;

        public decimal Salary
        {
            get { return this.Salary; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Salary cannot be a negative number!", "salary");
                }
                this.salary = value;
            }
        }

    }
}
