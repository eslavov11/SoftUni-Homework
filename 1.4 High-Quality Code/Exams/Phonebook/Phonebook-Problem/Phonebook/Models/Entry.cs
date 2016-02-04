namespace Phonebook.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Entry : IComparable<Entry>
    {
        public string Name { get; set; }

        public SortedSet<string> PhoneNumbers { get; set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append('[' + this.Name);
            bool flag = true;
            foreach (var phone in this.PhoneNumbers)
            {
                if (flag)
                {
                    output.Append(": ");
                    flag = false;
                }
                else
                {
                    output.Append(", ");
                }

                output.Append(phone);
            }

            output.Append(']');

            return output.ToString();
        }

        public int CompareTo(Entry other)
        {
            return this.Name.ToLowerInvariant().CompareTo(other.Name.ToLowerInvariant());
        }
    }
}