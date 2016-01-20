using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01.LinkedQueue.Tests
{
    [TestClass]
    public class LinkedQueueTests
    {
        [TestMethod]
        public void TestDequeue_SingleElement_ShouldReturnProperElement()
        {
            var queue = new LinkedQueue<int>();
            queue.Enqueue(50);
            var element = queue.Dequeue();

            Assert.AreEqual(50, element, "Element value should be 50.");
        }

        [TestMethod]
        public void TestDequeue_MultipleElements_ShouldReturnProperElements()
        {
            var queue = new LinkedQueue<int>();
            queue.Enqueue(50);
            queue.Enqueue(60);
            queue.Enqueue(70);
            var elementOne = queue.Dequeue();
            var elementTwo = queue.Dequeue();
            var elementThree = queue.Dequeue();

            Assert.AreEqual(50, elementOne, "First element value should be 50.");
            Assert.AreEqual(60, elementTwo, "Second element value should be 60.");
            Assert.AreEqual(70, elementThree, "Third element value should be 70.");
        }

        [TestMethod]
        public void TestCount_SingleElement_CountOne()
        {
            var queue = new LinkedQueue<int>();
            queue.Enqueue(50);
            queue.Enqueue(60);
            queue.Enqueue(70);
            queue.Enqueue(int.MaxValue);

            Assert.AreEqual(4, queue.Count, "Queue count should be 4.");
        }

        [TestMethod]
        public void TestCount_SeveralElementsWithDequeue_CountTwo()
        {
            var queue = new LinkedQueue<int>();
            queue.Enqueue(50);
            queue.Enqueue(60);
            queue.Enqueue(70);
            queue.Enqueue(int.MaxValue);

            queue.Dequeue();
            queue.Dequeue();

            Assert.AreEqual(2, queue.Count, "Queue count should be 2.");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestDequeue_EmptyQueue_ThrowsException()
        {
            var queue = new LinkedQueue<int>();
            queue.Dequeue();
        }
    }
}
