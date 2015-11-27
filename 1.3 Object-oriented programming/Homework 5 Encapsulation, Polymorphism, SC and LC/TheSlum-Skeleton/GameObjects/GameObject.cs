using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSlum.GameObjects
{
    public abstract class GameObject
    {
        public GameObject(string id)
        {
            this.Id = id;
        }

        public string Id { get; private set; }
    }
}
