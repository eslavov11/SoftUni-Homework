using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empires.Models.Resources;

namespace Empires.Models.Buildings
{
    public class Archery : Building
    {
        private const int DefaultResouceQuantity = 5;
        private const ResourceType DefaultResouceType = ResourceType.Gold;

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
