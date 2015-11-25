using _02.Animals.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Animals
{
    public abstract class Animal : ISoundProducible
    {
        private string name;
        private string gender;
        private byte age;

        public Animal(byte age, string gender, string name)
        {
            this.Age = age;
            this.Gender = gender;
            this.Name = name;
        }

        public byte Age
        {
            get
            {
                return age;
            }

            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentOutOfRangeException("Invalid age");
                }
                this.age = value;
            }
        }

        public string Gender
        {
            get
            {
                return gender;
            }

            set
            {
                if (value != "male" && value!= "female")
                {
                    throw new FormatException("Invalid gender!");
                }
                this.gender = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public abstract void ProduceSound();
    }
}
