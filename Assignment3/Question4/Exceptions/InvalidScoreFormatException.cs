namespace Assignment3.Question4.Exceptions
{
    public class InvalidScoreFormatException : Exception
    {
        public InvalidScoreFormatException() { }
        public InvalidScoreFormatException(string message) : base(message) { }
        public InvalidScoreFormatException(string message, Exception innerException) : base(message, innerException) { }
    }
}