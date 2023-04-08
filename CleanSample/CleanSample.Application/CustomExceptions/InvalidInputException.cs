using System;

namespace CleanSample.Application.CustomExceptions
{
    public class InvalidInputException : Exception
    {
        public InvalidInputException(string message) : base(message) { }
        public int ErrorStatusCode => 400;
    }
}
