using System;
using System.Runtime.Serialization;

[Serializable]
internal class OccupiedTileException : Exception
{
    public OccupiedTileException()
    {
    }

    public OccupiedTileException(string message) : base(message)
    {
    }

    public OccupiedTileException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected OccupiedTileException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}