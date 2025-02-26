namespace KeraNaidi.Data.Models;

public class ScratchCode : BaseEntity <int>
{
    public string Codigo {get; set;} = string.Empty;
    public int valor {get; set;} = 0;
    public bool IsReclaimed {get; set;} = false;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
