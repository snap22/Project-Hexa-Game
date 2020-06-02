using System;
using System.Runtime.Serialization;

[Serializable]
internal class LevelUpException : Exception
{
    public LevelUpException()
    {
    }

    public LevelUpException(string message) : base(message)
    {
    }

    public LevelUpException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected LevelUpException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}