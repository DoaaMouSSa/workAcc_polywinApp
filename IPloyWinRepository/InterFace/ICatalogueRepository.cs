using PloyWinContext.Entities;
using PloyWinDto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPloyWinRepository.InterFace
{
    public interface ICatalogueRepository : IGenericRepository<TblCatalogue>
    {
        Response<List<DtoCatalogue>> GetAllCatalogue();
        Response<bool> DeleteCatalogue(string Ids);
        Response<DtoCatalogue> AddEditCatalogue(DtoCatalogue dto);
    }
}
