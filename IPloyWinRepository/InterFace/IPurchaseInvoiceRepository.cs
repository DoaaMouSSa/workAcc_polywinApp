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
   public interface IPurchaseInvoiceRepository : IGenericRepository<TblPurchase_Invoice>
    {
        Task<Response<DtoPurchaseInvoiceForAdd>> AddEditPurchaseInvoice(DtoPurchaseInvoiceForAdd dto);
        Response<List<DtoPurchaseInvoiceForShow>> GetAllInvoices();
    }
}
