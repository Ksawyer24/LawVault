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
        
        builder.Entity<LegalDocument>()
            .HasOne(d => d.User)
            .WithMany(u => u.Documents)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Entity<Client>()
            .HasOne(d => d.User)
            .WithMany(u => u.Clients)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        
        builder.Entity<CourtCase>()
            .HasOne(d => d.User)
            .WithMany(u => u.CourtCases)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Entity<Reminder>()
            .HasOne(r => r.User)
            .WithMany(u => u.Reminders)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        
        builder.Entity<Reminder>()
            .HasOne(r => r.CourtCase)
            .WithMany(c => c.Reminders)
            .HasForeignKey(r => r.CourtCaseId)
            .OnDelete(DeleteBehavior.Cascade); 


        
        
        
        
        
        
        
        
        
        base.OnModelCreating(builder);
    }
}