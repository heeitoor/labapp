using System;

namespace Lab.Common.Exceptions
{
    public class SerializationException : Exception
    {
        public SerializationException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
