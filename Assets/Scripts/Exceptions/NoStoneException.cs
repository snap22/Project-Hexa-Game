using System;
using System.Runtime.Serialization;

[Serializable]
internal class NoStoneException : Exception
{
    public NoStoneException()
    {
    }

    public NoStoneException(string message) : base(message)
    {
    }

    public NoStoneException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected NoStoneException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}