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
    public class CategoryRepository : GenericRepository<ApplicationContext, TblCategory>, ICategoryRepository
    {
        public Response<List<DTOCategory>> GetAllCategory()
        {
            Response<List<DTOCategory>> res = new Response<List<DTOCategory>>();

            var result = (from q in Context.TblCategory.AsNoTracking().Where(x => x.IsDeleted == null)
                          select new DTOCategory
                          {
                              id = q.Id,
                              categoryName = q.CategoryName,
                              typeOfCategoryName = q.TblParentProductCategory.CatgoryName, // == 1 ? "قطاعات" : (q.TypeOfCategory == 2 ? "إكسسوارات" : (q.TypeOfCategory == 3 ? "قطاعات الأقتصادى" : "الماكينات"))
                              typeOfCategoryId = q.TypeOfCategory
                          }).ToList();

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            res.payload = result;
            return res;

        }


        public Response<List<DTOCategory>> GetAllCategoryForDrop()
        {
            Response<List<DTOCategory>> res = new Response<List<DTOCategory>>();

            var result = (from q in Context.TblCategory.AsNoTracking().Where(x => x.IsDeleted == null)
                          select new DTOCategory
                          {
                              id = q.Id,
                              categoryName = q.CategoryName 
                          }).ToList();

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            res.payload = result;
            return res;

        }

        public Response<List<DTOCategoryNamed>> GetCategoryType()
        {
            var result = new List<DTOCategoryNamed>()
            {
                new DTOCategoryNamed(){id = 1 ,typeOfCategoryName ="قطاعات"},
                new DTOCategoryNamed(){id = 2 ,typeOfCategoryName ="إكسسوارات"},
                new DTOCategoryNamed(){id = 3 ,typeOfCategoryName ="قطاعات الأقتصادى"},
                new DTOCategoryNamed(){id = 4 ,typeOfCategoryName ="الماكينات"},
            };

            Response<List<DTOCategoryNamed>> res = new Response<List<DTOCategoryNamed>>();

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            res.payload = result;
            return res;
        }

        public async Task<Response<List<DTOCategory>>> GetAllCategoryWithProduct()
        {
            Response<List<DTOCategory>> res = new Response<List<DTOCategory>>();

            var result = await (from q in Context.TblCategory.AsNoTracking().Where(x => x.IsDeleted == null)
                                let products = (from x in Context.TblProducts.Where(x => x.CategoryId == q.Id && x.IsDeleted == null)
                                                select new DtoProducts
                                                {
                                                    id = x.Id,
                                                    name = x.Name,
                                                    imgURL = x.TblProductName.ImgURL,
                                                    totalQuota = x.TotalQuota,
                                                    productCode = x.ProductCode,
                                                    //price = x.Price
                                                }).ToList()
                                select new DTOCategory
                                {
                                    id = q.Id,
                                    categoryName = q.CategoryName,
                                    Products = products
                                }).ToListAsync();

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            res.payload = result;
            return res;

        }

        public Response<DTOCategoryAddEdit> AddEditCategory(DTOCategoryAddEdit dTOCategoryAddEdit)
        {
            Response<DTOCategoryAddEdit> res = new Response<DTOCategoryAddEdit>();

            if (dTOCategoryAddEdit != null)
            {
                if (dTOCategoryAddEdit.id > 0)
                {
                    var obj = FindBy(x => x.Id == dTOCategoryAddEdit.id).FirstOrDefault();

                    if (obj != null)
                    {
                        obj.TypeOfCategory = dTOCategoryAddEdit.typeOfCategory;
                        obj.CategoryName = dTOCategoryAddEdit.categoryName;
                        obj.ModifiedDate = DateTime.Now;

                        Edit(obj);
                        Save();

                        dTOCategoryAddEdit.typeOfCategoryName = Context.TblParentProductCategory.AsNoTracking().Where(x => x.Id == dTOCategoryAddEdit.typeOfCategory).FirstOrDefault().CatgoryName;
                    }
                }
                else
                {
                    var obj = new TblCategory()
                    {
                        CategoryName = dTOCategoryAddEdit.categoryName,
                        TypeOfCategory = dTOCategoryAddEdit.typeOfCategory,
                        AddedDate = DateTime.Now
                    };

                    Add(obj);
                    Save();

                    dTOCategoryAddEdit.id = obj.Id;
                    dTOCategoryAddEdit.typeOfCategoryName = Context.TblParentProductCategory.AsNoTracking().Where(x => x.Id == dTOCategoryAddEdit.typeOfCategory).FirstOrDefault().CatgoryName;
                }
            }

            res.code = StaticApiStatus.ApiSaveSuccess.Code;
            res.message = StaticApiStatus.ApiSaveSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSaveSuccess.Status;
            res.payload = dTOCategoryAddEdit;
            return res;
        }

        public Response<bool> DeleteCategory(string Ids)
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

        public Response<List<DtoGroupCategoryWithProduct>> GetParenrCategorywithProduct(ApplicationUser user)
        {
            Response<List<DtoGroupCategoryWithProduct>> res = new Response<List<DtoGroupCategoryWithProduct>>();

            var result = (from q in Context.TblParentProductCategory.AsNoTracking().Where(x => x.IsDeleted == null)
                          select new DtoGroupCategoryWithProduct
                          {
                              Id = q.Id,
                              ParentCategory = q.CatgoryName,
                              haveIron = q.haveIron
                          }).ToList();

            var descount = (from q in Context.TblDescount.AsNoTracking().Where(x => x.TypeOfDescount == user.UserType && x.IsDeleted == null) select q).ToList();

            foreach (var item in result)
            {
                var listCategory = (from q in Context.TblCategory.AsNoTracking().Where(x => x.TypeOfCategory == item.Id && x.IsDeleted == null)
                                    select new DTOCategory
                                    {
                                        id = q.Id,
                                        categoryName = q.CategoryName
                                    }).ToList();

                if (listCategory.Count() > 0)
                {
                    item.ListCategory = listCategory;

                    foreach (var _product in item.ListCategory)
                    {
                        var products = (from q in Context.TblProducts.AsNoTracking().Where(x => x.CategoryId == _product.id && x.IsDeleted == null)
                                        select new DtoProducts
                                        {
                                            id = q.Id,
                                            categoryId = q.TblCategory.Id,
                                            categoryName = q.TblCategory.CategoryName,
                                            name = q.TblProductName.Name,
                                            imgURL = q.TblProductName.ImgURL,
                                            totalQuota = q.TotalQuota,
                                            productCode = q.ProductCode,
                                            measruingUnit = q.MeasruingUnit,
                                            pricePerMeter = q.PricePerMeter,
                                            pricePerOne = q.PricePerOne,
                                            TypeOfCategory = q.TblCategory.TypeOfCategory,
                                            colorName= q.TblColors.ColorName
                                        }).ToList();

                        if (products.Count() > 0)
                        {
                            foreach (var product in products)
                            {
                                product.Descount = descount.Where(x => x.TypeOfCategory == product.TypeOfCategory ).Select(x => x.Descount).FirstOrDefault();
                            }

                            _product.Products = products;
                        }
                    }
                }
                else
                {
                    item.ListCategory = new List<DTOCategory>();
                }
            }

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            res.payload = result;
            return res;
        }
        public Response<List<DtoGroupCategoryWithProduct>> GetParentCategorywithProductForWebApp()
        {
            Response<List<DtoGroupCategoryWithProduct>> res = new Response<List<DtoGroupCategoryWithProduct>>();

            var result = (from q in Context.TblParentProductCategory.AsNoTracking().Where(x => x.IsDeleted == null)
                          select new DtoGroupCategoryWithProduct
                          {
                              Id = q.Id,
                              ParentCategory = q.CatgoryName
                          }).ToList();

            var descount = (from q in Context.TblDescount.AsNoTracking().Where(x => x.TypeOfDescount == 4) select q).ToList();

            foreach (var item in result)
            {
                var listCategory = (from q in Context.TblCategory.AsNoTracking().Where(x => x.TypeOfCategory == item.Id)
                                    select new DTOCategory
                                    {
                                        id = q.Id,
                                        categoryName = q.CategoryName
                                    }).ToList();

                if (listCategory.Count() > 0)
                {
                    item.ListCategory = listCategory;

                    foreach (var _product in item.ListCategory)
                    {
                        var products = (from q in Context.TblProducts.AsNoTracking().Where(x => x.CategoryId == _product.id)
                                        select new DtoProducts
                                        {
                                            id = q.Id,
                                            categoryId = q.TblCategory.Id,
                                            categoryName = q.TblCategory.CategoryName,
                                            name = q.TblProductName.Name,
                                            imgURL = q.TblProductName.ImgURL,
                                            totalQuota = q.TotalQuota,
                                            productCode = q.ProductCode,
                                            measruingUnit = q.MeasruingUnit,
                                            pricePerMeter = q.PricePerMeter,
                                            pricePerOne = q.PricePerOne,
                                            TypeOfCategory = q.TblCategory.TypeOfCategory
                                        }).ToList();

                        if (products.Count() > 0)
                        {
                            foreach (var product in products)
                            {
                                product.Descount = descount.Where(x => x.TypeOfCategory == product.TypeOfCategory).Select(x => x.Descount).FirstOrDefault();
                            }

                            _product.Products = products;
                        }
                    }
                }
                else
                {
                    item.ListCategory = new List<DTOCategory>();
                }
            }

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            res.payload = result;
            return res;
        }
    }
}
