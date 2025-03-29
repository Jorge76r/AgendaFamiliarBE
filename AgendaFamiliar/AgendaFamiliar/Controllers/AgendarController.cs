using AgendaFamiliar.Models;
using AgendaFamiliar.Services;
using Microsoft.AspNetCore.Mvc;


namespace TestWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]

public class AgendarController : ControllerBase
{
    private readonly AgendarService _agendarService;
    private object _agendaService;

    public AgendarController(AgendarService agendarService)
    {
        _agendarService = agendarService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Agendar>>> ObtenerAgendar()
        {
    var agendar = await _agendarService.ObtenerAgenda(); ;
        return Ok(agendar);
        }
    
    [HttpGet("{Id}")]
    public async Task<ActionResult<Agendar>> ObtenerAgendarPorId(Guid Id)
    {
        var agendar = await _agendarService.ObtenerAgendarPorId(Id);
        if (agendar == null) return NotFound("Agenda no encontrada");

        return Ok(agendar);
    }

    [HttpPost]
    public async Task<ActionResult> CrearAgenda([FromBody] Agendar agendar)
    {
        if (agendar == null)
        {
            return BadRequest("Datos de agenda vienen vacios");
        }
        var nuevoAgenda = await _agendarService.CrearAgenda(agendar);
        return Ok(nuevoAgenda);
    }

    [HttpPut("{Id}")]
    public async Task<ActionResult> ActualizarAgenda(Guid Id, [FromBody] Agendar AgendaActualizada)
    {
        if (AgendaActualizada == null)
        {
            return BadRequest("Datos de agenda vienen vacios");
        }

        var response = await _agendarService.ActualizarAgendar(Id, AgendaActualizada);

        if (response == false)
        {
            return NotFound("Agenda no encontrada en base de datos");
        }

        return NoContent();
    }

    [HttpDelete("{Id}")]
    public async Task<ActionResult> EliminarAgendar(Guid Id)
    {
        var response = await _agendarService.EliminarAgendar(Id);
        if (response == false)
        {
            return NotFound("Agenda no encontrada en base de datos");
        }
        return NoContent();
    }

}
