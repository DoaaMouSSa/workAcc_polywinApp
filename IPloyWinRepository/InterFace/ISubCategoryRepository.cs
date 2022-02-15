using PloyWinContext.Entities;
using PloyWinDto.Dto;
using System.Collections.Generic;

namespace IPloyWinRepository.InterFace
{
    public interface ISubCategoryRepository : IGenericRepository<TblSubCategory>
    {
        Response<List<DtoSubCategory>> GetAllSubCategory();
        Response<List<DtoParentCategoryForDropDown>> GetAllSubCategoryForDropDown();
        Response<DtoSubCategory> AddEditSubCategory(DtoSubCategory dto);
        Response<bool> DeleteSubCategory(string Ids);
        Response<List<DtoSubCategory>> GetSubCatByParentCat(int id);
    
    }
}
