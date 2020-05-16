using NUnit.Framework;
using ReflexComparer.Primitives.Hash;
using ReflexComparerTests.TestClasses;

namespace ReflexComparerTests.Primitives.Hash
{
    [TestFixture]
    public class ConstHashCodeCalculatorTests
    {
        [TestCase("test", 0)]
        [TestCase("", 0)]
        [TestCase(null, 0)]
        public void GetHashStringPropertyClass(string value, int expectedHash)
        {
            TestHelper.AssertGetHashEqual<StringPropertyClass, ConstHashCodeCalculator<StringPropertyClass>>(
                new StringPropertyClass(value), expectedHash);
        }

        [TestCase("1", "2", 0)]
        [TestCase("1", null, 0)]
        [TestCase(null, "2", 0)]
        [TestCase("", "", 0)]
        public void GetHashContainedStringPropertyClass(
            string firstString, string secondString, int expectedHash)
        {
            TestHelper.AssertGetHashEqual<ContainedStringPropertyClass, ConstHashCodeCalculator<ContainedStringPropertyClass>>(
                new ContainedStringPropertyClass(firstString, new StringPropertyClass(secondString)), expectedHash);
        }
    }
}