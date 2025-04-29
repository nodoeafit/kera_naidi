using KeraNaidi.Data.Models;

namespace KeraNaidi.Data.Entities
{
    public class Evento : BaseEntity<int>
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public ICollection<Reto> Retos { get; set; } = new List<Reto>();
    }
}

