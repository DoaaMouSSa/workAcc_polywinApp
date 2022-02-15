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
    public class InvoiceRepository : GenericRepository<ApplicationContext, TblInvoices> , IInvoiceRepository
    {
        public async Task<Response<int>> GetMaxNumberIncoices()
        {
            Response<int> res = new Response<int>();

            var maxNumber = FindBy(x => x.IsDeleted == null).Max(x => x.InvoicesNumber) ?? 0;

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = (maxNumber + 1);
            return res;
        }


        public async Task<Response<int>> AddNewInvoices(DtoInvoice dtoInvoice, ApplicationUser user)
        {
            Response<int> res = new Response<int>();

            int result = 0;

            if (dtoInvoice != null)
            {
                var objInvoices = new TblInvoices()
                {
                    InvoicesNumber = dtoInvoice.invoicesNumber,
                    InvoicesDate = dtoInvoice.invoicesDate,
                    Describtion = dtoInvoice.describtion,
                    TotalInvoices = dtoInvoice.totalInvoices,
                    DescountInvoices = dtoInvoice.descountInvoices,
                    TotalWithInvoices = dtoInvoice.totalWithInvoices,
                    AddedDate = DateTime.Now,
                    ToUserId = user.ManagerId,
                    FromUserId = user.Id,
                    TotalPayed = dtoInvoice.totalPayed,
                    TotalAmount = dtoInvoice.totalAmount,
                };

                Add(objInvoices);
                Save();

                result = objInvoices.Id;
            }

            res.code = result > 0 ? StaticApiStatus.ApiSuccess.Code : StaticApiStatus.ApiFaild.Code;
            res.message = result > 0 ? StaticApiStatus.ApiSuccess.MessageAr : StaticApiStatus.ApiFaild.MessageAr;
            res.status = result > 0 ? StaticApiStatus.ApiSuccess.Status : StaticApiStatus.ApiFaild.Status;
            res.payload = result;
            return res;
        }


        public async Task<Response<List<DtoInvoice>>> GetAllInvoicesByResived(bool? IsRecived)
        {
            Response<List<DtoInvoice>> res = new Response<List<DtoInvoice>>();

            var result = (from q in Context.TblInvoices.AsNoTracking().Where(x => x.IsRecived == IsRecived && x.IsDeleted == null)
                          select new DtoInvoice
                          {
                              id = q.Id,
                              descountInvoices = q.DescountInvoices,
                              describtion = q.Describtion,
                              invoicesDate = q.InvoicesDate,
                              invoicesNumber = q.InvoicesNumber,
                              isRecivedText = q.IsRecived == true ? "تم تنفيذ الطلبية" : (q.IsRecived == false ? "تم رفض الطلبيه" : "الطلب قيد التنفيذ"),
                              totalInvoices = q.TotalInvoices,
                              totalWithInvoices = q.TotalWithInvoices,
                              details = Context.TblInvoicesDetails.Where(x => x.Invoice.Id == q.Id && x.IsDeleted == null)
                              .Select(s => new DtoInvoiceDetails
                              {
                                  id = s.Id,
                                  productName = s.Product.Name,
                                  numberIron = s.NumberIron,
                                  quantity = s.Quantity,
                                  typeOfProductText = s.Product.TblCategory.TypeOfCategory == 1 ? (s.TypeOfProduct == 1 ? "لفة" : "عود") : (s.TypeOfProduct == 2 ? "كرتونة" : "عود")
                              }).ToList()
                          }).OrderByDescending(x => x.id).ToList();

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = result;
            return res;
        }


        public async Task<Response<List<DtoInvoice>>> GetAllInvoicesFromPolyWin(int? IsRecived, ApplicationUser ToUserId)
        {
            bool? typeRecived = null;

            switch (IsRecived)
            {
                case 1:
                    typeRecived = null;
                    break;
                case 2:
                    typeRecived = true;
                    break;
                case 3:
                    typeRecived = false;
                    break;
                default:
                    break;
            }

            int order = 1;

            var result = (from q in Context.TblInvoices.AsNoTracking().Where(x => x.IsRecived == typeRecived && x.ToUserId == ToUserId.Id && x.IsDeleted == null)
                          select new DtoInvoice
                          {
                              id = q.Id,
                              fromUserId = q.FromUserId,
                              descountInvoices = q.DescountInvoices,
                              describtion = q.Describtion,
                              invoicesDate = q.AddedDate,
                              invoicesNumber = q.InvoicesNumber,
                              isRecivedText = q.IsRecived == true ? "تم تنفيذ الطلبية" : (q.IsRecived == false ? "تم رفض الطلبيه" : "الطلب قيد التنفيذ"),
                              totalInvoices = q.TotalInvoices,
                              totalWithInvoices = q.TotalWithInvoices,
                              details = Context.TblInvoicesDetails.Where(x => x.Invoice.Id == q.Id && x.IsDeleted == null)
                              .Select(s => new DtoInvoiceDetails
                              {
                                  id = s.Id,
                                  productId = s.ProductId,
                                  isRecived = s.IsRecived,
                                  Description = s.Description,
                                  numberIron = s.NumberIron,
                                  quantity = s.Quantity,
                                  pricePerMeter = s.PricePerMeter,
                                  descount = s.Descount,
                                  pricePerOne = s.PricePerOne,
                             
                                  priceWithDescount = s.PriceWithDescount,
                                  ImgURL = s.Product.TblProductName.ImgURL,
                                  totalOrder = Math.Round((decimal)(s.Quantity * s.PriceWithDescount),  2)
                              }).ToList()
                          }).ToList();

            foreach (var item in result)
            {
                string date = item.invoicesDate.ToString().Split("T")[0];
                item.invoicesDateString = date;

                item.order = order;

                var agentname = Context.TblAgent.AsNoTracking().Where(x => x.UserId == item.fromUserId).Select(x => x.NameAgent).FirstOrDefault();

                item.Agent = agentname;

                order++;

                foreach (var product in item.details)
                {
                    var ObjProduct = Context.TblProducts.AsNoTracking().Where(x => x.Id == product.productId).Select(x => new { productId = x.ProductId, ColorId = x.ColorId }).FirstOrDefault();

                    var productName = Context.TblProductName.AsNoTracking().Where(x => x.Id == ObjProduct.productId).FirstOrDefault().Name;

                    var colorName = Context.TblColors.AsNoTracking().Where(x => x.Id == ObjProduct.ColorId).FirstOrDefault().ColorName;

                    product.productName = productName;
                    product.Color = colorName;
                }
            }

            Response<List<DtoInvoice>> res = new Response<List<DtoInvoice>>();

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = result;
            return res;
        }

        public async Task<Response<List<DtoInvoice>>> GetAllInvoicesByRecived(int? IsRecived, ApplicationUser ToUserId)
        {
            bool? typeRecived = null;

            switch (IsRecived)
            {
                case 1:
                    typeRecived = null;
                    break;
                case 2:
                    typeRecived = true;
                    break;
                case 3:
                    typeRecived = false;
                    break;
                default:
                    break;
            }

            int order = 1;

            var result = (from q in Context.TblInvoices.AsNoTracking().Where(x => x.IsRecived == typeRecived && x.ToUserId == ToUserId.Id && x.IsDeleted == null)
                          select new DtoInvoice
                          {
                              id = q.Id,
                              fromUserId = q.FromUserId,
                              descountInvoices = q.DescountInvoices,
                              describtion = q.Describtion,
                              invoicesDate = q.AddedDate,
                              invoicesNumber = q.InvoicesNumber,
                              isRecivedText = q.IsRecived == true ? "تم تنفيذ الطلبية" : (q.IsRecived == false ? "تم رفض الطلبيه" : "الطلب قيد التنفيذ"),
                              totalInvoices = q.TotalInvoices,
                              totalWithInvoices = q.TotalWithInvoices,
                              details = Context.TblInvoicesDetails.Where(x => x.Invoice.Id == q.Id && x.IsDeleted == null)
                              .Select(s => new DtoInvoiceDetails
                              {
                                  id = s.Id,
                                  productId = s.ProductId,
                                  isRecived = s.IsRecived,
                                  Description = s.Description,
                                  numberIron = s.NumberIron,
                                  quantity = s.Quantity,
                                  //ImgURL = Context.TblProductName.AsNoTracking().Where(x => x.Id == s.ProductId).Select(x => x.ImgURL).FirstOrDefault(),
                                  ImgURL = s.Product.TblProductName.ImgURL,

                                  totalOrder = Math.Round((decimal)(s.Quantity * s.PricePerOne)-s.PriceWithDescount.Value, 2)
                              }).ToList()
                          }).ToList();

            foreach (var item in result)
            {
                string date = item.invoicesDate.ToString().Split("T")[0];
                item.invoicesDateString = date;

                item.order = order;

                var agentname = Context.TblAgent.AsNoTracking().Where(x => x.UserId == item.fromUserId).Select(x => x.NameAgent).FirstOrDefault();

                item.Agent = agentname;

                order++;

                foreach (var product in item.details)
                {
                    var ObjProduct = Context.TblProducts.AsNoTracking().Where(x => x.Id == product.productId).Select(x => new { productId = x.ProductId, ColorId = x.ColorId }).FirstOrDefault();

                    var productName = Context.TblProductName.AsNoTracking().Where(x => x.Id == ObjProduct.productId).FirstOrDefault().Name;

                    var colorName = Context.TblColors.AsNoTracking().Where(x => x.Id == ObjProduct.ColorId).FirstOrDefault().ColorName;

                    product.productName = productName;
                    product.Color = colorName;
                }
            }

            Response<List<DtoInvoice>> res = new Response<List<DtoInvoice>>();

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = result;
            return res;
        }

        public async Task<Response<List<DtoInvoice>>> GetAllInvoicesFromAgentOrWorkShop(int? IsRecived, ApplicationUser ToUserId)
        {
            bool? typeRecived = null;
            switch (IsRecived)
            {
                case 1:
                    typeRecived = null;
                    break;
                case 2:
                    typeRecived = true;
                    break;
                case 3:
                    typeRecived = false;
                    break;
                default:
                    break;
            }

            int order = 1;

            var result = (from q in Context.TblInvoices.AsNoTracking().Where(x => x.IsRecived == typeRecived && x.FromUserId == ToUserId.Id && x.IsDeleted == null)
                          select new DtoInvoice
                          {
                              id = q.Id,
                              toUserId = q.ToUserId,
                              descountInvoices = q.DescountInvoices,
                              describtion = q.Describtion,
                              invoicesDate = q.AddedDate,
                              invoicesNumber = q.InvoicesNumber,
                              isRecivedText = q.IsRecived == true ? "تم تنفيذ الطلبية" : (q.IsRecived == false ? "تم رفض الطلبيه" : "الطلب قيد التنفيذ"),
                              totalInvoices = q.TotalInvoices,
                              totalWithInvoices = q.TotalWithInvoices,
                              details = Context.TblInvoicesDetails.Where(x => x.Invoice.Id == q.Id && x.IsDeleted == null)
                              .Select(s => new DtoInvoiceDetails
                              {
                                  id = s.Id,
                                  productId = s.ProductId,
                                  //productName = s.Product.TblProductName.Name,
                                  isRecived = s.IsRecived,
                                  Description = s.Description,
                                  numberIron = s.NumberIron,
                                  quantity = s.Quantity,
                                  descount = s.Descount,
                                  pricePerMeter = s.PricePerMeter ?? 0,
                                  pricePerOne = s.PricePerOne ?? 0,
                                  priceWithDescount = s.PriceWithDescount ?? 0,
                          
                                  
                                   totalOrder = Math.Round((decimal)((s.Quantity * s.PriceWithDescount) ), 2),
                                  ImgURL = s.Product.TblProductName.ImgURL
                              }).ToList()
                          }).ToList();

            foreach (var item in result)
            {
                string date = item.invoicesDate.ToString().Split("T")[0];
                item.invoicesDateString = date;
                item.order = order;

                var agentname = Context.TblAgent.AsNoTracking().Where(x => x.UserId == item.toUserId).Select(x => x.NameAgent).FirstOrDefault();

                item.Agent = agentname;

                order++;

                foreach (var product in item.details)
                {
                    var ObjProduct = Context.TblProducts.AsNoTracking().Where(x => x.Id == product.productId).Select(x => new { productId = x.ProductId, ColorId = x.ColorId }).FirstOrDefault();

                    var productName = Context.TblProductName.AsNoTracking().Where(x => x.Id == ObjProduct.productId).Select(x => new { x.Name, x.ImgURL }).FirstOrDefault();

                    var colorName = Context.TblColors.AsNoTracking().Where(x => x.Id == ObjProduct.ColorId).FirstOrDefault().ColorName;

                    product.productName = productName.Name;
                    product.productPath = productName.ImgURL;
                    product.Color = colorName;
                }
            }

            Response<List<DtoInvoice>> res = new Response<List<DtoInvoice>>();

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = result;
            return res;
        }

        public async Task<Response<List<DtoTotalPayedAgent>>> GetStatisticsForAgent(int userType)
        {
            var listAgent = Context.Users.Where(x => x.UserType == userType && x.isDeleted == null).Select(x => x.Id).ToList();

            List<DtoTotalPayedAgent> result = new List<DtoTotalPayedAgent>();

            foreach (var item in listAgent)
            {
                var TotalInvoices = Context.TblInvoices.AsNoTracking().Where(x => x.FromUserId == item && x.IsRecived == true && x.IsDeleted == null).Sum(x => x.TotalWithInvoices) ?? 0;
                var TotalPayed = Context.TblInvoices.AsNoTracking().Where(x => x.ToUserId == item && x.IsRecived == true && x.IsDeleted == null).Sum(x => x.TotalWithInvoices) ?? 0;
                var AgentName = Context.TblAgent.Where(x => x.UserId == item).Select(x => new
                {
                    Name = x.NameAgent,
                    Logo = x.AgentLogo
                }).FirstOrDefault();

                result.Add(new DtoTotalPayedAgent { AgentName = AgentName != null ? AgentName.Name : "", TotalInvoices = TotalInvoices, TotalPayed = TotalPayed, AgentLogo = AgentName != null ? AgentName.Logo : "" });
            }

            Response<List<DtoTotalPayedAgent>> res = new Response<List<DtoTotalPayedAgent>>();

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = result;
            return res;

        }

        public async Task UpdateInvoicesRescived(int id)
        {
            var result = FindBy(c => c.Id == id).FirstOrDefault();

            if (result != null)
            {
                var resDet = Context.TblInvoicesDetails.Where(x => x.Invoice.Id == id && x.IsDeleted == null);
                result.IsRecived = true;
                result.ModifiedDate = DateTime.Now;
                result.DescountInvoices = result.DescountInvoices;
                //Math.Round((decimal)(s.Quantity * s.PricePerOne), 2)

                var invoice = Context.TblInvoices.Where(x => x.Id == id).FirstOrDefault();

                decimal invoiceVal = 0;
                decimal invoicewithDiscount = 0;

                foreach (var item in resDet)
                {
                    
                    if (item.IsRecived==true)
                    {
                        invoiceVal += (decimal)(item.Quantity * item.PricePerOne);
                        invoicewithDiscount += (decimal)(item.Quantity * item.PriceWithDescount); ;
                    }

                }
                result.TotalInvoices = invoiceVal;
                result.TotalWithInvoices = invoicewithDiscount;

                Edit(result);
                Save();
            }
        }

        public async Task<Response<bool>> UpdateInvoices(int id, string description, bool isRecived, double? totalinvoices, double? descount, double? totalwithdescount)
        {
            var result = FindBy(c => c.Id == id).FirstOrDefault();
            bool gg = false;
            if (result != null)
            {
                result.IsRecived = isRecived;
                result.Describtion = description;
                result.ModifiedDate = DateTime.Now;
                result.TotalInvoices = (decimal)totalinvoices;
                result.DescountInvoices = (decimal)descount;
                result.TotalWithInvoices = (decimal)totalwithdescount;

                Edit(result);
                Save();

                gg = true;
            }

            Response<bool> res = new Response<bool>();

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = gg;
            return res;
        }

        public Response<bool> DeleteInvoices(string Ids)
        {
            var listId = Ids.Split(',').ToList();

            bool dd = false;

            foreach (var Id in listId)
            {
                var result = FindBy(x => x.Id == Convert.ToInt32(Id)).FirstOrDefault();


                if (result != null)
                {
                    result.IsDeleted = true;
                    result.DeletedDate = DateTime.Now;

                    Edit(result);
                    Save();

                    dd = true;
                }
            }

            Response<bool> res = new Response<bool>();
            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = dd;
            return res;
        }
    }
}
