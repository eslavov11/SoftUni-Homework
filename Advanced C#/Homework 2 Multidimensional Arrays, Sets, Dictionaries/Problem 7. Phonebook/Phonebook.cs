using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_7.Phonebook
{
    class Phonebook
    {
        static void Main(string[] args)
        {
            Dictionary<string,string> phonebook = new Dictionary<string,string>();
            string contacts = ""; 
            while (true)
            {
                contacts = Console.ReadLine();
                if (contacts=="search")
                {
                    break;
                }
                string[] contact = contacts.Split('-');
                phonebook.Add(contact[0], contact[1]);
            }
            string input = "";
            while (true)
            {
                input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }
                int count = 0;
                foreach (var item in phonebook)
                {
                    if (item.Key==input)
                    {
                        Console.WriteLine("{0} -> {1}", item.Key, item.Value);  
                    }
                    else
                    {
                        count++;
                    }
                }
                if (count!=0)
                {
                    Console.WriteLine("Contact {0} does not exist.",input);
                }
            }
        }
    }
}