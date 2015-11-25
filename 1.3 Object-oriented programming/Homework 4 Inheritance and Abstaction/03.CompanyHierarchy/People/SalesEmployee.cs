using _03.CompanyHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CompanyHierarchy.People
{

    public class SalesEmployee : RegularEmpoyee, ISalesEmployee
    {
        public SalesEmployee(string firstName, string lastName, uint iD, Department department, decimal salary)
            : base(firstName, lastName, iD, department, salary)
        {
        }

        public IEnumerable<ISale> Sales
        {
            get; set;
        }
    }
}
