using PloyWinContext.Entities;
using PloyWinDto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPloyWinRepository.InterFace
{
    public interface IGallaryUserRepository : IGenericRepository<TblGallaryUser>
    {
        bool AddGalleryByContract(int? contractId,List<DtoGalleryUser> dto);
        List<DtoGalleryUser> GetAllGalleryByContractId(int contractId);
        bool DeleteGalleryById(int Id);
    }
}
