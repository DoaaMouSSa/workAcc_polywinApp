using PloyWinContext.Entities;
using PloyWinDto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPloyWinRepository.InterFace
{
    public interface IDescountRepository : IGenericRepository<TblDescount>
    {
        Response<List<DtoDescount>> GetAllDescount();
        List<DtoDescount> GetDescountByType(int? type);
        Response<bool> AddDescount(DtoDescountAdded dtoDescount);
        Response<bool> DeleteDescount(string id);
        Response<DtoDescountEdit> AddEditDescount(DtoDescountEdit dtoDescount);
    }
}
