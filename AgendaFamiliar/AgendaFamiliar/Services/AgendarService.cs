using AgendaFamiliar.Data;
using AgendaFamiliar.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaFamiliar.Services;

public class AgendarService
{
    private readonly DataContext _context;

    public AgendarService(DataContext context)
    {
        _context = context;
    }

    //obtener todos los datos de Agendar
    public async Task<List<Agendar>> ObtenerAgenda()
    {
        return await _context.Agendar.ToListAsync();
    }

    //obtener un Agendar por id
    public async Task<Agendar?> ObtenerAgendarPorId(Guid id)
    {
        return await _context.Agendar.FirstOrDefaultAsync(u => u.Id == id);
    }

    //crear una Agenda 
    public async Task<Agendar> CrearAgenda(Agendar agendar)
    {
         agendar.Id = Guid.NewGuid();
        _context.Agendar.Add(agendar);
        await _context.SaveChangesAsync();

        return agendar;
    }

    
    //actualizar una Agenda
    public async Task<bool> ActualizarAgendar(Guid id, Agendar agendarActualizado)
    {
        var agendar = await _context.Agendar.FindAsync(id);
        if (agendar == null) return false;

        agendar.Title = agendarActualizado.Title;
        agendar.Description = agendarActualizado.Description;
        agendar.Tipo = agendarActualizado.Tipo;
        agendar.FechaHora = agendarActualizado.FechaHora;
        agendar.Recurrencia = agendarActualizado.Recurrencia;
        

        await _context.SaveChangesAsync();
        return true;
    }

    //eliminar una agenda
    public async Task<bool> EliminarAgendar(Guid id)
    {
        var agendar = await _context.Agendar.FindAsync(id);
        if (agendar == null) return false;

        _context.Agendar.Remove(agendar);
        await _context.SaveChangesAsync();
        return true;
    }

}

