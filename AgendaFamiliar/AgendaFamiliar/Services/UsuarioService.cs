using AgendaFamiliar.Data;
using AgendaFamiliar.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaFamiliar.Services;

public class UsuarioService
{
    private readonly DataContext _context;

    public UsuarioService(DataContext context)
    {
        _context = context;
    }

    //obtener todos los usuarios
    public async Task<List<Usuarios>> ObtenerUsuarios()
    {
        return await _context.Usuarios.ToListAsync();
    }

    //obtener un usuario por id
    public async Task<Usuarios?> ObtenerUsuarioPorId(Guid id)
    {
        return await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
    }

    //crear un usuario 
    public async Task<Usuarios> CrearUsuario(Usuarios usuario)
    {
        usuario.Id = Guid.NewGuid();

        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();

        return usuario;
    }

    //actualizar un usuario
    public async Task<bool> ActualizarUsuario(Guid id, Usuarios usuarioActualizado)
    {
        var usuario = await _context.Usuarios.FindAsync(id);
        if (usuario == null) return false;

        usuario.Nombre = usuarioActualizado.Nombre;
        usuario.Email = usuarioActualizado.Email;
        usuario.Clave = usuarioActualizado.Clave;

        await _context.SaveChangesAsync();
        return true;
    }

    //eliminar un usuario
    public async Task<bool> EliminarUsuario(Guid id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);
        if (usuario == null) return false;

        _context.Usuarios.Remove(usuario);
        await _context.SaveChangesAsync();
        return true;
    }
}