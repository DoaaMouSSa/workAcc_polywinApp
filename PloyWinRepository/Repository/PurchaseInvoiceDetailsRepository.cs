using IPloyWinRepository.InterFace;
using Microsoft.EntityFrameworkCore;
using PloyWinContext.Context;
using PloyWinContext.Entities;
using PloyWinDto.Dto;
using PloyWinRepository.EnumData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinRepository.Repository
{
    public class PurchaseInvoiceDetailsRepository : GenericRepository<ApplicationContext, TblPurchase_Invoices_Details>, IPurchaseInvoiceDetailsRepository
    {

      public  Response<DtoPurchaseInvoiceDetails> AddEditPurchaseInvoiceDetails(DtoPurchaseInvoiceDetails dto,int inv_id)
        {
            var objPurchaseInvProducts = new TblPurchase_Invoices_Details()
            {
                AddedDate = DateTime.Now,
                Invoice_id = inv_id,
                ProuctId = dto.Product_Id,
                ProuctIdName = dto.Product_IdName,
                Qty = dto.Qty,
                Price = dto.Price,
                TPrice_Product = dto.TPrice_product
            };
            Add(objPurchaseInvProducts);
            Save();
            Response<DtoPurchaseInvoiceDetails> res = new Response<DtoPurchaseInvoiceDetails>();
            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = dto;
            return res;
        }

        public Response<DtoPurchaseInvoiceDetails> GetProductsGroupByInvoice(DtoPurchaseInvoiceDetails dto, int Id)
        {
            throw new NotImplementedException();
        }
    }
}
