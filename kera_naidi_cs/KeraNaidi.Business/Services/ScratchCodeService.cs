namespace KeraNaidi.Services;
using KeraNaidi.Data;
using KeraNaidi.Data.Models;



public class ScratchCodeService : IScratchCodeService
{

   private readonly IUnitOfWork _unitOfWork;

        public ScratchCodeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

   public async Task<ScratchCode> AddCode(ScratchCode scratchcode)
        {
            await _unitOfWork.ScratchCodeRepository.AddAsync(scratchcode);
            await _unitOfWork.SaveAsync();
            return scratchcode;
        }

    public async Task<ScratchCode> GetScratchCodeByCode(string codigo)
    {
        return await _unitOfWork.ScratchCodeRepository.GetScratchCodeByCode(codigo);
    }

    public async Task<ScratchCode> GetScratchCodeById(int id)
   {
        var scratchcode = await _unitOfWork.ScratchCodeRepository.GetScratchCodeById(id);
        return scratchcode; 
   }

    public async Task<ScratchCode> UpdateScratchCode(ScratchCode scratchcode)
    {
        _unitOfWork.ScratchCodeRepository.Update(scratchcode);
        await _unitOfWork.SaveAsync(); // Guarda los cambios
        return scratchcode;
    }

}


 