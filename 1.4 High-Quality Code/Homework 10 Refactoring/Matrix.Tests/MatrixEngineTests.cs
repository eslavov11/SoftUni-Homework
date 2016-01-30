using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Matrix.Tests
{
    using System.Runtime.InteropServices;

    using Matrix.Core;

    [TestClass]
    public class MatrixEngineTests
    {
        [TestMethod]
        public void TestGenerateMatrixWithSize3()
        {
            var engine = new MatrixEngine();
            ulong[,] matrix = engine.GenerateMatrix(3);

            ulong[,] expectedResult =
            {
                { 1, 7, 8, },
                {6, 2, 9, },
                { 5, 4, 3, },
            };

            CollectionAssert.AreEqual(expectedResult, matrix);
        }
    }
}
