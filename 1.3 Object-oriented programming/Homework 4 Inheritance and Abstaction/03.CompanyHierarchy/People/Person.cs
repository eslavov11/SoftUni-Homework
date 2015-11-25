using _03.CompanyHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CompanyHierarchy
{
    public class Person : IPerson
    {
        public Person(string firstName, string lastName, uint iD)
        {
            this.FirstName = firstName;
            this.ID = iD;
            this.LastName = lastName;
        }

        public uint ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
