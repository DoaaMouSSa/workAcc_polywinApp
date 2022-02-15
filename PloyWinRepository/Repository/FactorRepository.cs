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
    public class FactorRepository : GenericRepository<ApplicationContext, TblFactor>, IFactorRepository
    {
        public Response<DtoFactor> AddEditFactor(DtoFactor dto)
        {
            if (dto != null)
            {
                if (dto.Id > 0)
                {
                    var isExist = FindBy(x => x.Id == dto.Id).FirstOrDefault();

                    if (isExist != null)
                    {
                        if (dto.file != null)
                        {
                            isExist.filePath = dto.filePath;
                        }
                        isExist.Description = dto.Description;

                        if (dto.LogoPath != null)
                        {
                            isExist.LogoPath = dto.LogoPath;
                        }
                        isExist.ModifiedDate = DateTime.Now;

                        Edit(isExist);
                        Save();

                        dto.filePath = isExist.filePath;
                        dto.LogoPath = isExist.LogoPath;
                    }
                }
                else
                {
                    var obj = new TblFactor()
                    {
                        AddedDate = DateTime.Now,
                        Description = dto.Description,
                        filePath = dto.filePath,
                        LogoPath = dto.LogoPath
                    };

                    Add(obj);
                    Save();

                    dto.Id = obj.Id;
                }
            }

            Response<DtoFactor> res = new Response<DtoFactor>();
            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = dto;
            return res;
        }

        public Response<bool> DeleteFactor(string Ids)
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

        public Response<List<DtoFactor>> GetAllFactor()
        {
            var result = (from q in Context.TblFactor.AsNoTracking().Where(x => x.IsDeleted == null)
                          select new DtoFactor
                          {
                              Id = q.Id,
                              Description = q.Description,
                              filePath = q.filePath,
                              LogoPath = q.LogoPath
                          }).ToList();

            Response<List<DtoFactor>> res = new Response<List<DtoFactor>>();
            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = result;
            return res;
        }
    }
}
