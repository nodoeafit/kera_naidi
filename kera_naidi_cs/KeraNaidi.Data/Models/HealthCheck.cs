namespace KeraNaidi.Data.Models;

public class HealthCheck  : BaseEntity<int>
{
    public DateTime Date {get;set;}
    public string Message {get;set;} = "";
}