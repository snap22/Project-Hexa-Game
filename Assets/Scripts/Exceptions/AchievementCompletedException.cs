using System;
using System.Runtime.Serialization;

[Serializable]
internal class AchievementCompletedException : Exception
{
    public AchievementCompletedException()
    {
    }

    public AchievementCompletedException(string message) : base(message)
    {
    }

    public AchievementCompletedException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected AchievementCompletedException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}