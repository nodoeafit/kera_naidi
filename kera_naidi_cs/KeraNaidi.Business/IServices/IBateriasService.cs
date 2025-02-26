using KeraNaidi.Data.Models;


namespace KeraNaidi.Interfaces;

public interface IBateriasService
{
    //Task<Baterias> AddBaterias(Baterias baterias)  ;
    Task<IEnumerable<Baterias>> GetAllBaterias();
    Task<Baterias> GetBateriasById(int id);
}