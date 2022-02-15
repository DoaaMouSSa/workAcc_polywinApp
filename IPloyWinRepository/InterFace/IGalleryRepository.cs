using PloyWinContext.Entities;
using PloyWinDto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPloyWinRepository.InterFace
{
    public interface IGalleryRepository : IGenericRepository<TblGallery>
    {
        Task<Response<List<DtoGalleryGroup>>> GetAllAgent(int type);
        Response<DtoGalleryViewModal> AddEditGalleryImage(DtoGalleryViewModal dto);
        Response<bool> DeleteGallery(string id);
        Response<List<DtoGalleryForViewModal>> GetAllGallery(int type);
    }
}
