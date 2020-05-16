namespace ReflexComparer.Primitives.Hash
{
    public interface IHashCodeCalculator<T>
    {
        int GetHashCode(T obj);
    }
}