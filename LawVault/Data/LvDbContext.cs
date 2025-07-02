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
        builder.Entity<EmailNotification>(entity =>
        {
            entity.HasKey(n => n.Id);
            entity.Property(n => n.Id).ValueGeneratedOnAdd();
            entity.Property(n => n.RecipientEmail).IsRequired();
            entity.Property(n => n.Subject).IsRequired();
            entity.Property(n => n.Body).IsRequired();
            entity.Property(n => n.Status).HasConversion<string>();
            entity.HasIndex(n => n.RecipientEmail);
            entity.HasIndex(n => n.Status);
            entity.Property(n => n.RetryCount).HasDefaultValue(0);
        });
        
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
            .OnDelete(DeleteBehavior.SetNull); 


        var adminId = Guid.Parse("4e3f5e12-494a-4f07-860b-2c7985debc3e");
        var lawyerId = Guid.Parse("2545020f-9654-4368-b16f-905f0c8ec168");
        
        var roles = new List<IdentityRole<Guid>>
        {
            new IdentityRole<Guid>
            {
                Id = adminId,
                ConcurrencyStamp = adminId.ToString(),
                Name="Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole <Guid>
            {
                Id = lawyerId,
                ConcurrencyStamp = lawyerId.ToString(),
                Name="Lawyer",
                NormalizedName = "LAWYER"
            },
        };
        
        
        
        
        
        
        
        
        base.OnModelCreating(builder);
    }
}