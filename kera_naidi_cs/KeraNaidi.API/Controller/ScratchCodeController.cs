using KeraNaidi.Data.Models;
using Microsoft.AspNetCore.Mvc;
namespace KeraNaidi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ScratchCodeController : ControllerBase
{
    private readonly IScratchCodeService _scratchcodeService;

    public ScratchCodeController(IScratchCodeService scratchcodeService)
    {
        _scratchcodeService = scratchcodeService;

    }

    [HttpPost]
    [Route("AddCode")]
    public async Task<IActionResult> AddCode(ScratchCode scratchcode)
    {
        if (scratchcode == null)
        {
            return BadRequest("El código no puede ser nulo");
        }
        var result = await _scratchcodeService.AddCode(scratchcode);
        return CreatedAtAction(nameof(AddCode), new { id = result.Id }, result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetScratchCodeById(int id)
    {
        var result = await _scratchcodeService.GetScratchCodeById(id);

        if (result == null)
        {
            return NotFound("$No se encontró un código con ID {id}");
        }
        return Ok(result);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateScratchCode(ScratchCode scratchcode)
    {
        if (scratchcode == null)
        {
            return BadRequest("El código no puede ser nulo");
        }
        var updatedScratchCode = await _scratchcodeService.UpdateScratchCode(scratchcode);
        return Ok(updatedScratchCode);
    }

    /*vamo a ve' si sirve*/
    [HttpGet("verify/{codigo}")]
    public async Task<IActionResult> VerifyScratchCode(string codigo) 
    {
    var result = await _scratchcodeService.GetScratchCodeByCode(codigo);
    
    if (result == null)
    {
        return NotFound($"No se encontró un código con el valor {codigo}");
    }
    
    if (result.IsReclaimed)
    {
        return BadRequest("El código ya ha sido reclamado.");
    }

    return Ok(new 
    {
        Codigo = result.Codigo,
        Valor = result.valor,
        Mensaje = "Código válido"
    });
    }


}

