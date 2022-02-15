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
    public class ColorsRepository : GenericRepository<ApplicationContext, TblColors>, IColorsRepository
    {
        public Response<List<DtoColors>> GetAllColors()
        {
            Response<List<DtoColors>> res = new Response<List<DtoColors>>();

            var result = (from q in Context.TblColors.AsNoTracking().Where(x => x.IsDeleted == null)
                          select new DtoColors
                          {
                              Id = q.Id,
                              ColorName = q.ColorName
                          }).ToList();

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            res.payload = result;
            return res;
        }
         
        public Response<DtoColors> AddEditColors(DtoColors dto)
        {
            if (dto != null)
            {
                if (dto.Id > 0)
                {
                    var isExist = FindBy(x => x.Id == dto.Id).FirstOrDefault();

                    if (isExist != null)
                    {
                        isExist.ColorName = dto.ColorName;
                        isExist.ModifiedDate = DateTime.Now;

                        Edit(isExist);
                        Save();
                    }
                }
                else
                {
                    var objColor = new TblColors()
                    {
                        AddedDate = DateTime.Now,
                        ColorName = dto.ColorName
                    };

                    Add(objColor);
                    Save();
                }
            }
         
            Response<DtoColors> res = new Response<DtoColors>();

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            res.payload = dto ;
            return res;    
        }

        public Response<bool> DeleteColors(string Ids)
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

        public Response<List<DtoColors>> GetColorsForWorkShop()
        {
            Response<List<DtoColors>> res = new Response<List<DtoColors>>();

            var result = (from q in Context.TblColors.AsNoTracking().Where(x => x.IsDeleted == null)
                          select new DtoColors
                          {
                              Id = q.Id,
                              ColorName = q.ColorName
                          }).Take(3).ToList();

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            res.payload = result;
            return res;
        }
    }
}
