using _03.CompanyHierarchy.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CompanyHierarchy
{
    public class Test
    {
        static void Main(string[] args)
        {
            Developer dev = new Developer("Fiki", "Stoyanov", 552, Department.Accounting, 2000);
            Developer dev2 = new Developer("Boris", "Ivanov", 563, Department.Production, 1000);
            Manager manager = new Manager("Kostadin", "Blagoev", 522, Department.Sales, 3200);
            SalesEmployee salesEmp = new SalesEmployee("Strahil", "Momchilov", 500, Department.Marketing, 750.43m);

            IList <Employee> employees = new List<Employee>
            {
                dev,
                dev2,
                manager,
                salesEmp
            };

            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee);
            }
        }
    }
}
