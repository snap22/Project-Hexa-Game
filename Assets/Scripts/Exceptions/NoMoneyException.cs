using System;
using System.Runtime.Serialization;

[Serializable]
internal class NoMoneyException : Exception
{
    public NoMoneyException()
    {
    }

    public NoMoneyException(string message) : base(message)
    {
    }

    public NoMoneyException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected NoMoneyException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}