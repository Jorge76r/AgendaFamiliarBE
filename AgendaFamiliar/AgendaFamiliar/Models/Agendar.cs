using System.ComponentModel.DataAnnotations;

namespace AgendaFamiliar.Models
{
    public class Agendar
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Tipo { get; set; }
        public DateTime FechaHora { get; set; }
        public string Recurrencia { get; set; }
     }
}
