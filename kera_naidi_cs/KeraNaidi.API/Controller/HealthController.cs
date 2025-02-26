namespace KeraNaidi.Controllers;

using KeraNaidi.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/[controller]")]
public class HealthController : ControllerBase
{
    private readonly IHealthService _healthService;
    
    public HealthController(IHealthService healthService)
    {
        _healthService = healthService;
    }
    
    
    [HttpGet]
    [Route("HealthCheck")]
    public async Task<IActionResult> HealthCheck()
    {
        var response = await _healthService.HealthCheck();
        return Ok(response);
    }

    [HttpPost]
    [Route("HealthCheck")]
    public async Task<IActionResult> DBHealthCheck()
    {
        var response = await _healthService.DbCheck();
        return Ok(response);
    }
}