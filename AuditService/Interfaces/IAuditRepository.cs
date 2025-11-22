using AuditService.Persistence.Entities;

namespace AuditService.Interfaces;

public interface IAuditRepository
{
    Task<Guid> RecordAuditAsync(Audit audit);
    Task<IEnumerable<Audit>> GetAllAuditsAsync();
}