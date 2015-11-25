using _03.CompanyHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03.CompanyHierarchy.People;

namespace _03.CompanyHierarchy
{
    public abstract class RegularEmpoyee : Employee, IRegularEmployee
    {
        public RegularEmpoyee(string firstName, string lastName, uint iD, Department department, decimal salary)
            : base(firstName, lastName, iD, department, salary)
        {
        }
    }
}
