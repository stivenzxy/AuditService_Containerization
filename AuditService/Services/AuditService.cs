using AuditService.DTOs;
using AuditService.Interfaces;
using AuditService.Persistence.Entities;

namespace AuditService.Services;

public class AuditService(IAuditRepository _auditRepository) : IAuditService
{
    public async Task<Guid> SaveAuditAsync(AuditRequest audit)
    {
        var auditEntity = new Audit
        {
            CreatedAt = audit.CreatedAt,
            Action = audit.Action,
            User = audit.User,
            LocationAction = audit.LocationAction,
        };
        
        var insertionResult = await _auditRepository.RecordAuditAsync(auditEntity);
        return insertionResult; 
    }

    public async Task<IEnumerable<AuditResponse>> ListAllAuditsAsync()
    {
        var allLogins = await _auditRepository.GetAllAuditsAsync();
        
        var responseDtos = allLogins.Select(entity => new AuditResponse
        {
            Id = entity.Id,
            CreatedAt = entity.CreatedAt,
            Action = entity.Action,
            User = entity.User,
            LocationAction = entity.LocationAction,
        });
        
        return responseDtos;
    }
}