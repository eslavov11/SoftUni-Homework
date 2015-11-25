using _03.CompanyHierarchy.Interfaces;
using _03.CompanyHierarchy.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CompanyHierarchy
{
    public class Employee : Person, IEmployee
    {
        private Department department;
        private decimal salary;

        public Employee(string firstName, string lastName, uint iD, Department department, decimal salary)
            : base(firstName, lastName, iD)
        {
            this.Department = department;
            this.Salary = salary;
        }

        public Department Department
        {
            get
            {
                return this.department;
            }

            set
            {
                this.department = value;
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
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Salary cannot be a negative number");
                }
                this.salary = value;
            }
        }

        public override string ToString()
        {
            return String.Format(
                "Employee Report (" +
                this.GetType().Name +
                "):" +
                Environment.NewLine + 
                this.FirstName +
                " " +
                this.LastName +
                Environment.NewLine + 
                "ID: " + 
                this.ID + 
                Environment.NewLine +
                "Salary: " + 
                this.Salary + 
                Environment.NewLine + 
                "Department: " + 
                this.Department.ToString() +
                Environment.NewLine);
        }

    }
}
