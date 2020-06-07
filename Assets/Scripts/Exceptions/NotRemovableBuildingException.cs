using System;
using System.Runtime.Serialization;

[Serializable]
internal class NotRemovableBuildingException : Exception
{
    public NotRemovableBuildingException()
    {
    }

    public NotRemovableBuildingException(string message) : base(message)
    {
    }

    public NotRemovableBuildingException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected NotRemovableBuildingException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}