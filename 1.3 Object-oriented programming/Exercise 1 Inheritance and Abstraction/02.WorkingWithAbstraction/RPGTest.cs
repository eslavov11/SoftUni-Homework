using _02.WorkingWithAbstraction.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.WorkingWithAbstraction
{
    class RPGTest
    {
        static void Main(string[] args)
        {
            Warrior warr = new Warrior();
            Priest pr = new Priest();
            pr.Heal(warr);
            warr.Attack(pr);
        }
    }
}
