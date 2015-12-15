using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empires.Interfaces;
using Empires.Models.Resources;
using Empires.Models.Units;

namespace Empires.Models.Buildings
{
    public class Barracks : Building
    {
        private const int DefaultResouceQuantity = 10;
        private const ResourceType DefaultResouceType = ResourceType.Steel;
        private const int DefaultBarracksTurnsToProduceUnit = 4;
        private const int DefaultBarracksTurnsToProduceResources = 3;

        public override IUnit ProduceUnit()
        {
            return base.Turns % DefaultBarracksTurnsToProduceUnit == 0 && this.Turns != 0 ? new Swordsman() : null;
        }

        public override IResource ProduceResources()
        {
           return base.Turns % DefaultBarracksTurnsToProduceResources == 0 && this.Turns!=0 ? 
                new Resource(DefaultResouceType, DefaultResouceQuantity) 
                : null;
        }

        public override string ToString()
        {
            return string.Format(
                base.ToString(), 
                this.GetType().Name, 
                base.Turns,
                DefaultBarracksTurnsToProduceUnit - base.Turns % DefaultBarracksTurnsToProduceUnit, 
                "Swordsman",
                DefaultBarracksTurnsToProduceResources - base.Turns % DefaultBarracksTurnsToProduceResources, 
                DefaultResouceType);
        }
    }
}
