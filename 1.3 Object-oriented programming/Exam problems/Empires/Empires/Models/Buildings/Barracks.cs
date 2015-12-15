using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empires.Models.Resources;

namespace Empires.Models.Buildings
{
    public class Barracks : Building
    {
        private const int DefaultResouceQuantity = 10;
        private const ResourceType DefaultResouceType = ResourceType.Steel;
        private const int DefaultBarracksTurnsToProduceUnit = 4;
        private const int DefaultBarracksTurnsToProduceResources = 3;

        public override void ProduceUnit()
        {
            throw new NotImplementedException();
        }

        public override void ProduceResources()
        {
            throw new NotImplementedException();
        }
    }
}
