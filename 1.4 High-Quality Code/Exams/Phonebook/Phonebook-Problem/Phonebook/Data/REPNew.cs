namespace Phonebook.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;

    using Phonebook.Models;

    public class REPNew : IPhonebookRepository
    {
        private readonly List<Entry> entries = new List<Entry>();

        public string AddPhone(string name, IEnumerable<string> nums)
        {
            var entryWithSameName = from entry in this.entries
                      where entry.Name.ToLowerInvariant() == name.ToLowerInvariant()
                      select entry;

            if (!entryWithSameName.Any())
            {
                Entry entry = new Entry { Name = name, PhoneNumbers = new SortedSet<string>() };

                foreach (var num in nums)
                {
                    entry.PhoneNumbers.Add(num);
                }

                this.entries.Add(entry);

                return "Phone entry created";
            }
            else if (entryWithSameName.Count() == 1)
            {
                Entry entry = entryWithSameName.First();
                foreach (var num in nums)
                {
                    entry.PhoneNumbers.Add(num);
                }

                // TODO: add to database

                return "Phone entry merged";
            }
            else
            {
                return "Duplicated name in the phonebook found: " + name;
            }
        }

        public int ChangePhone(string oldEntry, string newEntry)
        {
            var list = from entry in this.entries
                       where entry.PhoneNumbers.Contains(oldEntry)
                       select entry;

            int nums = 0;
            foreach (var entry in list)
            {
                entry.PhoneNumbers.Remove(oldEntry);
                entry.PhoneNumbers.Add(newEntry);
                nums++;
            }

            return nums;
        }

        public Entry[] ListEntries(int start, int num)
        {
            if (start < 0 || start + num > this.entries.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid start index or count.");
            }

            this.entries.Sort();
            Entry[] ent = new Entry[num];
            for (int i = start; i <= start + num - 1; i++)
            {
                Entry entry = this.entries[i];
                ent[i - start] = entry;
            }

            return ent;
        }
    }
}