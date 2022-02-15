using PloyWinContext.Entities;
using PloyWinDto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPloyWinRepository.InterFace
{
    public interface IDataSheetsRepository : IGenericRepository<TblDataSheets>
    {
        Response<DtoDataSheets> AddEditDataSheets(DtoDataSheets dto);
        Response<bool> DeleteDataSheets(string ids);
        Response<List<DtoDataSheets>> GetAllDataSheets();

    }
}
