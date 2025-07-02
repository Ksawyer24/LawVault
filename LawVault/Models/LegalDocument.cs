using LawVault.Enum;

namespace LawVault.Models;

public class LegalDocument
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string FilePath { get; set; }
    public string FileName { get; set; }
    public string FileSize { get; set; }
    public string ContentType { get; set; }
    public DateTime UploadedDate { get; set; } = DateTime.UtcNow;
    public Guid? CourtCaseId { get; set; } 
    public CourtCase CourtCase { get; set; }
    public Guid ClientId { get; set; }
    public Client Client { get; set; }
    public DocumentCategory Category { get; set; }
}