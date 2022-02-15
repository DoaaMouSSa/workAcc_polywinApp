using PloyWinContext.Context;
using PloyWinContext.Entities;
using PloyWinDto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPloyWinRepository.InterFace
{
    public interface ICurrencyRepository : IGenericRepository<TblCurrency>
    {
        Task<Response<DtoCurrency>> AddEditCurrency(DtoCurrency dtoCurrency);
        Task<Response<bool>> DeleteCurrency(string Ids);
        Task<Response<List<DtoCurrency>>> getCurrency();
    }
}
