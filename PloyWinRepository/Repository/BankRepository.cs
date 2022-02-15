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
    public class BankRepository : GenericRepository<ApplicationContext, TblBank>, IBankRepository
    {
        public async Task<Response<DtoBank>> AddEditBank(DtoBank dtoBank)
        {
            {
                if (dtoBank != null)
                {
                    if (dtoBank.Id > 0)
                    {
                        var isExist = FindBy(x => x.Id == dtoBank.Id).FirstOrDefault();

                        if (isExist != null)
                        {
                            if (dtoBank.nameBank != null)
                            {
                                isExist.nameBank = dtoBank.nameBank;
                            }

                            isExist.ModifiedDate = DateTime.Now;

                            Edit(isExist);
                            Save();

                            dtoBank.Id = isExist.Id;
                            dtoBank.nameBank = isExist.nameBank;

                        }
                    }
                    else
                    {
                        var objBank = new TblBank()
                        {
                            AddedDate = DateTime.Now,
                            nameBank = dtoBank.nameBank

                        };

                        Add(objBank);
                        Save();

                        dtoBank.Id = dtoBank.Id;
                        dtoBank.nameBank = dtoBank.nameBank;
                    }
                }

                Response<DtoBank> res = new Response<DtoBank>();
                res.code = StaticApiStatus.ApiSuccess.Code;
                res.message = StaticApiStatus.ApiSuccess.MessageAr;
                res.status = StaticApiStatus.ApiSuccess.Status;
                res.payload = dtoBank;
                return res;
            }
        }
        public async Task<Response<bool>> DeleteBank(string Ids)
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
    
        public async Task<Response<List<DtoBank>>> getBank()
        {
            var result = (from q in Context.TblBank.AsNoTracking().Where(x => x.IsDeleted == null)
                          select new DtoBank
                          {
                              Id = q.Id,
                              nameBank = q.nameBank,
                          }).ToList();
            Response<List<DtoBank>> res = new Response<List<DtoBank>>();

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            res.payload = result;

            return res;
        }
    }
}
