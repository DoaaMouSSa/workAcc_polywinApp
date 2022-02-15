using PloyWinContext.Entities;
using PloyWinDto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPloyWinRepository.InterFace
{
    public interface ICategoryTypeRepository : IGenericRepository<TblCategoryType>
    {
        Response<List<DtoCategoryType>> GetAllCategoryType();
        Response<bool> AddEditCategoryType(DtoCategoryType dto);
        Response<bool> DeleteCategoryType(string id);
        Response<List<DtoCategoryTypeWithChild>> GetAllCategoryGallery();
        Response<List<DtoCategoryGalleryViewModal>> GetAllCategoryGalleryById(int id);
    }
}
