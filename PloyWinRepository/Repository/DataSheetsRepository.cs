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
    public class DataSheetsRepository : GenericRepository<ApplicationContext, TblDataSheets>, IDataSheetsRepository
    {
        public Response<List<DtoDataSheets>> GetAllDataSheets()
        {
            var result = (from q in Context.TblDataSheets.AsNoTracking().Where(x => x.IsDeleted == null)
                          select new DtoDataSheets
                          {
                              Id = q.Id,
                              Description = q.Description,
                              ImagePath = q.ImagePath
                          }).ToList();

            Response<List<DtoDataSheets>> res = new Response<List<DtoDataSheets>>();
            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = result;
            return res;
        }

        public Response<bool> DeleteDataSheets(string ids)
        {
            var listId = ids.Split(',').ToList();

            bool dd = false;

            foreach (var item in listId)
            {
                var result = FindBy(x => x.Id == Convert.ToInt32(item)).FirstOrDefault();

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

        public Response<DtoDataSheets> AddEditDataSheets(DtoDataSheets dto)
        {
            if (dto != null)
            {
                if (dto.Id > 0)
                {
                    var isExist = FindBy(x => x.Id == dto.Id).FirstOrDefault();

                    if (isExist != null)
                    {
                        if (dto.fileUpload != null)
                        {
                            isExist.ImagePath = dto.ImagePath;
                        }

                        isExist.Description = dto.Description;
                        isExist.ModifiedDate = DateTime.Now;

                        Edit(isExist);
                        Save();
                    }

                }
                else
                {
                    var objDataSheet = new TblDataSheets()
                    {
                        AddedDate = DateTime.Now,
                        Description = dto.Description,
                        ImagePath = dto.ImagePath
                    };

                    Add(objDataSheet);
                    Save();

                    dto.Id = objDataSheet.Id;
                }
            }

            Response<DtoDataSheets> res = new Response<DtoDataSheets>();
            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = dto;
            return res;
        }
    }
}
