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
    public class CompanyInfoRepository : GenericRepository<ApplicationContext, TblCompanyInfo>, ICompanyInfoRepository
    {
        public Response<DtoCompanyInfo> GetCompanyInfo()
        {
            Response<DtoCompanyInfo> res = new Response<DtoCompanyInfo>();

            var result = (from q in Context.TblCompanyInfo.AsNoTracking().Where(x => x.Id > 0)
                          select new DtoCompanyInfo
                          {
                              Id = q.Id,
                              CompanyFile = q.CompanyFile,
                              FutureInfo = q.FutureInfo,
                              CompanyInfo = q.CompanyInfo
                          }).FirstOrDefault();

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            res.payload = result;
            return res;
        }

        public Response<DtoCompanyInfo> AddEditCompanyInfo(DtoCompanyInfo dto)
        {
            bool result = false;
            
            Response<DtoCompanyInfo> res = new Response<DtoCompanyInfo>();

            if (dto != null)
            {
                var isExist = FindBy(x => x.Id > 0).FirstOrDefault();

                if (isExist != null)
                {
                    isExist.CompanyInfo = dto.CompanyInfo;
                    isExist.ModifiedDate = DateTime.Now;
                    isExist.FutureInfo = dto.FutureInfo;
                    if (dto.CompanyFile != null)
                    {
                        isExist.CompanyFile = dto.CompanyFile;
                    }
                    
                    Edit(isExist);
                    Save();

                    result = true;
                }
                else
                {
                    var objCompany = new TblCompanyInfo()
                    {
                        AddedDate = DateTime.Now,
                        CompanyFile = dto.CompanyFile,
                        FutureInfo = dto.FutureInfo,
                        CompanyInfo = dto.CompanyInfo
                    };

                    Add(objCompany);
                    Save();
                }
            }

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            res.payload = dto;
            return res;
        }
    }
}
