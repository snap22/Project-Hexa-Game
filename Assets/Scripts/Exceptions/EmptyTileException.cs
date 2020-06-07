using System;
using System.Runtime.Serialization;

[Serializable]
internal class EmptyTileException : Exception
{
    public EmptyTileException()
    {
    }

    public EmptyTileException(string message) : base(message)
    {
    }

    public EmptyTileException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected EmptyTileException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}