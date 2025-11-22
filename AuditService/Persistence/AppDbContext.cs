using AuditService.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuditService.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base (options) {}
    public DbSet<Audit> Audits { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("audit");

        modelBuilder.Entity<Audit>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasColumnType("uuid")
                .IsRequired();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("NOW()");
        });

        base.OnModelCreating(modelBuilder);
    }

    
    public async Task EnsureSchemaExistsAsync()
    {
        await Database.ExecuteSqlRawAsync("CREATE SCHEMA IF NOT EXISTS audit");
    }
}