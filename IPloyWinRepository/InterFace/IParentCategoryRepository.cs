using PloyWinContext.Entities;
using PloyWinDto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPloyWinRepository.InterFace
{
    public interface IParentCategoryRepository:IGenericRepository<TblParentCategory>
    {
        Response<List<DtoParentCategory>> GetAllParentCategory();
        Response<List<DtoParentCategoryForDropDown>> GetAllParentCategoryForDropDown();
        Response<DtoParentCategory> AddEditParentCategory(DtoParentCategory dto);
        Response<bool> DeleteParentCategory(string Ids);
        Response<List<DtoParentSubCategory>> GetAllParentSubCategory();
    }
}
