using PloyWinContext.Entities;
using PloyWinDto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPloyWinRepository.InterFace
{
   public interface IItemTypeRepository:IGenericRepository<TblItemType>
    {
        Task<Response<DtoItemType>> AddEditItemType(DtoItemType dtoItemType);
        Task<Response<bool>> DeleteItemType(string Ids);
        Task<Response<List<DtoItemType>>> getItemType();
    }
}
