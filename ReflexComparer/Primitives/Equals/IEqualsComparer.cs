namespace ReflexComparer.Primitives.Equals
{
    public interface IEqualsComparer<T>
    {
        bool Equals(T first, T second);
    }
}