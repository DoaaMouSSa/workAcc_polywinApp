using PloyWinContext.Entities;
using PloyWinDto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPloyWinRepository.InterFace
{
    public interface IContractClientRepository : IGenericRepository<TblContractClient>
    {
        Response<int> AddNewContract(DtoContractClient contract);
        Response<bool> UpdateContract(int id, bool isRecived);
        Response<int> GetContractNumber();
        Response<List<DtoContractClientForView>> GetAllContractByWorkShop(string UserId);
        Response<List<DtoContractClientForView>> GetAllContractByClient(string UserId);
        ContractInfo GetContractInfoByContractId(int? contractId);
    }
}
