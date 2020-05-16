using ReflexComparer.Primitives.Equals;
using ReflexComparer.Primitives.Hash;
using System;
using System.Collections.Generic;

namespace ReflexComparer.Primitives
{
    public class CompositionEqualityComparer<T> : IEqualityComparer<T>
    {
        private readonly IEqualsComparer<T> _equalsComparer;
        private readonly IHashCodeCalculator<T> _hashCodeCalculator;

        public CompositionEqualityComparer(IEqualsComparer<T> equalsComparer, IHashCodeCalculator<T> hashCodeCalculator)
        {
            _equalsComparer = equalsComparer ?? throw new ArgumentNullException(nameof(equalsComparer));
            _hashCodeCalculator = hashCodeCalculator ?? throw new ArgumentNullException(nameof(hashCodeCalculator));
        }

        public bool Equals(T first, T second) => _equalsComparer.Equals(first, second);

        public int GetHashCode(T obj) => _hashCodeCalculator.GetHashCode(obj);
    }
}