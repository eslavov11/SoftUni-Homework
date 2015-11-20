using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace P6.BitArray
{
    class BitArray
    {
        private byte[] bits;

        public BitArray(int size)
        {
            if (size < 0 || size > 100000)
            {
                Console.WriteLine("Value should be in range [0; 100000]");
                return;
            }
            this.bits = new byte[size];
        }

        public byte this[int index]
        {
            get
            {
                return this.bits[index];
            }
            set
            {
                this.bits[index] = value;
            }
        }

        public override string ToString()
        {
            BigInteger number = 0;

            for (int i = 0; i < this.bits.Length; i++)
            {
                if (this.bits[i] == 1)
                {
                    number += BigInteger.Pow(2, i);
                }
            }

            return number.ToString();
        }

    }
}
