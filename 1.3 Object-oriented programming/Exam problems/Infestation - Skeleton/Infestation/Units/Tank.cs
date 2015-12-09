using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Infestation.Units
{
    public class Tank : Unit
    {
        private const int DefaultTankPower = 25;
        private const int DefaultTankHealth = 20;
        private const int DefaultTankAgression = 25;
        private const UnitClassification DefaultTankUnitClassification = UnitClassification.Mechanical;

        public Tank(string id) 
            : base(id, DefaultTankUnitClassification, DefaultTankHealth, DefaultTankPower, DefaultTankAgression)
        {
        }
    }
}
