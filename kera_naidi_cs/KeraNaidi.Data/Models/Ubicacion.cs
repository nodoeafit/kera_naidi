using KeraNaidi.Data.Models;

namespace KeraNaidi.Data.Entities
{
    public class Ubicacion : BaseEntity<int>
    {
        public string Nombre { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
    }
}
