using PloyWinContext.Entities;
using PloyWinDto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPloyWinRepository.InterFace
{
   public interface IPurchaseInvoiceDetailsRepository:IGenericRepository<TblPurchase_Invoices_Details>
    {
        Response<DtoPurchaseInvoiceDetails> AddEditPurchaseInvoiceDetails(DtoPurchaseInvoiceDetails dto,int Id);
        Response<DtoPurchaseInvoiceDetails> GetProductsGroupByInvoice(DtoPurchaseInvoiceDetails dto, int Id);
    }
}
