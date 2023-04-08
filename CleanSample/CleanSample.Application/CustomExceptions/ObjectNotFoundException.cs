using System;
namespace CleanSample.Application.CustomExceptions
{
    public class ObjectNotFoundException : Exception
    {
        public ObjectNotFoundException(string message) : base(message) { }
        public int ErrorStatusCode => 404;
    }
}
