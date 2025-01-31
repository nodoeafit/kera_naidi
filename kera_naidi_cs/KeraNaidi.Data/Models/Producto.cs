namespace KeraNaidi.Data.Models;

public class Product : BaseEntity<int>
{
    public string Name {get;set;} = String.Empty;
    public string Code {get;set;} = String.Empty;
    public  int Price {get;set;} = 0;
    public string Description {get;set;} = String.Empty;
    public int Quantity {get;set;} = 0;
    
}