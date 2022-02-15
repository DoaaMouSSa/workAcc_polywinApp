using IPloyWinRepository.InterFace;
using Microsoft.EntityFrameworkCore;
using PloyWinContext.Context;
using PloyWinContext.Entities;
using PloyWinDto.Dto;
using PloyWinRepository.EnumData;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PloyWinRepository.Repository
{
    public class ParentCategoryRepository : GenericRepository<ApplicationContext, TblParentCategory>, IParentCategoryRepository
    {
        public Response<List<DtoParentCategory>> GetAllParentCategory()
        {
            var result = (from q in Context.TblParentCategories.AsNoTracking().Where(x => x.IsDeleted == null)
                          select new DtoParentCategory
                          {
                              Id = q.Id,
                              Name = q.Name,
                              FilePath = q.FilePath,
                              LogoUrl = q.LogoUrl
                          }).ToList();

            Response<List<DtoParentCategory>> res = new Response<List<DtoParentCategory>>();
            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = result;
            return res;
        }

        public Response<List<DtoParentCategoryForDropDown>> GetAllParentCategoryForDropDown()
        {
            var result = (from q in Context.TblParentCategories.AsNoTracking().Where(x => x.IsDeleted == null)
                          select new DtoParentCategoryForDropDown
                          {
                              Id = q.Id,
                              Name = q.Name
                          }).ToList();

            Response<List<DtoParentCategoryForDropDown>> res = new Response<List<DtoParentCategoryForDropDown>>();
            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = result;
            return res;
        }

        public Response<DtoParentCategory> AddEditParentCategory(DtoParentCategory dto)
        {
            Response<DtoParentCategory> res = new Response<DtoParentCategory>();

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
                        isExist.Name = dto.Name;
                        isExist.ModifiedDate = DateTime.Now;
                        Edit(isExist);
                        Save();
                        dto.FilePath = isExist.FilePath;
                        dto.LogoUrl = isExist.LogoUrl;

                    }
                }
                //Add
                else
                {
                    var obj = new TblParentCategory()
                    {
                        AddedDate = DateTime.Now,
                        Name = dto.Name,
                        FilePath = dto.FilePath,
                        LogoUrl = dto.LogoUrl
                    };
                    Add(obj);
                    Save();
                    dto.Id = obj.Id;
                }
            }
            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = dto;
            return res;
        }

        public Response<bool> DeleteParentCategory(string Ids)
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

        public Response<List<DtoParentSubCategory>> GetAllParentSubCategory()
        {
            var result = (from q in Context.TblParentCategories.AsNoTracking().Where(x => x.IsDeleted == null)
                          select new DtoParentSubCategory
                          {
                              Id = q.Id,
                              ParentCategory = q.Name,
                              ListSub = q.TblSubCategories.Where(x => x.IsDeleted == null).Select(x =>
                                new DtoListSub
                                {
                                    Id = x.Id,
                                    filePath = x.FilePath,
                                    SubCategory = x.Name
                                }).ToList()
                          }).ToList();

            Response<List<DtoParentSubCategory>> res = new Response<List<DtoParentSubCategory>>();

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = result;
            return res;
        }
    }
}
