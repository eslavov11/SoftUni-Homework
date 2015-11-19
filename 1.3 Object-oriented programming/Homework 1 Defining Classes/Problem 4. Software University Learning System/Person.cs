using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_4.Software_University_Learning_System
{
    abstract class Person
    {
        private string firstName;
        private string lastName;
        private byte age;
        
        public Person(string fName, string lName, byte age)
        {
            this.FirstName = fName;
            this.LastName = lName;
            this.Age = age;
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                lastName = value;
            }
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
                    throw new ArgumentOutOfRangeException("age", "Age should be an integer between 0 and 100.");
                }

                this.age = value;
            }
        }

        public override string ToString()
        {
            var result = string.Format("{1}, {0}\r\n", this.FirstName, this.LastName);
            result += "Age: " + this.Age + "\r\n";

            return result;
        }
    }
}
