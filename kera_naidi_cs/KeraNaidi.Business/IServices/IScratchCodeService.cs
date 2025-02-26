using KeraNaidi.Data.Models;


public interface IScratchCodeService 
{

    Task<ScratchCode> AddCode (ScratchCode scratchcode);
    Task<ScratchCode> GetScratchCodeByCode(string codigo);
    Task<ScratchCode> GetScratchCodeById(int id);
    Task<ScratchCode> UpdateScratchCode(ScratchCode scratchcode);
}