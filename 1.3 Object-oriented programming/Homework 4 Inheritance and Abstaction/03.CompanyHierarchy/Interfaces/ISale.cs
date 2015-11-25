using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CompanyHierarchy.Interfaces
{
    public interface ISale
    {
        string ProductName { get; set; }

        DateTime date { get; set; }

        decimal Price { get; set; }
    }
}
