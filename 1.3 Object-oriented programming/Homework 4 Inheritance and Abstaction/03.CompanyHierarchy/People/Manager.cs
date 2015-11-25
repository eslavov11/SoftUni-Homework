using _03.CompanyHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03.CompanyHierarchy.People;

namespace _03.CompanyHierarchy
{
    public class Manager : Employee, IManager
    {
        public Manager(string firstName, string lastName, uint iD, Department department, decimal salary) 
            : base(firstName, lastName, iD, department, salary)
        {
        }

        public IEnumerable<Employee> employeesUnderComand
        {
            get; set;
        }
    }
}
