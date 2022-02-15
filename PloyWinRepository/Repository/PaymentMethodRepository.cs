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
    public class PaymentMethodRepository : GenericRepository<ApplicationContext, TblPaymentMethods>, IPaymentMethod
    {
        public async Task<Response<DtoPaymentMethod>> AddEditPaymentMethod(DtoPaymentMethod dtoPaymentMethod)
        {
            if (dtoPaymentMethod != null)
            {
                if (dtoPaymentMethod.Id > 0)
                {
                    var isExist = FindBy(x => x.Id == dtoPaymentMethod.Id).FirstOrDefault();

                    if (isExist != null)
                    {
                        if (dtoPaymentMethod.namePaymentMethod != null)
                        {
                            isExist.namePaymentMethod = dtoPaymentMethod.namePaymentMethod;
                        }

                        isExist.ModifiedDate = DateTime.Now;

                        Edit(isExist);
                        Save();

                        dtoPaymentMethod.Id = isExist.Id;
                        dtoPaymentMethod.namePaymentMethod = isExist.namePaymentMethod;

                    }
                }
                else
                {
                    var objPayment = new TblPaymentMethods()
                    {
                        AddedDate = DateTime.Now,
                        namePaymentMethod = dtoPaymentMethod.namePaymentMethod

                    };

                    Add(objPayment);
                    Save();

                    dtoPaymentMethod.Id = objPayment.Id;
                }
            }

            Response<DtoPaymentMethod> res = new Response<DtoPaymentMethod>();
            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = dtoPaymentMethod;
            return res;
        }

        public async Task<Response<bool>> DeletePaymentMethod(string Ids)
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

        public async Task<Response<List<DtoPaymentMethod>>> getPaymentMethod()
        {
            var result = (from q in Context.TblPaymentMethods.AsNoTracking().Where(x => x.IsDeleted == null)
                          select new DtoPaymentMethod
                          {
                              Id = q.Id,
                              namePaymentMethod = q.namePaymentMethod,
                          }).ToList();
            Response<List<DtoPaymentMethod>> res = new Response<List<DtoPaymentMethod>>();

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            res.payload = result;

            return res;
        }
    }
}
