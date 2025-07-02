using LawVault.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LawVault.Data;

public class LvDbContext: IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public LvDbContext(DbContextOptions<LvDbContext> options) : base(options) { }
    
    
    
    public DbSet<Client> Clients { get; set; }
    public DbSet<CourtCase> CourtCases { get; set; }
    public DbSet<LegalDocument> LegalDocuments { get; set; }
    public DbSet<Reminder> Reminders { get; set; }
    
    public DbSet<EmailNotification> EmailNotifications { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        
        
        
        
        
        
        
        
        
        
        
        
        base.OnModelCreating(builder);
    }
}