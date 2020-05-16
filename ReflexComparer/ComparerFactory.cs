using ReflexComparer.Primitives;
using ReflexComparer.Primitives.Equals;
using ReflexComparer.Primitives.Hash;

namespace ReflexComparer
{
    public static class ComparerFactory
    {
        public static CompositionEqualityComparer<T> CreateRecursiveReflectionComparer<T>(bool constantHash = true)
        {
            IHashCodeCalculator<T> hashCodeCalculator;            
            if (constantHash)
            {
                hashCodeCalculator = new ConstHashCodeCalculator<T>();
            }
            else
            {
                hashCodeCalculator = new ReflectionHashCodeCalculator<T>();
            }
            
            return new CompositionEqualityComparer<T>(new RecursiveReflectionEqualsComparer<T>(), hashCodeCalculator);
        }
    }
}