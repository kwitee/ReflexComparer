namespace ReflexComparer.Primitives.Hash
{
    /// <remarks>
    /// This class takes advantage of hash collisions. If the hashes of two objects are equal, 
    /// the calling code can't assume the objects are equal as well and the method Equals must be called.
    /// When the objects are the same, returning const value will be faster than using reflection 
    /// to callculate hash AND equality. When they are not the same, the reflection is used only once.
    /// </remarks>
    public class ConstHashCodeCalculator<T> : IHashCodeCalculator<T>
    {
        public int GetHashCode(T obj)
        {
            return default;
        }
    }
}