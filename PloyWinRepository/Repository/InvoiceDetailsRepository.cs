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
    public class InvoiceDetailsRepository : GenericRepository<ApplicationContext, TblInvoicesDetails>, IInvoiceDetailsRepository
    {
 
        

        public async Task<bool> AddInvoicesDetails(int invoiceId, List<DtoInvoiceDetails> dtoInvoiceDetails)
        {
            if (dtoInvoiceDetails.Count() > 0 && invoiceId > 0)
            {
                foreach (var item in dtoInvoiceDetails)
                {
                    var objItem = new TblInvoicesDetails()
                    {
                        InvoiceId = invoiceId,
                        ProductId = item.productId,
                        AddedDate = DateTime.Now,
                        NumberIron = item.numberIron,
                        TypeOfProduct = item.typeOfProduct,
                        Quantity = item.quantity,
                        Descount = item.descount,
                        PricePerOne = item.pricePerOne,
                        PriceWithDescount = item.priceWithDescount,
                        PricePerMeter = item.pricePerMeter
                    };

                    Add(objItem);
                }

                Save();

                return true;
            }

            return false;
        }

        public async Task<bool> UpdateInvoicesDetails(List<DtoUpdateInvoiceDetails> ids)
        {
            //var listId = ids.Split(',').ToList();
            var invoiceId = 0;
            foreach (var item in ids)
            {

                var result = FindBy(x => x.Id == item.Id).FirstOrDefault();

                if (result != null)
                {
                    if (item.IsRescived==false)
                    {
                        Delete(result);
                    }
                    else
                    {
                        invoiceId = result.InvoiceId.Value;
                        result.IsRecived = item.IsRescived;
                        result.Description = item.Description;
                        result.Quantity = item.qty;
                        Edit(result);

                    }
                }
            }

            


            Save();

            return true;
        }

        public async Task<Response<List<DtoInvoiceDetails>>> GetInvoicesDetails(int invoiceId)
        {
            Response<List<DtoInvoiceDetails>> res = new Response<List<DtoInvoiceDetails>>();

            var result = (from q in Context.TblInvoicesDetails.AsNoTracking().Where(x => x.InvoiceId == invoiceId)
                          select new DtoInvoiceDetails
                          {
                              id = q.Id,
                              productName = q.Product.Name,
                              //ImgURL = q.Product.ImgURL,
                              quantity = q.Quantity,
                              totalOrder = Math.Round((decimal)(q.Quantity * q.PricePerOne), 2)
                          }).ToList();


            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = result;
            return res;
        }

        public async Task UpdateInvoicesDetailsWithInvoices(int invoiceId, bool isRecived, string descrition)
        {
            var result = Context.TblInvoicesDetails.AsNoTracking().Where(x => x.InvoiceId == invoiceId).ToList();

            foreach (var item in result)
            {
                item.IsRecived = isRecived;
                item.Description = descrition;

                Edit(item);
                Save();
            }
        }

        public bool UpdateQuantityInvoicesDetails(int Id, int Qty)
        {
            var isExist = FindBy(x => x.Id == Id).FirstOrDefault();

            if (isExist != null)
            {
                isExist.Quantity = Qty;
                Edit(isExist);
                Save();
                return true;
            }

            return false;
        }
    }
}
