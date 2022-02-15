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
    public class CategoryGalleryRepository : GenericRepository<ApplicationContext, TblCategoryGallary>, ICategoryGalleryRepository
    {
        public Response<List<DtoCategoryGallery>> GetAllCategoryGallery()
        {
            var list = (from q in Context.TblCategoryGallary.AsNoTracking().Where(x => x.IsDeleted == null)
                        select new DtoCategoryGallery
                        {
                            Id = q.Id,
                            CategoryName = q.CategoryName,
                            CategoryTypeId = q.CategoryTypeId,
                            CategoryTypeName = q.TblCategoryType.TypeName
                        }).ToList();

            Response<List<DtoCategoryGallery>> res = new Response<List<DtoCategoryGallery>>();

            res.code = StaticApiStatus.ApiSaveSuccess.Code;
            res.message = StaticApiStatus.ApiSaveSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSaveSuccess.Status;
            res.IsSuccess = true;
            res.payload = list;

            return res;
        }
        public Response<List<DtoCategoryGallery>> GetAllCategoryGalleryForDrop()
        {
            var list = (from q in Context.TblCategoryGallary.AsNoTracking().Where(x => x.IsDeleted == null)
                        select new DtoCategoryGallery
                        {
                            Id = q.Id,
                            CategoryName = q.CategoryName
                        }).ToList();

            Response<List<DtoCategoryGallery>> res = new Response<List<DtoCategoryGallery>>();

            res.code = StaticApiStatus.ApiSaveSuccess.Code;
            res.message = StaticApiStatus.ApiSaveSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSaveSuccess.Status;
            res.IsSuccess = true;
            res.payload = list;

            return res;
        }

        public Response<DtoCategoryGallery> AddEditCategoryName(DtoCategoryGallery dtoCategoryGallery)
        {
            if (dtoCategoryGallery != null)
            {
                if (dtoCategoryGallery.Id > 0)
                {
                    var isExist = FindBy(x => x.Id == dtoCategoryGallery.Id).FirstOrDefault();

                    if (isExist != null)
                    {
                        isExist.CategoryName = dtoCategoryGallery.CategoryName;
                        isExist.ModifiedDate = DateTime.Now;
                        isExist.CategoryTypeId = (int)dtoCategoryGallery.CategoryTypeId;

                        Edit(isExist);
                        Save();

                        dtoCategoryGallery.CategoryTypeName = Context.TblCategoryType.AsNoTracking().Where(x => x.Id == dtoCategoryGallery.CategoryTypeId).FirstOrDefault().TypeName;
                    }
                }
                else
                {
                    var category = new TblCategoryGallary()
                    {
                        AddedDate = DateTime.Now,
                        CategoryName = dtoCategoryGallery.CategoryName,
                        CategoryTypeId = (int)dtoCategoryGallery.CategoryTypeId
                    };

                    Add(category);
                    Save();

                    dtoCategoryGallery.Id = category.Id;
                    dtoCategoryGallery.CategoryTypeName = Context.TblCategoryType.AsNoTracking().Where(x => x.Id == dtoCategoryGallery.CategoryTypeId).FirstOrDefault().TypeName;
                }
            }

            Response<DtoCategoryGallery> res = new Response<DtoCategoryGallery>();
            res.code = StaticApiStatus.ApiSaveSuccess.Code;
            res.message = StaticApiStatus.ApiSaveSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSaveSuccess.Status;
            res.IsSuccess = true;
            res.payload = dtoCategoryGallery;

            return res;
        }

        public Response<bool> DeleteCategoryName(string Ids)
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

        public Response<List<DtoCategoryGalleryViewModal>> GetCategoryWithFile()
        {
            Response<List<DtoCategoryGalleryViewModal>> res = new Response<List<DtoCategoryGalleryViewModal>>();

            var result = (from q in Context.TblCategoryGallary.AsNoTracking().Where(x => x.IsDeleted == null)
                          select new DtoCategoryGalleryViewModal
                          {
                              id = q.Id,
                              name = q.CategoryName,
                              ListGallery = q.TblCategoryChildGallery.Where(x => x.IsDeleted == null).Select(x =>
                              new DtoChildCategoryGallery
                              {
                                  Id = x.Id,
                                  CategoryChildName = x.CategoryChildName,
                                  filePath = x.filePath,
                                  Gallery = x.TblGallery.Where(s => s.IsDeleted == null).Select(c =>
                                    new DtoGalleryViewModales
                                    {
                                        Id = c.Id,
                                        Description = c.Description,
                                        GalleryType = c.TypeGallery,
                                        PathImage = c.ImageGallery
                                    }
                                    ).ToList()
                              }).ToList()
                          }).ToList();

            res.code = StaticApiStatus.ApiSaveSuccess.Code;
            res.message = StaticApiStatus.ApiSaveSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSaveSuccess.Status;
            res.IsSuccess = true;
            res.payload = result;

            return res;
        }
    }
}
