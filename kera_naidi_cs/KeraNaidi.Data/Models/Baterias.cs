namespace KeraNaidi.Data.Models;

public class Baterias: BaseEntity<int>
{
    public string Codigo {get;set;} = String.Empty;
    public  int Precio{get;set;} = 0;
    public int PorcentajeDeEnergia {get;set;} = 100;
    public bool IsInUse{get;set;} = false;
    
}