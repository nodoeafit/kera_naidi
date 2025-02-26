namespace KeraNaidi.Controllers;


using KeraNaidi.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/[controller]")]
public class BateriasController : ControllerBase
{
   private readonly IBateriasService _baterias;

    public BateriasController(IBateriasService bateriasService)
    { 
        _baterias = bateriasService;
        }


    [HttpGet]
    [Route("GetAllBaterias")]
    public async Task<IActionResult> GetAllBaterias()
    {
        var result = await _baterias.GetAllBaterias();
        return Ok(result);
    }
}