using System.ComponentModel.DataAnnotations;
using LawVault.Enum;

namespace LawVault.Models;

public class EmailNotification
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string RecipientEmail { get; set; } 
    public string? Subject { get; set; }
    public string? Body { get; set; }

    public EmailStatus Status { get; set; } = EmailStatus.Unsent;

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? LastAttemptDate { get; set; }
    public int RetryCount { get; set; } = 0;
    public string? LastError { get; set; }
}