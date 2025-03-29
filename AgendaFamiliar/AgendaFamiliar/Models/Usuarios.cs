using System.ComponentModel.DataAnnotations;

namespace AgendaFamiliar.Models
{
    public class Usuarios
    {
        [Key]
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }

    }
}
