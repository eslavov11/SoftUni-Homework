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
    public class Archery : Building
    {
        private const int DefaultResouceQuantity = 5;
        private const ResourceType DefaultResouceType = ResourceType.Gold;
        private const int DefaultArcheryTurnsToProduceUnit = 3;
        private const int DefaultArcheryTurnsToProduceResources = 2;

        public override IUnit ProduceUnit()
        {
            return base.Turns % DefaultArcheryTurnsToProduceUnit == 0 && this.Turns != 0 ? new Archer() : null;
        }

        public override IResource ProduceResources()
        {
            return base.Turns % DefaultArcheryTurnsToProduceResources == 0 && this.Turns != 0 ?
                new Resource(DefaultResouceType, DefaultResouceQuantity)
                : null;
        }

        public override string ToString()
        {
            return string.Format(
                base.ToString(),
                this.GetType().Name,
                base.Turns,
                DefaultArcheryTurnsToProduceUnit - base.Turns % DefaultArcheryTurnsToProduceUnit,
                "Archer",
                DefaultArcheryTurnsToProduceResources - base.Turns % DefaultArcheryTurnsToProduceResources,
                DefaultResouceType);
        }
    }
}
