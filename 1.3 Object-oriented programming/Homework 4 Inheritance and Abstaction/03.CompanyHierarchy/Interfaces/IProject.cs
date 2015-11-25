using _03.CompanyHierarchy.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CompanyHierarchy.Interfaces
{
    public interface IProject
    {
        string ProjectName { get; set; }

        DateTime StartDate { get; set; }

        string Details { get; set; }

        State State { get; set; }

        void CloseProject();
    }
}
