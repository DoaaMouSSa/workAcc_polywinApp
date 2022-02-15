using IPloyWinRepository.InterFace;
using Microsoft.Data.SqlClient;
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
    public class ProductsRepository : GenericRepository<ApplicationContext, TblProducts>, IProductsRepository
    {
        public async Task<Response<List<DtoProducts>>> GetAllProduct()
        {
            Response<List<DtoProducts>> res = new Response<List<DtoProducts>>();

            var result = (from q in Context.TblProducts.AsNoTracking().Where(x => x.IsDeleted == null)
                          select new DtoProducts
                          {
                              id = q.Id,
                              categoryId = q.TblCategory.Id,
                              categoryName = q.TblCategory.CategoryName,
                              name = q.TblProductName.Name,
                              ProductId = q.ProductId,
                              totalQuota = q.TotalQuota,
                              productCode = q.ProductCode,
                              measruingUnit = q.MeasruingUnit,
                              pricePerMeter = q.PricePerMeter,
                              pricePerOne = q.PricePerOne,
                              colorId = q.ColorId,
                              colorName = q.TblColors.ColorName
                          }).ToList();

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageEn;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            res.payload = result;
            return res;
        }

        public Response<List<DtoProductGroup>> GetAllProductPerCategory(int type)
        {
            Response<List<DtoProductGroup>> res = new Response<List<DtoProductGroup>>();

            List<DtoProductGroup> empjon = new List<DtoProductGroup>();

            var listProduct = FindBy(x => x.IsDeleted == null).Select(x => new
            {
                id = x.Id,
                productCode = x.ProductCode,
                imgURL = x.TblProductName.ImgURL,
                colorName = x.TblColors.ColorName,
                name = x.TblProductName.Name,
                pricePerOne = x.PricePerOne,
                pricePerMeter = x.PricePerMeter,
                measruingUnit = x.MeasruingUnit,
                NumberIron = 0,
                ParentCategory = x.TblCategory.TblParentProductCategory.Id,
                TypeOfCategory = x.TblCategory.CategoryName
            }).ToList();

            if (listProduct.Count() > 0)
            {
                var groupByCategory = from prod in listProduct
                                      group prod by prod.TypeOfCategory
                                                           into egroup
                                      orderby egroup.Key
                                      select new
                                      {
                                          TypeOfCategory = egroup.Key,
                                          ProductList = egroup.ToList()
                                      };

                foreach (var item in groupByCategory)
                {
                    DtoProductGroup obj = new DtoProductGroup();

                    obj.CategoryName = item.TypeOfCategory; //== 1 ? "قطاعات" : (item.TypeOfCategory == 2 ? "أكسسوارات" : (item.TypeOfCategory == 3 ? "قطاعات اقتصادى" : "الماكينات"));
                    obj.ListProduct = new List<DtoProducts>();

                    foreach (var Product in item.ProductList)
                    {
                        var Descount = Context.TblDescount.Where(x => x.TypeOfCategory == Product.ParentCategory && x.TypeOfDescount == type).Select(x => new { Descount = x.Descount, TypeDescount = x.TypeDescount }).FirstOrDefault();

                        DtoProducts store = new DtoProducts()
                        {
                            id = Product.id,
                            productCode = Product.productCode,
                            imgURL = Product.imgURL,
                            colorName = Product.colorName,
                            name = Product.name,
                            pricePerOne = Product.pricePerOne,
                            pricePerMeter = Product.pricePerMeter,
                            measruingUnit = Product.measruingUnit,
                            NumberIron = 0,
                            Descount = Descount != null ? Descount.Descount : 0,
                            TypeDescount = Descount != null ? (Descount.TypeDescount == true ? "نسبة مئوية" : "رقم صحيح") : ""
                        };

                        obj.ListProduct.Add(store);
                    }

                    empjon.Add(obj);
                }
            }

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = empjon;
            return res;
        }

        public async Task<Response<DtoProducts>> AddEditProduct(DtoProducts dtoProducts)
        {
            Response<DtoProducts> res = new Response<DtoProducts>();

            if (dtoProducts != null)
            {
                if (dtoProducts.id > 0)
                {
                    var isExist = FindBy(x => x.Id == dtoProducts.id).FirstOrDefault();
                    if (isExist != null)
                    {
                        isExist.ProductCode = dtoProducts.productCode;
                        isExist.CategoryId = dtoProducts.categoryId;
                        isExist.PricePerOne = dtoProducts.pricePerOne;
                        isExist.TotalQuota = dtoProducts.totalQuota;
                        isExist.MeasruingUnit = dtoProducts.measruingUnit;
                        isExist.PricePerMeter = dtoProducts.pricePerMeter;
                        isExist.ProductId = dtoProducts.ProductId;
                        isExist.ColorId = dtoProducts.colorId;
                        Edit(isExist);
                        Save();

                        dtoProducts.categoryName = Context.TblCategory.AsNoTracking().Where(x => x.Id == dtoProducts.categoryId).FirstOrDefault().CategoryName;
                        dtoProducts.colorName = Context.TblColors.AsNoTracking().Where(x => x.Id == dtoProducts.colorId).FirstOrDefault().ColorName;
                        dtoProducts.name = Context.TblProductName.AsNoTracking().Where(x => x.Id == dtoProducts.ProductId).FirstOrDefault().Name;
                    }
                }
                else
                {
                    var objProduct = new TblProducts()
                    {
                        AddedDate = DateTime.Now,
                        ProductCode = dtoProducts.productCode,
                        CategoryId = dtoProducts.categoryId,
                        PricePerOne = dtoProducts.pricePerOne,
                        TotalQuota = dtoProducts.totalQuota,
                        MeasruingUnit = dtoProducts.measruingUnit,
                        PricePerMeter = dtoProducts.pricePerMeter,
                        ProductId = dtoProducts.ProductId,
                        ColorId = dtoProducts.colorId
                    };

                    Add(objProduct);
                    Save();

                    dtoProducts.id = objProduct.Id;
                    dtoProducts.categoryName = Context.TblCategory.AsNoTracking().Where(x => x.Id == dtoProducts.categoryId).FirstOrDefault().CategoryName;
                    dtoProducts.colorName = Context.TblColors.AsNoTracking().Where(x => x.Id == dtoProducts.colorId).FirstOrDefault().ColorName;
                    dtoProducts.name = Context.TblProductName.AsNoTracking().Where(x => x.Id == dtoProducts.ProductId).FirstOrDefault().Name;
                }
            }

            res.code = StaticApiStatus.ApiSaveSuccess.Code;
            res.message = StaticApiStatus.ApiSaveSuccess.MessageEn;
            res.status = StaticApiStatus.ApiSaveSuccess.Status;
            res.IsSuccess = true;
            res.payload = dtoProducts;
            return res;
        }

        public async Task<Response<List<DtoProducts>>> SearchProduct(string search, int usertype)
        {

            Response<List<DtoProducts>> res = new Response<List<DtoProducts>>();
            search = search == null ? "" : search;
            var result = (from q in Context.TblProducts.AsNoTracking().Where(x => x.IsDeleted == null && (x.TblProductName.Name.Contains(search) || x.ProductCode.Contains(search)))
                          select new DtoProducts
                          {
                              id = q.Id,
                              colorId = q.ColorId,
                              colorName = q.TblColors.ColorName,
                              categoryId = q.TblCategory.Id,
                              categoryName = q.TblCategory.CategoryName,
                              name = q.TblProductName.Name,
                              imgURL = q.TblProductName.ImgURL,
                              totalQuota = q.TotalQuota,
                              productCode = q.ProductCode,
                              measruingUnit = q.MeasruingUnit,
                              pricePerMeter = q.PricePerMeter,
                              pricePerOne = q.PricePerOne,
                              TypeOfCategory = q.TblCategory.TblParentProductCategory.Id,
                              ProductName = q.TblProductName.Name
                          }).ToList();



            foreach (var item in result)
            {
                var descount = Context.TblDescount.Where(x => x.TypeOfDescount == usertype && x.TypeOfCategory == item.TypeOfCategory).Select(x => new { x.Descount, x.TypeDescount }).FirstOrDefault();
                if (descount != null)
                {
                    item.Descount = descount.Descount;
                    item.TypeDescount = descount.TypeDescount == true ? "نسبة مئوية" : "رقم صحيح";
                }
            }

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageEn;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            res.payload = result;
            return res;
        }

        public Response<bool> DeleteProduct(string Ids)
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


        public Response<List<DtoProductsForDrop>> GetAllProductWithColor()
        {
            var result = (from q in Context.TblProductName.AsNoTracking().Where(x => x.IsDeleted == null)
                          select new DtoProductsForDrop
                          {
                              Id = q.Id,
                              ProductName = q.Name //+ " - " + q.TblColors.ColorName
                          }).ToList();

            Response<List<DtoProductsForDrop>> res = new Response<List<DtoProductsForDrop>>();
            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = result;
            return res;

        }
        public Response<List<DtoProductsWithColorGroup>> GetAllProductWithColorForShow()
        {
            Response<List<DtoProductsWithColorGroup>> res = new Response<List<DtoProductsWithColorGroup>>();

            var result = (from q in Context.TblProducts.AsNoTracking().Where(x => x.IsDeleted == null)
                          select new DtoProductsWithColor
                          {
                              ProductName = q.TblProductName.Name,
                              productCode = q.ProductCode,
                              ProductColor = q.TblColors.ColorName,
                              ProductImg = q.TblProductName.ImgURL,
                          }).ToList();
            if (result.Count() > 0)
            {
                var ProColors = (from query in result
                                 group query by query.productCode
                                         into egroup
                                 orderby egroup.Key
                                 select new DtoProductsWithColorGroup
                                 {
                                     productCode = egroup.Key,
                                     AllPro = egroup.ToList()
                                 }).ToList();

                res.code = StaticApiStatus.ApiSuccess.Code;
                res.message = StaticApiStatus.ApiSuccess.MessageAr;
                res.status = StaticApiStatus.ApiSuccess.Status;
                res.payload = ProColors;

            }
            return res;

        }
    }
}
