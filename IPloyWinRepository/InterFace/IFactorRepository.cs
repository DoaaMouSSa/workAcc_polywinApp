using PloyWinContext.Entities;
using PloyWinDto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPloyWinRepository.InterFace
{
   public interface IFactorRepository:IGenericRepository<TblFactor>
    {
        Response<List<DtoFactor>> GetAllFactor();
        Response<bool> DeleteFactor(string Ids);
        Response<DtoFactor> AddEditFactor(DtoFactor dto);
    }
}
