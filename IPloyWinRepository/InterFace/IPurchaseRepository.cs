using PloyWinContext.Entities;
using PloyWinDto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPloyWinRepository.InterFace
{
    public interface IPurchaseRepository:IGenericRepository<TblPurchase>
    {
        Task<Response<DtoPurchase>> AddEditPurchase(DtoPurchase dtoPurchase);
        Task<Response<bool>> DeletePurchase(string Ids);
        Task<Response<List<DtoPurchaseForShow>>> getPurchase();
    }
}
