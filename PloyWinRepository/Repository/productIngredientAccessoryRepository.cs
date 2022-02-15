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
   public class productIngredientAccessoryRepository : GenericRepository<ApplicationContext, TblProductIngredientAccessory>, IproductIngredientAccessoryRepository
    {
        public Response<List<DtoProductIngredientAccessory>> GetAllProductIngredientAccessory()
        {
            var result = (from q in Context.TblProductIngredientAccessory.AsNoTracking().Where(x => x.IsDeleted == null)
                          select new DtoProductIngredientAccessory
                          {
                              Id = q.Id,
                              CountOfItems = q.CountOfItems,
                              ProductId = q.ProductId,
                              ProductName = q.TblProductName.Name,
                              SubCategoryId = q.SubCategoryId,
                              SubCategoryName = q.TblSubCategory.Name
                          }).ToList();

            Response<List<DtoProductIngredientAccessory>> res = new Response<List<DtoProductIngredientAccessory>>();
            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = result;
            return res;
        }

        public Response<List<DtoProductIngredientAccessory>> GetProductIngredientAccessoryByProduct(int id)
        {
            Response<List<DtoProductIngredientAccessory>> res = new Response<List<DtoProductIngredientAccessory>>();

            var result = (from q in Context.TblProductIngredientAccessory.AsNoTracking().Where(x => x.IsDeleted == null && x.ProductId == id)
                          select new DtoProductIngredientAccessory
                          {
                              Id = q.Id,
                              CountOfItems = q.CountOfItems
                          }).ToList();


            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = result;
            return res;
        }

        public Response<List<DtoProductIngredientAccessory>> GetProductIngredientAccessoryBySubCat(int id)
        {
            Response<List<DtoProductIngredientAccessory>> res = new Response<List<DtoProductIngredientAccessory>>();

            var result = (from q in Context.TblProductIngredientAccessory.AsNoTracking().Where(x => x.IsDeleted == null && x.SubCategoryId == id)
                          select new DtoProductIngredientAccessory
                          {
                              Id = q.Id,
                              CountOfItems = q.CountOfItems
                          }).ToList();


            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = result;
            return res;
        }

        public Response<DtoProductIngredientAccessory> AddEditProductIngredientAccessory(DtoProductIngredientAccessory dto)
        {
            Response<DtoProductIngredientAccessory> res = new Response<DtoProductIngredientAccessory>();

            if (dto != null) 
            { 
                if (dto.Id > 0)
                {
                    var isExist = FindBy(x => x.Id == dto.Id).FirstOrDefault();
                    if (isExist != null)
                    { 
                        isExist.CountOfItems = dto.CountOfItems;
                        isExist.ModifiedDate = DateTime.Now;
                        isExist.SubCategoryId = dto.SubCategoryId;
                        isExist.ProductId = dto.ProductId;

                        Edit(isExist);
                        Save();
                        dto.ProductName = Context.TblProductName.AsNoTracking().Where(x => x.Id == dto.ProductId).FirstOrDefault().Name;

                    }
                }

                else
                {
                    var obj = new TblProductIngredientAccessory()
                    {
                        AddedDate = DateTime.Now,
                        CountOfItems = dto.CountOfItems,
                        SubCategoryId = dto.SubCategoryId,
                        ProductId = dto.ProductId
                    };
                    Add(obj);
                    Save();
                    dto.Id = obj.Id;
                    //var productId = Context.TblProducts.AsNoTracking().Where(x => x.Id == dto.ProductId).FirstOrDefault().ProductId;
                    dto.ProductName = Context.TblProductName.AsNoTracking().Where(x => x.Id == dto.ProductId).FirstOrDefault().Name;

                }
            }


            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = dto;
            return res;
        }

        public Response<bool> DeleteProductIngredientAccessory(string Ids)
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
    }
}
