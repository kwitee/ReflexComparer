using NUnit.Framework;
using ReflexComparer.Primitives.Hash;
using ReflexComparerTests.TestClasses;

namespace ReflexComparerTests.Primitives.Hash
{
    [TestFixture]
    public class ReflectionHashCodeCalculatorTests
    {
        [TestCase(1, 390)]
        [TestCase(0, 391)]
        [TestCase(1024, 1415)]
        public void GetHashIntPropertyClass(int value, int expectedHash)
        {
            TestHelper.AssertGetHashEqual<IntPropertyClass, ReflectionHashCodeCalculator<IntPropertyClass>>(
                new IntPropertyClass(value), expectedHash);
        }
    }

    // TODO: add more tests
}