using LawVault.Enum;

namespace LawVault.Models;

public class Reminder
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Guid? CourtCaseId { get; set; }
    public CourtCase CourtCase { get; set; }
    public string Title { get; set; }
    public string Notes { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }
    public ReminderPriority Priority { get; set; }
}