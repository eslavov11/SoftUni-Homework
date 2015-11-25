using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CompanyHierarchy.Interfaces
{
    public interface IPerson
    {
        uint ID { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }
    }
}
