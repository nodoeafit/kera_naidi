using KeraNaidi.Data.Models;

namespace KeraNaidi.Data.Entities
{
    public class Pregunta : BaseEntity<int>
    {
        public string Texto { get; set; }
        public string RespuestaCorrecta { get; set; }
        public string RespuestasIncorrectas { get; set; } // Guardadas como JSON string
        public int Puntos { get; set; }

        public int RetoId { get; set; }
        public Reto Reto { get; set; }

        public int UbicacionId { get; set; }
        public Ubicacion Ubicacion { get; set; }
    }
}
