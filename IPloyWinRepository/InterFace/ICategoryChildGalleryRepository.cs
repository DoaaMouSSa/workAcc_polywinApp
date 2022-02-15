using PloyWinContext.Entities;
using PloyWinDto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPloyWinRepository.InterFace
{
    public interface ICategoryChildGalleryRepository : IGenericRepository<TblCategoryChildGallery>
    {
        Response<List<DtoCategoryChildGallery>> GetAllCategoryChildGallery();
        Response<List<DtoCategoryChildGallery>> GetAllCategoryChildGalleryForDrop();
        Response<DtoCategoryChildGallery> AddEditCategoryName(DtoCategoryChildGallery dtoCategoryGallery);
        Response<bool> DeleteCategoryName(string Ids);
    }
}
