using PloyWinContext.Entities;
using PloyWinDto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPloyWinRepository.InterFace
{
    public interface ICategoryRepository : IGenericRepository<TblCategory>
    {
        Response<List<DTOCategoryNamed>> GetCategoryType();
        Response<List<DTOCategory>> GetAllCategory();
        Response<List<DTOCategory>> GetAllCategoryForDrop();
        Task<Response<List<DTOCategory>>> GetAllCategoryWithProduct();
        Response<DTOCategoryAddEdit> AddEditCategory(DTOCategoryAddEdit dTOCategoryAddEdit);
        Response<bool> DeleteCategory(string id);
        Response<List<DtoGroupCategoryWithProduct>> GetParenrCategorywithProduct(ApplicationUser user);
        Response<List<DtoGroupCategoryWithProduct>> GetParentCategorywithProductForWebApp();

    }
}
