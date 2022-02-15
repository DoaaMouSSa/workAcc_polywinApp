using PloyWinContext.Entities;
using PloyWinDto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPloyWinRepository.InterFace
{
    public interface IBankRepository : IGenericRepository<TblBank>
    {
        Task<Response<DtoBank>> AddEditBank(DtoBank dtoBank);
        Task<Response<bool>> DeleteBank(string Ids);
        Task<Response<List<DtoBank>>> getBank();
    }
}
