using AgendaFamiliar.Models;
using AgendaFamiliar.Services;
using Microsoft.AspNetCore.Mvc;



namespace TestWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]

public class UsuariosController : ControllerBase
{
    private readonly UsuarioService _usuarioService;

    public UsuariosController(UsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Usuarios>>> ObtenerUsuarios()
    {
        var usuarios = await _usuarioService.ObtenerUsuarios();
        return Ok(usuarios);
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<Usuarios>> ObtenerUsuarioPorId(Guid Id)
    {
        var usuario = await _usuarioService.ObtenerUsuarioPorId(Id);
        if (usuario == null) return NotFound("Usuario no encontrado");

        return Ok(usuario);
    }

    [HttpPost]
    public async Task<ActionResult> CrearUsuario([FromBody] Usuarios usuario)
    {
        if (usuario == null)
        {
            Console.WriteLine("Datos vacíos recibidos en CrearUsuario");
            return BadRequest("Datos de usuario vienen vacios");
        }
        Console.WriteLine($"Datos recibidos: Nombre={usuario.Nombre}, Email={usuario.Email}");
        var nuevoUsuario = await _usuarioService.CrearUsuario(usuario);
        return Ok(nuevoUsuario);
    }

    [HttpPut("{Id}")]
    public async Task<ActionResult> ActualizarUsuario(Guid Id, [FromBody] Usuarios usuarioActualizado)
    {
        if (usuarioActualizado == null)
        {
            return BadRequest("Datos de usuario vienen vacios");
        }

        var response = await _usuarioService.ActualizarUsuario(Id, usuarioActualizado);

        if (response == false)
        {
            return NotFound("Usuario no encontrado en base de datos");
        }

        return NoContent();
    }

    [HttpDelete("{Id}")]
    public async Task<ActionResult> EliminarUsuario(Guid Id)
    {
        var response = await _usuarioService.EliminarUsuario(Id);
        if (response == false)
        {
            return NotFound("Usuario no encontrado en base de datos");
        }
        return NoContent();
    }

}