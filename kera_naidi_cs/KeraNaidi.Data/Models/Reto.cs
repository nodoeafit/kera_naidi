using KeraNaidi.Data.Models;

namespace KeraNaidi.Data.Entities
{
    public class Reto : BaseEntity<int>
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public int EventoId { get; set; }
        public Evento Evento { get; set; }

        public int UbicacionId { get; set; }
        public Ubicacion Ubicacion { get; set; }

        public ICollection<Pregunta> Preguntas { get; set; } = new List<Pregunta>();
    }
}
