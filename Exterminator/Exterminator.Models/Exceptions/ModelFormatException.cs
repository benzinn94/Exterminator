using System;

namespace Exterminator.Models.Exceptions
{
    public class ModelFormatException : Exception
    {
        public ModelFormatException() : base("Invalid formatting of model.") {}
        public ModelFormatException(string msg) : base(msg) {}
        public ModelFormatException(string msg, Exception exception) : base(msg, exception) {}

    }
}