namespace ChepelareHotelBookingSystem.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using ChepelareHotelBookingSystem.Interfaces;

    public class Repository<T> : IRepository<T> where T : IDbEntity
    {
        private int nextAddId = 1;
        private Dictionary<int, T> items;

        public Repository()
        {
            this.items = new Dictionary<int, T>(new DbEqualityComparer());
        }

        public virtual IEnumerable<T> GetAll()
        {
            return this.items
                .OrderBy(item => item.Key)
                .Select(item => item.Value);
        }

        public virtual T Get(int id)
        {
            T item;
            try
            {
                item = this.items[id];
            }
            catch (KeyNotFoundException)
            {
                item = default(T);
            }

            return item;
        }

        public virtual void Add(T item)
        {
            item.Id = this.nextAddId;
            this.items.Add(this.nextAddId, item);
            this.nextAddId++;
        }

        public virtual bool Update(int id, T newItem)
        {
            var item = this.Get(id);
            if (item == null)
            {
                return false;
            }

            item = newItem;
            return true;
        }

        public virtual bool Delete(int id)
        {
            return this.items.Remove(id);
        }

        private class DbEqualityComparer : IEqualityComparer<int>
        {
            public bool Equals(int x, int y)
            {
                return x == y;
            }

            public int GetHashCode(int obj)
            {
                return obj % 10;
            }
        }
    }
}