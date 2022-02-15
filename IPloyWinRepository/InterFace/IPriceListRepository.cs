using PloyWinContext.Entities;
using PloyWinDto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPloyWinRepository.InterFace
{
   public interface IPriceListRepository:IGenericRepository<TblPriceList>
    {
        Response<List<DtoPriceList>> GetAllPriceLst();
        Response<bool> DeletePriceLst(string Ids);
        Response<DtoPriceList> AddEditPriceLst(DtoPriceList dto);
    }
}
