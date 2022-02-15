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
    public class CategoryChildGalleryRepository : GenericRepository<ApplicationContext, TblCategoryChildGallery>, ICategoryChildGalleryRepository
    {
        public Response<List<DtoCategoryChildGallery>> GetAllCategoryChildGallery()
        {
            var list = (from q in Context.TblCategoryChildGallery.AsNoTracking().Where(x => x.IsDeleted == null)
                        select new DtoCategoryChildGallery
                        {
                            Id = q.Id,
                            CategoryChildName = q.CategoryChildName,
                            CategoryGalleryId = q.CategoryGallaryId,
                            CategoryGalleryName = q.CategoryGallary.CategoryName
                        }).ToList();

            Response<List<DtoCategoryChildGallery>> res = new Response<List<DtoCategoryChildGallery>>();

            res.code = StaticApiStatus.ApiSaveSuccess.Code;
            res.message = StaticApiStatus.ApiSaveSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSaveSuccess.Status;
            res.IsSuccess = true;
            res.payload = list;

            return res;
        }

        public Response<List<DtoCategoryChildGallery>> GetAllCategoryChildGalleryForDrop()
        {
            var list = (from q in Context.TblCategoryChildGallery.AsNoTracking().Where(x => x.IsDeleted == null)
                        select new DtoCategoryChildGallery
                        {
                            Id = q.Id,
                            CategoryChildName = q.CategoryChildName
                        }).ToList();

            Response<List<DtoCategoryChildGallery>> res = new Response<List<DtoCategoryChildGallery>>();

            res.code = StaticApiStatus.ApiSaveSuccess.Code;
            res.message = StaticApiStatus.ApiSaveSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSaveSuccess.Status;
            res.IsSuccess = true;
            res.payload = list;

            return res;
        }

        public Response<DtoCategoryChildGallery> AddEditCategoryName(DtoCategoryChildGallery dtoCategoryGallery)
        {
            if (dtoCategoryGallery != null)
            {
                if (dtoCategoryGallery.Id > 0)
                {
                    var isExist = FindBy(x => x.Id == dtoCategoryGallery.Id).FirstOrDefault();

                    if (isExist != null)
                    {
                        isExist.CategoryChildName = dtoCategoryGallery.CategoryChildName;
                        isExist.ModifiedDate = DateTime.Now;
                        isExist.CategoryGallaryId = (int)dtoCategoryGallery.CategoryGalleryId;

                        Edit(isExist);
                        Save();

                        dtoCategoryGallery.CategoryGalleryName = Context.TblCategoryGallary.AsNoTracking().Where(x => x.Id == dtoCategoryGallery.CategoryGalleryId).FirstOrDefault().CategoryName;
                    }
                }
                else
                {
                    var category = new TblCategoryChildGallery()
                    {
                        AddedDate = DateTime.Now,
                        CategoryChildName = dtoCategoryGallery.CategoryChildName,
                        CategoryGallaryId =  dtoCategoryGallery.CategoryGalleryId
                    };

                    Add(category);
                    Save();

                    dtoCategoryGallery.Id = category.Id;
                    dtoCategoryGallery.CategoryGalleryName = Context.TblCategoryGallary.AsNoTracking().Where(x => x.Id == dtoCategoryGallery.CategoryGalleryId).FirstOrDefault().CategoryName;
                }
            }

            Response<DtoCategoryChildGallery> res = new Response<DtoCategoryChildGallery>();
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
    }
}
