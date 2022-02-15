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
    public class PurchaseInvoiceRepository : GenericRepository<ApplicationContext, TblPurchase_Invoice>, IPurchaseInvoiceRepository
    {
        public async Task<Response<DtoPurchaseInvoiceForAdd>> AddEditPurchaseInvoice(DtoPurchaseInvoiceForAdd dto)
        {
 
                if (dto.AllProducts.Count != 0)
                {
                    var objPurchaseInv = new TblPurchase_Invoice()
                    {
                        Code = dto.Inv_Code,
                        AddedDate = DateTime.Now,
                        ClientName = dto.Client_Name,
                        CurrencyId = dto.Currency_Id,
                        Price_Invoice = dto.inv_total,
                        SupplierId = dto.Supplier_Id,
                        Type = dto.Type
                    };
                    Add(objPurchaseInv);
                    Save();
                    dto.Id = objPurchaseInv.Id;
                    for (int i = 0; i < dto.AllProducts.Count; i++)
                    {
                        PurchaseInvoiceDetailsRepository inv_details = new PurchaseInvoiceDetailsRepository();
                        inv_details.AddEditPurchaseInvoiceDetails(dto.AllProducts[i],objPurchaseInv.Id);
                    }
                }
            

            Response<DtoPurchaseInvoiceForAdd> res = new Response<DtoPurchaseInvoiceForAdd>();
            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = dto;
            return res;
        }

        Response<List<DtoPurchaseInvoiceForShow>> IPurchaseInvoiceRepository.GetAllInvoices()
        {
            var result = (from q in Context.TblPurchase_Invoice.AsNoTracking().Where(x => x.IsDeleted == null)
                          select new DtoPurchaseInvoiceForShow
                          {
                              Id = q.Id,
                              Type = q.Type,
                              Inv_Code = q.Code,
                              Client_Name = (q.ClientName == "") ? "--" : q.ClientName,
                              Currency_Name = q.TblCurrency.Name,
                              Supplier_Name = (q.TblSupplier.Name == "") ? "--" : q.TblSupplier.Name,
                              inv_total = q.Price_Invoice,
                              AllProducts=q.ListPurchase_Invoices_Details
                          }).ToList();
            Response<List<DtoPurchaseInvoiceForShow>> res = new Response<List<DtoPurchaseInvoiceForShow>>();

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            res.payload = result;

            return res;
        }
    }
}
