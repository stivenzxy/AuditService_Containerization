namespace AuditService.DTOs;

public class AuditResponse
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Action { get; set; } = string.Empty;
    public string User { get; set; } = string.Empty;
    public string LocationAction { get; set; } = string.Empty;
}