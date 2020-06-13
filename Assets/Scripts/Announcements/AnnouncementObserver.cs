using System;

public class AnnouncementObserver
{
    public static event Action<IAnnouncable> OnAnnouncement;
}
