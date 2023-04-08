using System;

namespace CleanSample.Application.CustomExceptions
{
    public class UnAuthorizedException : Exception
    {
        public UnAuthorizedException(string message) : base(message) { }
        public int ErrorStatusCode => 401;
    }
}
