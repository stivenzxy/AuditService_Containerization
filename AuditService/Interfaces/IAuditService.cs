using AuditService.DTOs;
using AuditService.Persistence.Entities;

namespace AuditService.Interfaces;

public interface IAuditService
{
    Task<Guid> SaveAuditAsync(AuditRequest audit);
    Task<IEnumerable<AuditResponse>> ListAllAuditsAsync();
}