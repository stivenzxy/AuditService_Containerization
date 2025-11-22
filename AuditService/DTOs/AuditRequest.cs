using System.ComponentModel.DataAnnotations;

namespace AuditService.DTOs;

public class AuditRequest
{
    [Required]
    public DateTime CreatedAt { get; set; }

    [Required, MinLength(1)]
    public string Action { get; set; }

    [Required, MinLength(1)]
    public string User { get; set; }

    [Required, MinLength(1)]
    public string LocationAction { get; set; }
}
