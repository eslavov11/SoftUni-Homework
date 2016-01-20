namespace CustomLinkedList.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DynamicListTests
    {
        private DynamicList<int> dynamicList;

        [TestInitialize]
        public void InitializeTest()
        {
            this.dynamicList = new DynamicList<int>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestListIndexer_NegativeLength_ThrowsException()
        {
            this.dynamicList[-1] = 5;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestListIndexer_LengthBiggerThanList_ThrowsException()
        {
            this.dynamicList.Add(10);
            this.dynamicList[1] = 5;
        }

        [TestMethod]
        public void TestAdd_SingleElement_CountOne()
        {
            this.dynamicList.Add(10);

            Assert.AreEqual(1, this.dynamicList.Count, "List count should be 1.");
        }

        [TestMethod]
        public void TestAdd_SingleElement_SuccesfullyAdded()
        {
            this.dynamicList.Add(10);

            Assert.AreEqual(10, this.dynamicList[0], "The first element should be 10.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestRemoveAt_NegativeLength_ThrowsException()
        {
            this.dynamicList.RemoveAt(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestRemoveAt_LengthBiggerThanList_ThrowsException()
        {
            this.dynamicList.Add(10);
            this.dynamicList.RemoveAt(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestRemoveAt_ListEmpty_ThrowsException()
        {
            this.dynamicList.RemoveAt(0);
        }

        [TestMethod]
        public void TestRemoveAt_OneRemoval_CountShouldBeDecremented()
        {
            this.dynamicList.Add(10);
            this.dynamicList.Add(20);
            var oldCount = this.dynamicList.Count;
            this.dynamicList.RemoveAt(1);

            Assert.AreNotEqual(oldCount, this.dynamicList.Count, "The list count should be 1.");
        }

        [TestMethod]
        public void TestRemove_NonExistantElement_ShouldReturnMinusOne()
        {
            this.dynamicList.Add(10);
            this.dynamicList.Add(20);
            var element = this.dynamicList.Remove(30);

            Assert.AreEqual(-1, element, "Remove should return -1 because the element was not in the list");
        }

        [TestMethod]
        public void TestRemove_ExistantElement_ShouldReturnElement()
        {
            this.dynamicList.Add(10);
            this.dynamicList.Add(20);
            var element = this.dynamicList.Remove(20);

            Assert.AreEqual(1, element, "Remove should return the index of the removed element (1).");
        }

        [TestMethod]
        public void TestIndexOf_NonExistantElement_ShouldReturnMinusOne()
        {
            this.dynamicList.Add(10);
            this.dynamicList.Add(20);
            var element = this.dynamicList.IndexOf(30);

            Assert.AreEqual(-1, element, "IndexOf should return index -1 because the element was not in the list");
        }

        [TestMethod]
        public void TestIndexOf_ExistantElement_ShouldReturnElement()
        {
            this.dynamicList.Add(10);
            this.dynamicList.Add(20);
            var element = this.dynamicList.IndexOf(20);

            Assert.AreEqual(1, element, "IndexOf should return 1.");
        }

        [TestMethod]
        public void TestContains_NonExistantElement_ShouldReturnFalse()
        {
            this.dynamicList.Add(10);
            this.dynamicList.Add(20);
            var element = this.dynamicList.Contains(30);

            Assert.AreEqual(false, element, "Contains should return false.");
        }

        [TestMethod]
        public void TestContains_ExistantElement_ShouldReturnTrue()
        {
            this.dynamicList.Add(10);
            this.dynamicList.Add(20);
            var element = this.dynamicList.Contains(20);

            Assert.AreEqual(true, element, "Contains should return true.");
        }
    }
}
