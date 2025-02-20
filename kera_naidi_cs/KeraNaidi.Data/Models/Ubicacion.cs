namespace KeraNaidi.Data.Models;

public class Ubicacion : BaseEntity<int>
{
    public required string Nombre { get; set; } = string.Empty;
    public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
    public DateTime HorarioApertura { get; set; }
    public DateTime HorarioCierre { get; set; }
    public double Latitud { get; set; }
    public double Longitud { get; set; }
}