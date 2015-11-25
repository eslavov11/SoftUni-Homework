using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CompanyHierarchy.Interfaces
{
    public interface IDeveloper : IRegularEmployee
    {
        IEnumerable<IProject> Projects { get; set; }
    }
}
