namespace ReflexComparerTests.TestClasses
{
    public class PrimitivePropertiesClass
    {
        public int IntProperty { get; }

        public double DoubleProperty { get; }

        public string StringProperty { get; }

        public char CharProperty { get; }

        public bool BoolProperty { get; }

        public PrimitivePropertiesClass(int intProperty, double doubleProperty, string stringProperty, char charProperty, bool boolProperty)
        {
            IntProperty = intProperty;
            DoubleProperty = doubleProperty;
            StringProperty = stringProperty;
            CharProperty = charProperty;
            BoolProperty = boolProperty;
        }
    }
}