namespace mUnit.Core.Assertions
{
    using Exceptions;

    public class Assert
    {
        // TODO: Add AreEqual() for primitive types (e.g. double, decimal, int) 
        // to avoid incorrect equality checks (e.g. AreEqual(3m, 3d))

        public static void AreEqual(object expected, object actual, string message = null)
        {
            if (!expected.Equals(actual))
            {
                throw new AssertFailedException(message);
            }
        }

        public static void IsNull(object obj, string message = null)
        {
            if (obj != null)
            {
                throw new AssertFailedException(message);
            }
        }

        public static void IsTrue(bool condition, string message = null)
        {
            if (!condition)
            {
                throw new AssertFailedException(message);
            }
        }
    }
}
