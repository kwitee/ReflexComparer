using NUnit.Framework;
using ReflexComparer.Primitives.Equals;
using ReflexComparer.Primitives.Hash;

namespace ReflexComparerTests.Primitives.Hash
{
    public static class TestHelper
    {
        public static void AssertEqual<T, U>(T first, T second, bool expectedOutput)
            where U : IEqualsComparer<T>, new()
        {
            var comparer = new U();

            var output = comparer.Equals(first, second);

            Assert.AreEqual(expectedOutput, output);
        }

        public static void AssertGetHashEqual<T, U>(T value, int expectedHash) 
            where U : IHashCodeCalculator<T>, new()
        {
            var hashCalculator = new U();

            var hash = hashCalculator.GetHashCode(value);

            Assert.AreEqual(expectedHash, hash);
        }
    }
}