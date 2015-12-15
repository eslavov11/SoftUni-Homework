using Empires.Interfaces;
using Empires.Models.Resources;

namespace Empires.Models
{
    public class Resource : IResource
    {
        private ResourceType resourceType;
        private int quantity;


        public Resource(ResourceType resourceType, int quantity)
        {
            this.ResourceType = resourceType;
            this.Quantity = quantity;
        }

        public ResourceType ResourceType
        {
            get
            {
                return this.resourceType;
            }

            set
            {
                this.resourceType = value;
            }
        }

        public int Quantity
        {
            get
            {
                return this.quantity;
            }

            set
            {
                //TODO VAlidate
                this.quantity = value;
            }
        }
    }
}
