using System;

namespace Homework_1_Defining_Classes
{
    class Person
    {
        private string name;
        private byte age;
        private string email;


        public Person(string name, byte age) : this(name, age, null)
        {
        }

        public Person (string name, byte age, string email)
        {
            this.Name = name;
            this.Age = age;
            this.Email = email;
        }

        

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid name!");
                }
                this.name = value;
            }
        }

        public byte Age
        {
            get { return this.age; }
            set
            {
                if(value<1 || value>100)
                {
                    throw new ArgumentException("Age should be in the interval [1..100]");
                }
                this.age = value;
            }
        }

        public string Email
        {
            get { return this.email; }
            set
            {
                if (value == null || value.Contains("@"))
                {
                    this.email = value;
                }
                else
                {
                    throw new ArgumentException("Invalid email!");
                }
                
            }
        }

        public override string ToString()
        {
            string result;
            if (string.IsNullOrEmpty(this.Email))
            {
                result = String.Format("My name is {0} and I'm {1} years old.", this.Name, this.Age);
            }
            else
            {
                result = String.Format("My name is {0} and I'm {1} years old. My email is {2}", this.Name, this.Age, this.Email);
            }
            return result;
        }
    }
}


/*Define a class Person that has name, age and email. The name and age are mandatory.
The email is optional. Define properties that accept non-empty name and age in the range
    [1 ... 100]. In case of invalid arguments, throw an exception. Define a property for 
        the email that accepts either null or non-empty string containing '@'. Define two 
        constructors. The first constructor should take name, age and email. The second
        constructor should take name and age only and call the first constructor. Implement
        the ToString() method to enable printing persons at the console. */