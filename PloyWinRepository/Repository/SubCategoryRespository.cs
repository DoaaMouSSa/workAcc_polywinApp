using PloyWinContext.Context;
using PloyWinContext.Entities;
using IPloyWinRepository.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PloyWinDto.Dto;
using PloyWinRepository.EnumData;
using Microsoft.EntityFrameworkCore;

namespace PloyWinRepository.Repository
{
    public class SubCategoryRespository : GenericRepository<ApplicationContext, TblSubCategory>, ISubCategoryRepository
    {
        public Response<List<DtoSubCategory>> GetAllSubCategory()
        {
            var result = (from q in Context.TblSubCategories.AsNoTracking().Where(x => x.IsDeleted == null)
                          select new DtoSubCategory
                          {
                              Id = q.Id,
                              ParentCategoryId = q.ParentCategoryId,
                              ParentCategoryName = q.TblParentCategory.Name,
                              Name = q.Name,
                              FilePath = q.FilePath,
                              LogoUrl = q.LogoUrl
                          }).ToList();

            Response<List<DtoSubCategory>> res = new Response<List<DtoSubCategory>>();
            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = result;
            return res;
        }
        public Response<List<DtoParentCategoryForDropDown>> GetAllSubCategoryForDropDown()
        {
            var result = (from q in Context.TblSubCategories.AsNoTracking().Where(x => x.IsDeleted == null)
                          select new DtoParentCategoryForDropDown
                          {
                              Id = q.Id,
                              Name = q.Name,
                          }).ToList();

            Response<List<DtoParentCategoryForDropDown>> res = new Response<List<DtoParentCategoryForDropDown>>();
            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = result;
            return res;
        }
        public Response<DtoSubCategory> AddEditSubCategory(DtoSubCategory dto)
        {
            Response<DtoSubCategory> res = new Response<DtoSubCategory>();

            if (dto != null)

            {
                //Edit
                if (dto.Id > 0)
                {
                    var isExist = FindBy(x => x.Id == dto.Id).FirstOrDefault();
                    if (isExist != null)
                    {
                        if (dto.FilePath != null)
                        {
                            isExist.FilePath = dto.FilePath;
                        }
                        if (dto.LogoUrl != null)
                        {
                            isExist.LogoUrl = dto.LogoUrl;
                        }

                        isExist.ParentCategoryId = dto.ParentCategoryId;
                        isExist.Name = dto.Name;
                        isExist.ModifiedDate = DateTime.Now;
                        Edit(isExist);
                        Save();
                        dto.FilePath = isExist.FilePath;
                        dto.LogoUrl = isExist.LogoUrl;
                        dto.ParentCategoryName = Context.TblParentCategories.AsNoTracking().Where(x => x.Id == isExist.ParentCategoryId).FirstOrDefault().Name;
                    }
                }
                //Add
                else
                {
                    var obj = new TblSubCategory()
                    {
                        AddedDate = DateTime.Now,
                        Name = dto.Name,
                        FilePath = dto.FilePath,
                        LogoUrl = dto.LogoUrl,
                        ParentCategoryId = dto.ParentCategoryId
                    };
                    Add(obj);
                    Save();
                    dto.Id = obj.Id;
                    dto.ParentCategoryName = Context.TblParentCategories.AsNoTracking().Where(x => x.Id == dto.ParentCategoryId).FirstOrDefault().Name;
                }
            }
            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = dto;
            return res;
        }

        public Response<bool> DeleteSubCategory(string Ids)
        {
            var listId = Ids.Split(',').ToList();

            bool result = false;

            foreach (var Id in listId)
            {
                var isExist = FindBy(x => x.Id == Convert.ToInt32(Id)).FirstOrDefault();


                if (isExist != null)
                {
                    isExist.IsDeleted = true;
                    isExist.DeletedDate = DateTime.Now;

                    Edit(isExist);
                    Save();

                    result = true;
                }
            }

            Response<bool> res = new Response<bool>();
            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = result;
            return res;
        }

        public Response<List<DtoSubCategory>> GetSubCatByParentCat(int id)
        {
            Response<List<DtoSubCategory>> res = new Response<List<DtoSubCategory>>();

            var result = (from q in Context.TblSubCategories.AsNoTracking().Where(x => x.IsDeleted == null && x.ParentCategoryId == id)
                          select new DtoSubCategory
                          {
                              Id = q.Id,
                              Name = q.Name,
                              FilePath = q.FilePath,
                              LogoUrl = q.LogoUrl
                          }).ToList();


            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = result;
            return res;
        }
    }
}
