using Microsoft.AspNetCore.Identity;

namespace LawVault.Models;

public class User:IdentityUser<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string BarNumber { get; set; }
    public ICollection<Client> Clients { get; set; }
    public ICollection<Reminder> Reminders { get; set; }

    public ICollection<LegalDocument> Documents { get; set; }
    public ICollection<CourtCase> CourtCases { get; set; }
}