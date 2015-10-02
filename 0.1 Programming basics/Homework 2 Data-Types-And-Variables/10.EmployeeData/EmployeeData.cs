using System;

namespace _10.EmployeeData
{
    class EmployeeData
    {
        static void Main()
        {
            string firstName = "Pesho";
            string lastName = "Georgiev";
            byte age = 27;
            char gender = 'f';
            long personalID = 8306112507;
            int uniqueEmployeeNumber = 27563571;

            Console.WriteLine("First name: {0}\nLast name: {1}\nAge: {2}\nGender: {3}\nPersonal ID: {4}\nUnique Employee Number: {5}",
                firstName,lastName,age,gender,personalID,uniqueEmployeeNumber);
        }
    }
}
