using KeraNaidi.Data;
using KeraNaidi.Data.Models;
using KeraNaidi.Interfaces;
namespace KeraNaidi.Services;

public class CodigosService : ICodigosService
{
    private readonly IUnitOfWork _unitofWork;
    
    public CodigosService(IUnitOfWork unitofWork)
    {
        _unitofWork = unitofWork;        
    }
    
    public async Task<ScratchCode> AddAsync(ScratchCode scratchCode)
    {
        await _unitofWork.ScratchCodeRepository.AddAsync(scratchCode);
        return scratchCode;
    }

    public async Task<IEnumerable<ScratchCode>> GetAllAsync()
    {
        var listaCodigos = await _unitofWork.ScratchCodeRepository.GetAllAsync();

        await _unitofWork.ScratchCodeRepository.AddAsync(new ScratchCode(){
        Codigo = "SSD862",
        valor = 15
        });
    await _unitofWork.SaveAsync();

    await _unitofWork.ScratchCodeRepository.AddAsync(new ScratchCode(){
        Codigo = "IKA604",
        valor = 25
        });
    await _unitofWork.SaveAsync();

    await _unitofWork.ScratchCodeRepository.AddAsync(new ScratchCode(){
        Codigo = "YCU818",
        valor = 20
        });
    await _unitofWork.SaveAsync();

    await _unitofWork.ScratchCodeRepository.AddAsync(new ScratchCode(){
        Codigo = "TYU336",
        valor = 30
        });
    await _unitofWork.SaveAsync();

    await _unitofWork.ScratchCodeRepository.AddAsync(new ScratchCode(){
        Codigo = "LQD165",
        valor = 5
        });
    await _unitofWork.SaveAsync();

        return listaCodigos;
    }
    
}