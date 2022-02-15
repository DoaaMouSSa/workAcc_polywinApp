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
    public class StoreRepository : GenericRepository<ApplicationContext, TblStores>, IStoreRepository
    {
        public Response<List<DtoStores>> GetAllStore(ApplicationUser user)
        {
            Response<List<DtoStores>> res = new Response<List<DtoStores>>();
            var result = (from q in Context.TblStores.AsNoTracking().Where(x => x.IsDeleted == null)
                          select new DtoStores
                          {
                              id=q.Id,
                              productId=q.ProductId,
                              ProductIdName=q.ProductIdName,
                              productName =q.TblProductName.Name,
                              productCode=q.TblProducts.ProductCode,
                              quantity=q.Quantity,
                          }).ToList();
                              res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = result;
            return res;
        }
        public Response<List<DtoStoresGroupBy>> GetAllStoreByUserId(ApplicationUser user)
        {
            Response<List<DtoStoresGroupBy>> res = new Response<List<DtoStoresGroupBy>>();
            
            List<DtoStoresGroupBy> empjon = new List<DtoStoresGroupBy>();

            var listProduct = FindBy(x => x.UserId == user.Id).Select(x =>
            new
            {
                CategoryName = x.TblProducts.TblCategory.CategoryName,
                productId = x.ProductId,
                productCode = x.TblProducts.ProductCode,
                productImg = x.TblProducts.TblProductName.ImgURL,
                productName = x.TblProducts.TblProductName.Name,
                quantity = x.Quantity,
                pricePerOne = x.TblProducts.PricePerOne,
                pricePerMeter = x.TblProducts.PricePerMeter,
            }).ToList();

            if (listProduct.Count() > 0)
            {
                var groupByCategory = from prod in listProduct
                                      group prod by prod.CategoryName
                                                           into egroup
                                      orderby egroup.Key
                                      select new
                                      {
                                          CategoryName = egroup.Key,
                                          ProductList = egroup.ToList()
                                      };


                foreach (var item in groupByCategory)
                {
                    DtoStoresGroupBy obj = new DtoStoresGroupBy();

                    obj.categoryName = item.CategoryName;
                    obj.ListProduct = new List<DtoStores>();

                    foreach (var Product in item.ProductList)
                    {
                        DtoStores store = new DtoStores()
                        {
                            productId = Product.productId,
                            productCode = Product.productCode,
                            productImg = Product.productImg,
                            productName = Product.productName,
                            quantity = Product.quantity,
                            pricePerOne = Product.pricePerOne,
                            pricePerMeter = Product.pricePerMeter,
                            totalPriceProduct = Math.Round((decimal)(Product.quantity * Product.pricePerOne), 2)
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
    
        public bool AddProductToStore(DtoToAddToStore dtoStores, ApplicationUser user)
        {
            if (dtoStores != null)
            {
                var obj = new TblStores()
                {
                    ProductId = dtoStores.product_id,
                    AddedDate = DateTime.Now,
                    ProductIdName= dtoStores.productname_id,
                    Quantity = dtoStores.quantity,
                    UserId = user.Id
                };

                Add(obj); 
                Save();
            }

            return false;
        }
        public bool AddProductToStoreAfterPurchase(DtoStoreFromPurchase dtoStores)
        {
            if (dtoStores != null)
            {
                var obj = new TblStores()
                {
                    AddedDate = DateTime.Now,
                    ProductIdName = dtoStores.productname_id,
                    Quantity = dtoStores.quantity,
                };

                Add(obj);
                Save();
            }

            return false;
        }

    }
}
