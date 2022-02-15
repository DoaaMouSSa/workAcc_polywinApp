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
    public class CategoryTypeRepository : GenericRepository<ApplicationContext, TblCategoryType>, ICategoryTypeRepository
    {
        public Response<List<DtoCategoryType>> GetAllCategoryType()
        {
            Response<List<DtoCategoryType>> res = new Response<List<DtoCategoryType>>();

            var result = (from q in Context.TblCategoryType.AsNoTracking().Where(x => x.IsDeleted == null)
                          select new DtoCategoryType
                          {
                              id = q.Id,
                              name = q.TypeName
                          }).ToList();

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            res.payload = result;
            return res;
        }

        public Response<bool> AddEditCategoryType(DtoCategoryType dto)
        {
            Response<bool> res = new Response<bool>();

            bool result = false;

            if (dto != null)
            {
                if (dto.id > 0)
                {
                    var isExist = FindBy(x => x.Id == dto.id).FirstOrDefault();

                    if (isExist != null)
                    {
                        isExist.TypeName = dto.name;
                        isExist.ModifiedDate = DateTime.Now;

                        Edit(isExist);
                        Save();

                        result = true;
                    }
                }
                else
                {
                    var objType = new TblCategoryType()
                    {
                        Id = dto.id,
                        TypeName = dto.name,
                        AddedDate = DateTime.Now
                    };

                    Add(objType);
                    Save();

                    result = true;
                }
            }

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            res.payload = result;
            return res;
        }

        public Response<bool> DeleteCategoryType(string Ids)
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

        public Response<List<DtoCategoryTypeWithChild>> GetAllCategoryGallery()
        {
            Response<List<DtoCategoryTypeWithChild>> res = new Response<List<DtoCategoryTypeWithChild>>();

            var result = (from q in Context.TblCategoryType.AsNoTracking().Where(x => x.IsDeleted == null)
                          select new DtoCategoryTypeWithChild
                          {
                              id = q.Id,
                              name = q.TypeName,
                              listCategoryGallery = q.TblCategoryGallaries.Where(x => x.IsDeleted == null).Select(x =>
                                 new DtoCategoryGalleryViewModal
                                 {
                                     id = x.Id,
                                     name = x.CategoryName,
                                     ListGallery = x.TblCategoryChildGallery.Where(x => x.IsDeleted == null).Select(x =>
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
                                 }).ToList()
                          }).ToList();


            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            res.payload = result;
            return res;
        }
        public Response<List<DtoCategoryGalleryViewModal>> GetAllCategoryGalleryById(int id)
        {
            Response<List<DtoCategoryGalleryViewModal>> res = new Response<List<DtoCategoryGalleryViewModal>>();
            //var cat = from q in Context.TblCategoryGallary.AsNoTracking().Where(x => x.IsDeleted == null && x.Id == id).FirstOrDefault();
            //var result = (from q in Context.TblCategoryGallary.AsNoTracking().Where(x => x.IsDeleted == null && x.Id == id).FirstOrDefault().Select(x =>

            //                       new DtoCategoryGalleryViewModal
            //                       {
                                  
            //                           id = x.Id,
            //                           name = x.CategoryName,
            //                           ListGallery = x.TblCategoryChildGallery.Where(x => x.IsDeleted == null).Select(x =>
            //                  new DtoChildCategoryGallery
            //                  {
            //                      Id = x.Id,
            //                      CategoryChildName = x.CategoryChildName, //باب مفصلى
            //                    filePath = x.filePath,
            //                      Gallery = x.TblGallery.Where(s => s.IsDeleted == null).Select(c =>
            //                        new DtoGalleryViewModales
            //                        {
            //                            Id = c.Id,
            //                            Description = c.Description,
            //                            GalleryType = c.TypeGallery,
            //                            PathImage = c.ImageGallery
            //                        }
            //                        ).ToList()
            //                  }).ToList()
            //                       }).ToList();


            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            //res.payload = result;
            return res;
        }
    }
}
