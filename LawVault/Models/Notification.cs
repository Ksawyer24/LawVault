using LawVault.Enum;

namespace LawVault.Models;

public class Notification
{
    public Guid Id { get; set; }
    public string UserId { get; set; }
    public NotificationEventType EventType { get; set; }
    public string Title { get; set; }
    public string Message { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsRead { get; set; }
    public Dictionary<string, object> Metadata { get; set; } = new();
}