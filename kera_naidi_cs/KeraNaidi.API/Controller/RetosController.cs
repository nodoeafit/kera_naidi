using KeraNaidi.Data.Dtos;
using KeraNaidi.Data;
using KeraNaidi.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class RetoController : ControllerBase
{
    private readonly KeraNaidiContext _context;

    public RetoController(KeraNaidiContext context)
    {
        _context = context;
    }

    // Aquí van tus métodos antiguos como Get, Post, etc...

    [HttpPost("evaluar")]
    [AllowAnonymous]
    public async Task<IActionResult> EvaluarRespuestas([FromBody] List<RespuestaUsuarioDto> respuestas)
    {
        int puntosTotales = 0;
        int preguntasCorrectas = 0;
        int preguntasIncorrectas = 0;

        foreach (var respuestaUsuario in respuestas)
        {
            var pregunta = await _context.Preguntas.FindAsync(respuestaUsuario.PreguntaId);
            if (pregunta != null)
            {
                if (respuestaUsuario.RespuestaSeleccionada == pregunta.RespuestaCorrecta)
                {
                    puntosTotales += pregunta.Puntos;
                    preguntasCorrectas++;
                }
                else
                {
                    preguntasIncorrectas++;
                }
            }
        }

        var resultado = new EvaluacionResultadoDto
        {
            PuntosObtenidos = puntosTotales,
            TotalPreguntas = respuestas.Count,
            PreguntasCorrectas = preguntasCorrectas,
            PreguntasIncorrectas = preguntasIncorrectas
        };

        return Ok(resultado);
    }
}
