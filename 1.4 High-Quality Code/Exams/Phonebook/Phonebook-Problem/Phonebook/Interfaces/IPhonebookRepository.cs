namespace Phonebook.Interfaces
{
    using System.Collections.Generic;

    using Phonebook.Models;

    public interface IPhonebookRepository
    {
        string AddPhone(string name, IEnumerable<string> phoneNumbers);

        int ChangePhone(string oldEntry, string newEntry);

        Entry[] ListEntries(int startIndex, int count);
    }
}