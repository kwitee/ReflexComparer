using System.Collections.Generic;

namespace ReflexComparerTests.Primitives
{
    public class ListPropertyClass
    {
        public List<int> ArrayProperty { get; }

        public ListPropertyClass(IEnumerable<int> ints)
        {
            ArrayProperty = new List<int>();
            ArrayProperty.AddRange(ints);
        }
    }
}