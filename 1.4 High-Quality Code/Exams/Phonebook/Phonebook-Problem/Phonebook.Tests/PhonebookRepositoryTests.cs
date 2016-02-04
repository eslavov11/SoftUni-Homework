using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Phonebook.Tests
{
    using System.Collections.Generic;
    using System.Linq;

    using Phonebook.Interfaces;
    using Phonebook.Data;
    using Phonebook.Models;

    [TestClass]
    public class PhonebookRepositoryTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestListEntries_NegativeStartIndex_ShouldThrow()
        {
            int startIndex = -1;
            int endIndex = 0;
            IPhonebookRepository phonebookRepo = new PhonebookRepository();

            phonebookRepo.ListEntries(startIndex, endIndex);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestListEntries_NegativeEndIndex_ShouldThrow()
        {
            int startIndex = 0;
            int endIndex = -1;
            IPhonebookRepository phonebookRepo = new PhonebookRepository();

            phonebookRepo.ListEntries(startIndex, endIndex);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestListEntries_OutOfRangeStartIndex_ShouldThrow()
        {
            int startIndex = 3;
            int endIndex = 0;
            IPhonebookRepository phonebookRepo = new PhonebookRepository();

            phonebookRepo.ListEntries(startIndex, endIndex);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestListEntries_OutOfRangeEndIndex_ShouldThrow()
        {
            int startIndex = 0;
            int endIndex = 3;
            IPhonebookRepository phonebookRepo = new PhonebookRepository();

            phonebookRepo.ListEntries(startIndex, endIndex);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestListEntries_NegativeIndeces_ShouldThrow()
        {
            int startIndex = -1;
            int endIndex = -1;
            IPhonebookRepository phonebookRepo = new PhonebookRepository();

            phonebookRepo.ListEntries(startIndex, endIndex);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestListEntries_OutOfRangeIndeces_ShouldThrow()
        {
            int startIndex = 1;
            int endIndex = 1;
            IPhonebookRepository phonebookRepo = new PhonebookRepository();

            phonebookRepo.ListEntries(startIndex, endIndex);
        }

        [TestMethod]
        public void TestListEntries_RangeCoversAllEntries_CollectionsShouldMatch()
        {
            int startIndex = 0;
            int endIndex = 2;
            IPhonebookRepository phonebookRepo = new PhonebookRepository();
            Entry[] entries =
                            {
                                new Entry()
                                    {
                                        Name = "Maina",
                                        PhoneNumbers = new SortedSet<string>() { "+359123"}
                                    },
                                new Entry()
                                    {
                                        Name = "Maina2",
                                        PhoneNumbers = new SortedSet<string>() { "+359123"}
                                    },
                            };

            phonebookRepo.AddPhone(entries[0].Name, entries[0].PhoneNumbers);
            phonebookRepo.AddPhone(entries[1].Name, entries[1].PhoneNumbers);

            var returnedEntries = phonebookRepo.ListEntries(startIndex, endIndex);

            Assert.AreEqual(entries[1].Name, returnedEntries[1].Name, "Entries names should be equal.");
            Assert.AreEqual(entries[1].PhoneNumbers.ElementAt(0),
                returnedEntries[1].PhoneNumbers.ElementAt(0), "Entries numbers should be equal.");
        }

        [TestMethod]
        public void TestListEntries_RangeOneOfTwoEntries_EntriesShouldMatch()
        {
            int startIndex = 0;
            int endIndex = 2;
            IPhonebookRepository phonebookRepo = new PhonebookRepository();
            Entry[] entries =
                            {
                                new Entry()
                                    {
                                        Name = "Maina",
                                        PhoneNumbers = new SortedSet<string>() { "+359123"}
                                    },
                                new Entry()
                                    {
                                        Name = "Maina2",
                                        PhoneNumbers = new SortedSet<string>() { "+359123"}
                                    },
                            };

            phonebookRepo.AddPhone(entries[0].Name, entries[0].PhoneNumbers);
            phonebookRepo.AddPhone(entries[1].Name, entries[1].PhoneNumbers);

            var returnedEntries = phonebookRepo.ListEntries(startIndex, endIndex);

            Assert.AreEqual(entries[0].Name, returnedEntries[0].Name, "Entries names should be equal.");
            Assert.AreEqual(entries[0].PhoneNumbers.ElementAt(0),
                returnedEntries[0].PhoneNumbers.ElementAt(0), "Entries numbers should be equal.");
        }
    }
}
