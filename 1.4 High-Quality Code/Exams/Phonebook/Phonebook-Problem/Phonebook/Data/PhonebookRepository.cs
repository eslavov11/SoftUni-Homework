namespace Phonebook.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Phonebook.Interfaces;
    using Phonebook.Models;

    using Wintellect.PowerCollections;

    public class PhonebookRepository : IPhonebookRepository
    {
        private readonly OrderedSet<Entry> entries = new OrderedSet<Entry>();
        private readonly Dictionary<string, Entry> entriesByName = new Dictionary<string, Entry>();
        private readonly MultiDictionary<string, Entry> multidict = new MultiDictionary<string, Entry>(false);

        public string AddPhone(string name, IEnumerable<string> nums)
        {
            string name2 = name.ToLowerInvariant();

            Entry entry;
            string message = string.Empty;
            if (!this.entriesByName.ContainsKey(name2))
            {
                entry = new Entry { Name = name, PhoneNumbers = new SortedSet<string>() };
                this.entriesByName.Add(name2, entry);

                this.entries.Add(entry);
                message = "Phone entry created";
            }
            else
            {
                entry = this.entriesByName[name2];
                message = "Phone entry merged";
            }

            foreach (var num in nums)
            {
                this.multidict.Add(num, entry);
            }

            entry.PhoneNumbers.UnionWith(nums);

            return message;
        }

        public int ChangePhone(string oldEntry, string newEntry)
        {
            var found = this.multidict[oldEntry].ToList();
            foreach (var entry in found)
            {
                entry.PhoneNumbers.Remove(oldEntry);
                this.multidict.Remove(oldEntry, entry);

                entry.PhoneNumbers.Add(newEntry);
                this.multidict.Add(newEntry, entry);
            }

            return found.Count;
        }

        public Entry[] ListEntries(int first, int num)
        {
            if (first < 0 || first + num > this.entriesByName.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid start index or count.");
            }

            // PERFORMANCE: removed getting entries in range with loop
            return this.entries.Range(
                this.entries[first],
                true, 
                this.entries[first + num - 1], 
                true).ToArray();
        }
    }
}