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
    public class ParentProductCategoryRepository : GenericRepository<ApplicationContext, TblParentProductCategory>, IParentProductCategoryRepository
    {
        public Response<List<DtoParentProductCategory>> GetAllParentProductCategory()
        {
            Response<List<DtoParentProductCategory>> res = new Response<List<DtoParentProductCategory>>();

            var result = (from q in Context.TblParentProductCategory.AsNoTracking().Where(x => x.IsDeleted == null)
                          select new DtoParentProductCategory
                          {
                              Id = q.Id,
                              CatgoryName = q.CatgoryName,
                              haveIron = q.haveIron,
                              haveIronString = q.haveIron== true ? "لدية حديد":"ليس لدية حديد"
                          }).ToList();

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            res.payload = result;
            return res;
        }

        public Response<DtoParentProductCategory> AddEditParentProductCategory(DtoParentProductCategory dto)
        {
            if (dto != null)
            {
                if (dto.Id > 0)
                {
                    var isExist = FindBy(x => x.Id == dto.Id).FirstOrDefault();

                    if (isExist != null)
                    {
                        isExist.CatgoryName = dto.CatgoryName;
                        isExist.ModifiedDate = DateTime.Now;
                        isExist.haveIron = dto.haveIron;

                        Edit(isExist);
                        Save();
                    }
                }
                else
                {
                    var objParentProductCategory = new TblParentProductCategory()
                    {
                        AddedDate = DateTime.Now,
                        CatgoryName = dto.CatgoryName,
                        haveIron = dto.haveIron
                    };

                    Add(objParentProductCategory);
                    Save();

                    dto.Id = objParentProductCategory.Id;
                }
            }

            Response<DtoParentProductCategory> res = new Response<DtoParentProductCategory>();

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            res.payload = dto;
            return res;
        }

        public Response<bool> DeleteParentProductCategory(string Ids)
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
