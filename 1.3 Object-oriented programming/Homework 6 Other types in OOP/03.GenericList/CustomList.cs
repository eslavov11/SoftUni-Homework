using System;
using System.Linq;

namespace CustomGenericList
{
    [Version(0, 1)]
    public class CustomList<T> where T : IComparable<T>
    {
        private const int DefaultSize = 16;
        private T[] elements;
        private int currentIndex;

        public CustomList(int initSize = DefaultSize)
        {
            this.elements = new T[initSize];
            this.currentIndex = 0;
        }

        public void Add(T element)
        {
            if (currentIndex + 1 == elements.Length)
            {
                this.Resize();
            }
            this.elements[currentIndex] = element;
            currentIndex++;
        }

        public void Insert(int index, T element)
        {
            if (currentIndex+1 == this.elements.Length)
            {
                this.Resize();
            }

            for (int i = currentIndex + 1; i > index; i--)
            {
                this.elements[i] = this.elements[i - 1];
            }
            this.elements[index] = element;
            this.currentIndex++;
        }

        public void Clear()
        {
            for (int i = 0; i < currentIndex; i++)
            {
                this.elements[i] = default(T);

            }
        }

        public int Count
        {
            get { return this.currentIndex; }
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < this.currentIndex - 1; i++)
            {
                this.elements[i] = this.elements[i + 1];
            }
            this.elements[currentIndex - 1] = default(T);
            currentIndex--;
        }

        public void Remove(T element)
        {
            int index = this.IndexOf(element);
            for (int i = index; i < this.currentIndex-1; i++)
            {
                this.elements[i] = this.elements[i + 1];
            }
            this.elements[currentIndex-1] = default(T);
            currentIndex--;
        }

        public int IndexOf(T element)
        {
            for (int i = 0; i < this.currentIndex; i++)
            {
                if (this.elements[i].Equals(element))
                {
                    return i;
                }
            }
            return -1;
        }

        public T this [int i]
        {
            get
            {
                return this.elements[i];
            }
            set
            {
                this.elements[i] = value;
            }
        }

        public T Max
        {
            get
            {
                T max = this.elements[0];
                for (int i = 0; i < this.currentIndex; i++)
                {
                    if (max.CompareTo(this.elements[i]) == -1)
                    {
                        max = this.elements[i];
                    }
                }
                return max;
            }
        }

        public T Min
        {
            get
            {
                T min = this.elements[0];
                for (int i = 0; i < this.currentIndex; i++)
                {
                    if (min.CompareTo(this.elements[i]) == 1)
                    {
                        min = this.elements[i];
                    }
                }
                return min;
            }
        }

        private void Resize()
        {
            var newElements = new T[this.currentIndex * 2];
            for (int i = 0; i < this.currentIndex; i++)
            {
                newElements[i] = this.elements[i];
            }
            this.elements = newElements;
        }

        public override string ToString()
        {
            return string.Format($"[{string.Join(", ", this.elements.Take(currentIndex))}]");
        }
    }
}
