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
    public class CatalogueRepository : GenericRepository<ApplicationContext, TblCatalogue>, ICatalogueRepository
    {
        public Response<List<DtoCatalogue>> GetAllCatalogue()
        {
            var result = (from q in Context.TblCatalogue.AsNoTracking().Where(x => x.IsDeleted == null)
                          select new DtoCatalogue
                          {
                              Id = q.Id,
                              Description = q.Description,
                              filePath = q.filePath,
                              LogoPath = q.LogoPath
                          }).ToList();

            Response<List<DtoCatalogue>> res = new Response<List<DtoCatalogue>>();
            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = result;
            return res;
        }

        public Response<bool> DeleteCatalogue(string Ids)
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

        public Response<DtoCatalogue> AddEditCatalogue(DtoCatalogue dto)
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
                    var objDataSheet = new TblCatalogue()
                    {
                        AddedDate = DateTime.Now,
                        Description = dto.Description,
                        filePath = dto.filePath,
                        LogoPath = dto.LogoPath
                    };

                    Add(objDataSheet);
                    Save();

                    dto.Id = objDataSheet.Id;
                }
            }

            Response<DtoCatalogue> res = new Response<DtoCatalogue>();
            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = dto;
            return res;
        }
    }
}
