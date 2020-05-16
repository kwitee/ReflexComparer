using System.Collections.Generic;

namespace ReflexComparerPerformanceTests.TestsClasses
{
    public class IntPropertyClassEqualityComparer : IEqualityComparer<IntPropertyClass>
    {
        public bool Equals(IntPropertyClass x, IntPropertyClass y)
        {
            return x.IntProperty == y.IntProperty;
        }

        public int GetHashCode(IntPropertyClass obj)
        {
            return obj.IntProperty.GetHashCode();
        }
    }
}