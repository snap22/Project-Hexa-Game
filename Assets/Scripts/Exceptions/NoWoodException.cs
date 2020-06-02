using System;
using System.Runtime.Serialization;

[Serializable]
internal class NoWoodException : Exception
{
    public NoWoodException()
    {
    }

    public NoWoodException(string message) : base(message)
    {
    }

    public NoWoodException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected NoWoodException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}