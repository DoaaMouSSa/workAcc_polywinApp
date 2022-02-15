using PloyWinContext.Entities;
using PloyWinDto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPloyWinRepository.InterFace
{
   public interface ICategoryGalleryRepository : IGenericRepository<TblCategoryGallary>
    {
        Response<bool> DeleteCategoryName(string id);
        Response<DtoCategoryGallery> AddEditCategoryName(DtoCategoryGallery dtoCategoryGallery);
        Response<List<DtoCategoryGallery>> GetAllCategoryGallery();
        Response<List<DtoCategoryGallery>> GetAllCategoryGalleryForDrop();
        Response<List<DtoCategoryGalleryViewModal>> GetCategoryWithFile();
    }
}
