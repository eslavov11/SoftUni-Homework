namespace Phonebook
{
    using Phonebook.Core;
    using Phonebook.Data;
    using Phonebook.Interfaces;

    public class PhonebookMain
    {
        public static void Main()
        {
            IPhonebookRepository phonebook = new PhonebookRepository();
            IPhonebookRepository phonebookData = new PhonebookRepository();
            var engine = new PhonebookEngine(phonebook);
            engine.Run();
        }
    }
}
