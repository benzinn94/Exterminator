using System;

namespace Exterminator.Models.Exceptions
{
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException() : base("The requested resource was not found.") {}
        public ResourceNotFoundException(string msg) : base(msg) {}
        public ResourceNotFoundException(string msg, Exception exception) : base(msg, exception) {}

    }
}