using NUnit.Framework;
using ReflexComparer.Primitives.Equals;
using ReflexComparerTests.Primitives.Hash;
using ReflexComparerTests.TestClasses;

namespace ReflexComparerTests.Primitives.Equals
{
    [TestFixture]
    public class RecursiveReflectionEqualsComparerTests
    {
        [TestCase("test", "test", true)]
        [TestCase(null, null, true)]
        [TestCase(null, "Test", false)]
        [TestCase("", null, false)]
        [TestCase("", "", true)]
        public void EqualsStringPropertyClass(string firstString, string secondString, bool expectedOutput)
        {
            TestHelper.AssertEqual<StringPropertyClass, RecursiveReflectionEqualsComparer<StringPropertyClass>>(
                new StringPropertyClass(firstString), new StringPropertyClass(secondString), expectedOutput);
        }

        [TestCase("1", "2", "1", "2", true)]
        [TestCase("1", "2", "1", "3", false)]
        [TestCase("1", "2", "3", "2", false)]
        [TestCase(null, "2", null, "2", true)]
        [TestCase(null, null, null, null, true)]
        [TestCase(null, "2", "1", "2", false)]
        [TestCase("1", "2", "1", null, false)]
        public void EqualsContainedStringPropertyClass(
            string firstStringOne, string firstStringTwo, 
            string secondStringOne, string secondStringTwo, 
            bool expectedOutput)
        {
            TestHelper.AssertEqual<ContainedStringPropertyClass, RecursiveReflectionEqualsComparer<ContainedStringPropertyClass>>(
                new ContainedStringPropertyClass(firstStringOne, new StringPropertyClass(firstStringTwo)), 
                new ContainedStringPropertyClass(secondStringOne, new StringPropertyClass(secondStringTwo)),
                expectedOutput);
        }

        [TestCase(1, 1, 3.5, 3.5, "hello", "hello", "a", "a", true, true, true)]
        [TestCase(1, 2, 3.5, 3.5, "hello", "hello", "a", "a", true, true, false)]
        [TestCase(1, 1, 3.5, 7.24, "hello", "hello", "a", "a", true, true, false)]
        [TestCase(1, 1, 3.5, 3.5, "hello", "hi", "a", "a", true, true, false)]
        [TestCase(1, 1, 3.5, 3.5, "hello", "hello", "a", "b", true, true, false)]
        [TestCase(1, 1, 3.5, 3.5, "hello", "hello", "a", "a", true, false, false)]
        public void EqualsPrimitivePropertiesClass(
            int firstInt, int secondInt, 
            double firstDouble, double secondDouble, 
            string firstString, string secondString,
            char firstChar, char secondChar,
            bool firstBool, bool secondBool,
            bool expectedOutput)
        {
            TestHelper.AssertEqual<PrimitivePropertiesClass, RecursiveReflectionEqualsComparer<PrimitivePropertiesClass>>(
                new PrimitivePropertiesClass(firstInt, firstDouble, firstString, firstChar, firstBool),
                new PrimitivePropertiesClass(secondInt, secondDouble, secondString, secondChar, secondBool),
                expectedOutput);
        }
    }
}