using System;
using System.Diagnostics;

namespace ReflexComparer.Primitives.Equals
{
    public class RecursiveReflectionEqualsComparer<T> : IEqualsComparer<T>
    {
        public bool Equals(T first, T second)
        {
            return RecursiveEquals(first, second);
        }

        private bool RecursiveEquals(object first, object second)
        {
            if (first == null)
            {
                return second == null;
            }
            else
            {
                if (second == null)
                {
                    return false;
                }
            }

            var objectType = first.GetType();
            Debug.Assert(objectType == second.GetType());

            var equatableType = typeof(IEquatable<>).MakeGenericType(new Type[] { objectType });

            if (equatableType.IsAssignableFrom(objectType))
            {
                return Equals(first, second);
            }

            // TODO: what about collections? 

            foreach (var property in objectType.GetProperties())
            {
                var firstValue = property.GetValue(first, null);
                var secondValue = property.GetValue(second, null);

                if (!RecursiveEquals(firstValue, secondValue))
                {
                    return false;
                }
            }

            return true;
        }
    }
}