using _03.CompanyHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CompanyHierarchy.People
{
    public class Developer : RegularEmpoyee, IDeveloper
    {
        public Developer(string firstName, string lastName, uint iD, Department department, decimal salary)
            : base(firstName, lastName, iD, department, salary)
        {
        }

        public IEnumerable<IProject> Projects
        {
            get; set;
        }
    }
}
