using Moq;
using NUnit.Framework;
using ReflexComparer.Primitives;
using ReflexComparer.Primitives.Equals;
using ReflexComparer.Primitives.Hash;

namespace ReflexComparerTests.Primitives
{
    [TestFixture]
    public class CompositionEqualityComparerTests
    {
        [Test]
        public void EqualsPropagation()
        {
            var equalsComparerMock = new Mock<IEqualsComparer<int>>();
            var comparer = new CompositionEqualityComparer<int>(equalsComparerMock.Object, new Mock<IHashCodeCalculator<int>>().Object);
            var firstObject = 4; var secondObject = 4;

            comparer.Equals(firstObject, secondObject);

            equalsComparerMock.Verify(e => e.Equals(firstObject, secondObject));
        }

        [Test]
        public void HashCodeCalculatorPropagation()
        {
            var hashCodeCalculatorMock = new Mock<IHashCodeCalculator<int>>();
            var comparer = new CompositionEqualityComparer<int>(new Mock<IEqualsComparer<int>>().Object, hashCodeCalculatorMock.Object);
            var hashObject = 1;

            comparer.GetHashCode(hashObject);

            hashCodeCalculatorMock.Verify(h => h.GetHashCode(hashObject));
        }
    }
}
