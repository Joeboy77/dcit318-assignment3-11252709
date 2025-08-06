namespace Assignment3.Question4.Exceptions
{
    public class MissingFieldException : Exception
    {
        public MissingFieldException() { }
        public MissingFieldException(string message) : base(message) { }
        public MissingFieldException(string message, Exception innerException) : base(message, innerException) { }
    }
}