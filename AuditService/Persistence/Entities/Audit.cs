namespace AuditService.Persistence.Entities;

public class Audit
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; set; }
    public string Action { get; set; } = string.Empty;
    public string User { get; set; } = string.Empty;
    public string LocationAction { get; set; } = string.Empty;
}
