using PloyWinContext.Entities;
using PloyWinDto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPloyWinRepository.InterFace
{
    public interface IColorsRepository : IGenericRepository<TblColors>
    {
        Response<bool> DeleteColors(string Ids);
        Response<DtoColors> AddEditColors(DtoColors dto);
        Response<List<DtoColors>> GetAllColors();
        Response<List<DtoColors>> GetColorsForWorkShop();
    }
}
