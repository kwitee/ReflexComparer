using System;
using System.Collections;
using System.Linq;

namespace ReflexComparer.Primitives.Hash
{
    public class ReflectionHashCodeCalculator<T> : IHashCodeCalculator<T>
    {
        private const int InitialHashValue = 17;
        private const int HashMultiplier = 23;

        public int GetHashCode(T obj)
        {
            unchecked
            {
                return RecursiveGetHashCode(obj);
            }
        }

        private int RecursiveGetHashCode(object obj)
        {
            if (obj == null)
            {
                return 0;
            }

            var equatableHashCode = GetEquatableHashCode(obj);

            if (equatableHashCode != null)
            {
                return equatableHashCode.Value;
            }

            var enumerableHashCode = GetEnumberableHashCode(obj);

            if (enumerableHashCode != null)
            {
                return enumerableHashCode.Value;
            }

            return CalculateHash(obj.GetType().GetProperties().Select(p => p.GetValue(obj, null)));
        }

        private int? GetEquatableHashCode(object obj)
        {
            var objectType = obj.GetType();
            var equatableType = typeof(IEquatable<>).MakeGenericType(new Type[] { objectType });

            if (equatableType.IsAssignableFrom(objectType))
            {
                return obj.GetHashCode();
            }

            return null;
        }

        private int? GetEnumberableHashCode(object obj)
        {
            if (obj is IEnumerable enumerable)
            {
                return CalculateHash(enumerable);
            }

            return null;
        }

        private int CalculateHash(IEnumerable objects)
        {
            var hash = InitialHashValue;

            foreach (var obj in objects)
            {
                hash = (hash * HashMultiplier) ^ RecursiveGetHashCode(obj);
            }

            return hash;
        }
    }
}