namespace Assignment3.Question3.Exceptions
{
    public class DuplicateItemException : Exception
    {
        public DuplicateItemException() { }
        public DuplicateItemException(string message) : base(message) { }
        public DuplicateItemException(string message, Exception innerException) : base(message, innerException) { }
    }
}
