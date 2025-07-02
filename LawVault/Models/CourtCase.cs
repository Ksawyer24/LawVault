namespace LawVault.Models;

public class CourtCase
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; } 
    public string CaseNumber { get; set; }
    public string CaseName { get; set; }
    public string Jurisdiction { get; set; }
    public string Judge { get; set; }
    public string OpposingCounsel { get; set; }
    public string Status { get; set; }
    public DateTime? FiledDate { get; set; }
    public ICollection<LegalDocument> Documents { get; set; }
    public ICollection<Reminder> Reminders { get; set; }
    public ICollection<Client> Clients { get; set; }
}