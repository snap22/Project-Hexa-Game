using System;
using System.Runtime.Serialization;

[Serializable]
internal class LockedTileException : Exception
{
    public LockedTileException()
    {
    }

    public LockedTileException(string message) : base(message)
    {
    }

    public LockedTileException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected LockedTileException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}