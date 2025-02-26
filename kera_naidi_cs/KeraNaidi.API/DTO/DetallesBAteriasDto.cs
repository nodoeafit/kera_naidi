namespace DetallesBAterias.Dto
{
    public class DetallesBAteriasDTO
    {
        public int BateriasID {get;set;}
        public string Codigo {get;set;} = String.Empty;
        public int PorcentajeDeEnergia {get;set;} = 100;
        public int UserID {get; set;}
    }
}