namespace KeraNaidi.Data.Models;

public class Producto : BaseEntity<int>
{
    public string Name {get;set;} = String.Empty;
    public string Codigo {get;set;} = String.Empty;
    public  int Precio {get;set;}
    public string Descripcion {get;set;} = String.Empty;
    public int Inventario {get;set;} = 0;
    
}