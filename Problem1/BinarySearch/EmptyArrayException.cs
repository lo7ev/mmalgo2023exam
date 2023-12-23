namespace binsearch
{
    [Serializable]
    public class EmptyArrayException : Exception
    {
        public EmptyArrayException() : base("Array without elements for search") { }
    }
}