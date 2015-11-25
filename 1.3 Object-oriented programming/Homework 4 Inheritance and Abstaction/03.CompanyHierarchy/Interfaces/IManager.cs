using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CompanyHierarchy.Interfaces
{
    public interface IManager : IEmployee
    {
        IEnumerable<Employee> employeesUnderComand { get; set; }
    }
}
