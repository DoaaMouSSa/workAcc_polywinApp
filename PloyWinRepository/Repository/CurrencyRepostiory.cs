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
   public class CurrencyRepostiory : GenericRepository<ApplicationContext, TblCurrency>, ICurrencyRepository
    {
        public async Task<Response<DtoCurrency>> AddEditCurrency(DtoCurrency dtoCurrency)
        {
            if (dtoCurrency != null)
            {
                if (dtoCurrency.Id > 0)
                {
                    var isExist = FindBy(x => x.Id == dtoCurrency.Id).FirstOrDefault();

                    if (isExist != null)
                    {
                        if (dtoCurrency.NameCurrency != null)
                        {
                            isExist.Name = dtoCurrency.NameCurrency;
                        }

                        isExist.ModifiedDate = DateTime.Now;

                        Edit(isExist);
                        Save();

                        dtoCurrency.Id = isExist.Id;
                        dtoCurrency.NameCurrency = isExist.Name;

                    }
                }
                else
                {
                    var objCurrency = new TblCurrency()
                    {
                        AddedDate = DateTime.Now,
                        Name = dtoCurrency.NameCurrency

                    };

                    Add(objCurrency);
                    Save();

                    dtoCurrency.Id = objCurrency.Id;
                }
            }

            Response<DtoCurrency> res = new Response<DtoCurrency>();
            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = dtoCurrency;
            return res;
        }

        public async Task<Response<bool>> DeleteCurrency(string Ids)
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


        public async Task<Response<List<DtoCurrency>>> getCurrency()
        {
            var result = (from q in Context.TblCurrency.AsNoTracking().Where(x => x.IsDeleted == null)
                          select new DtoCurrency
                          {
                              Id = q.Id,
                              NameCurrency = q.Name,
                          }).ToList();
            Response<List<DtoCurrency>> res = new Response<List<DtoCurrency>>();

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            res.payload = result;

            return res;
        }
    }
}
