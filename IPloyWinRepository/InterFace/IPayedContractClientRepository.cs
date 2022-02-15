using PloyWinContext.Entities;
using PloyWinDto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPloyWinRepository.InterFace
{
    public interface IPayedContractClientRepository : IGenericRepository<TblPayedContractClient>
    {
        Response<bool> UpdateBulkInvoice(int id);
        Response<List<DtoPayedAfterCreate>> AddPayedOfContract(DtoPayedClient dtoPayedClient);
        Response<List<DtoPayedBeforeCreate>> GetAllPayedByClientId(string UserId, int ContractId);
    }
}
