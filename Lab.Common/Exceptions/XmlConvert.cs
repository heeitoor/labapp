using System;

namespace Lab.Common.Exceptions
{
    public class XmlConvertException : Exception
    {
        public XmlConvertException(Exception innerException, string message = "Erro convertendo objeto para xml.")
            : base(message, innerException) { }
    }
}
