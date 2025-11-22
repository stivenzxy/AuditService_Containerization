using AuditService.Interfaces;
using AuditService.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuditService.Persistence.Repositories;

public class AuditRepository (AppDbContext _dbContext) : IAuditRepository
{
    public async Task<Guid> RecordAuditAsync(Audit audit)
    {
        await _dbContext.Audits.AddAsync(audit);
        await _dbContext.SaveChangesAsync();
        
        return audit.Id;
    }

    public async Task<IEnumerable<Audit>> GetAllAuditsAsync()
    {
        return await _dbContext.Audits.ToListAsync();
    }
}