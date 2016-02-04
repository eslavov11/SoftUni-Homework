namespace Phonebook.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Phonebook.Data;
    using Phonebook.Interfaces;
    using Phonebook.Models;

    public class PhonebookEngine
    {
        private const string DefaultNumberCode = "+359";
        private readonly IPhonebookRepository phonebookData;
        private readonly StringBuilder input;

        public PhonebookEngine(IPhonebookRepository phonebookData)
        {
            this.phonebookData = phonebookData;
            this.input = new StringBuilder();
        }

        public void Run()
        {
            while (true)
            {
                string data = Console.ReadLine();
                if (data == "End" || data == null)
                {
                    // Error reading from console 
                    break;
                }

                int i = data.IndexOf('(');
                if (i == -1)
                {
                    Console.WriteLine("error!");
                    Environment.Exit(0);
                }

                string commandName = data.Substring(0, i);
                if (!data.EndsWith(")"))
                {
                    this.Run();
                }

                string s = data.Substring(i + 1, data.Length - i - 2);
                string[] commandParts = s.Split(',');
                for (int j = 0; j < commandParts.Length; j++)
                {
                    commandParts[j] = commandParts[j].Trim();
                }

                if (commandParts.Length < 2)
                {
                    // TODO: what to do ^ and if numbers > 10
                    throw new ArgumentException();
                }

                this.ExecuteCommand(commandName, commandParts);
            }

            Console.Write(this.input);
        }

        private void ExecuteCommand(string commandName, string[] commandParts)
        {
            switch (commandName)
            {
                case "AddPhone":
                    string ownerName = commandParts[0];
                    var numbers = commandParts.Skip(1).ToList();
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        numbers[i] = this.FormatNumber(numbers[i]);
                    }

                    var message = this.phonebookData.AddPhone(ownerName, numbers);

                    this.Print(message);
                    break;

                case "ChangePhone":
                    this.Print(this.phonebookData.ChangePhone(
                        this.FormatNumber(commandParts[0]),
                        this.FormatNumber(commandParts[1])) + " numbers changed");
                    break;

                case "List":
                    try
                    {
                        IEnumerable<Entry> entries = this.phonebookData.ListEntries(
                            int.Parse(commandParts[0]),
                            int.Parse(commandParts[1]));
                        foreach (var entry in entries)
                        {
                            this.Print(entry.ToString());
                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        this.Print("Invalid range");
                    }

                    break;
                default:
                    this.Print("Invalid command.");
                    break;
            }
        }

        private string FormatNumber(string unformattedNumber)
        {
            // Skip all non-digit characters except '+'
            // Example: (+359) 888 999 111 --> +359888999111
            StringBuilder cannonicalPhoneBuilder = new StringBuilder();
            foreach (char ch in unformattedNumber)
            {
                if (char.IsDigit(ch) || (ch == '+'))
                {
                    cannonicalPhoneBuilder.Append(ch);
                }
            }

            if (cannonicalPhoneBuilder.Length >= 2 &&
                cannonicalPhoneBuilder[0] == '0' && cannonicalPhoneBuilder[1] == '0')
            {
                // The phone number starts with "00", replace it with "+"
                // Example: 00359888999111 --> +359888999111
                cannonicalPhoneBuilder.Remove(0, 1);
                cannonicalPhoneBuilder[0] = '+';
            }

            while (cannonicalPhoneBuilder.Length > 0 && cannonicalPhoneBuilder[0] == '0')
            {
                // Remove any leading zeros
                // Example: 0894778899 --> 894778899
                cannonicalPhoneBuilder.Remove(0, 1);
            }

            if (cannonicalPhoneBuilder.Length > 0 && cannonicalPhoneBuilder[0] != '+')
            {
                // Insert the default country code the first char is not "+"
                // Example: 894778899 --> +359894778899
                cannonicalPhoneBuilder.Insert(0, "+359");
            }

            string cannonicalPhoneNumber = cannonicalPhoneBuilder.ToString();
            return cannonicalPhoneNumber;
        }

        private void Print(string text)
        {
            this.input.AppendLine(text);
        }
    }
}
