using System;

namespace Lab.App.Exceptions
{
    public class SerializationException : Exception
    {
        public SerializationException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
