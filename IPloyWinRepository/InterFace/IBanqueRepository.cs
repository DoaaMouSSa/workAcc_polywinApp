using PloyWinContext.Entities;
using PloyWinDto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPloyWinRepository.InterFace
{
    public interface IBanqueRepository : IGenericRepository<TbltreasuryBank>
    {
        Task<Response<DtoBanque>> AddEditBanque(DtoBanque dtoBanque);
        Task<Response<bool>> DeleteBanque(string Ids);
        Task<Response<List<DtoBankForDepositForShow>>> getBanque();
        Task<Response<List<DtoBanqueForDropDown>>> getBanqueForDropDown();
        Task<Response<bool>> EditBalance(int id, int newBalance);
        Task<Response<DtoBankForDepositForAdd>> AddDeposit(DtoBankForDepositForAdd dtoBanque);
        Task<Response<DtoBankForDepositForAdd>> DecreaseDeposit(DtoBankForDepositForAdd dtoBanque);
        
    }
}
