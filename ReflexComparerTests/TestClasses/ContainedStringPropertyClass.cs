namespace ReflexComparerTests.TestClasses
{
    public class ContainedStringPropertyClass
    {
        public string StringProperty { get; }

        public StringPropertyClass StringPropertyClass { get; }

        public ContainedStringPropertyClass(
            string stringProperty, StringPropertyClass stringPropertyClass)
        {
            StringProperty = stringProperty;
            StringPropertyClass = stringPropertyClass;
        }
    }
}