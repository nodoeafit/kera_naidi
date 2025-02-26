using KeraNaidi.Data.Models;
namespace KeraNaidi.Interfaces;

public interface ICodigosService
{
    Task<ScratchCode> AddAsync(ScratchCode scratchCode);
    Task<IEnumerable<ScratchCode>> GetAllAsync();
}