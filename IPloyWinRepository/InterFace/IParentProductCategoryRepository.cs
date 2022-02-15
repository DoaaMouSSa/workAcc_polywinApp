using PloyWinContext.Entities;
using PloyWinDto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPloyWinRepository.InterFace
{
    public interface IParentProductCategoryRepository : IGenericRepository<TblParentProductCategory>
    {
        Response<bool> DeleteParentProductCategory(string Ids);
        Response<DtoParentProductCategory> AddEditParentProductCategory(DtoParentProductCategory dto);
        Response<List<DtoParentProductCategory>> GetAllParentProductCategory();
    }
}
