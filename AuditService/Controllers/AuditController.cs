using AuditService.DTOs;
using AuditService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AuditService.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AuditController : ControllerBase
{
    private readonly IAuditService _auditService;

    public AuditController(IAuditService auditService)
    {
        _auditService = auditService;
    }

    [HttpPost("record")]
    public async Task<IActionResult> RecordAuditAsync([FromBody] AuditRequest audit)
    {
        var result = await _auditService.SaveAuditAsync(audit);
        return Ok($"Audit Recorded with id: {result}");
    }

    [HttpGet("/list")]
    public async Task<IActionResult> ListAllAuditsAsync()
    {
        try
        {
            var result = await _auditService.ListAllAuditsAsync();
            return Ok(result);
        }
        
        catch (Exception)
        {
            return StatusCode(500, new { message = "Error on audit list request." });
        }
    }
}