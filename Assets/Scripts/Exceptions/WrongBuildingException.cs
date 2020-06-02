using System;
using System.Runtime.Serialization;

[Serializable]
internal class WrongBuildingException : Exception
{
    public WrongBuildingException()
    {
    }

    public WrongBuildingException(string message) : base(message)
    {
    }

    public WrongBuildingException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected WrongBuildingException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}