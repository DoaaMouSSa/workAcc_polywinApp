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
    public class ProductNameRepository : GenericRepository<ApplicationContext, TblProductName>, IProductNameRepository
    {

        public Response<List<DtoProductName>> GetAllProductName()
        {
            Response<List<DtoProductName>> res = new Response<List<DtoProductName>>();

            var result = (from q in Context.TblProductName.AsNoTracking().Where(x => x.IsDeleted == null)
                          select new DtoProductName
                          {
                              Id = q.Id,
                              ProductName = q.Name,
                              ImgURL = q.ImgURL
                          }).ToList();

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            res.payload = result;
            return res;
        }

        public Response<DtoProductName> AddEditProductName(DtoProductName dto)
        {
            if (dto != null)
            {
                if (dto.Id > 0)
                {
                    var isExist = FindBy(x => x.Id == dto.Id).FirstOrDefault();

                    if (isExist != null)
                    {
                        isExist.Name = dto.ProductName;
                        if (dto.fileUpload != null)
                        {
                            isExist.ImgURL = dto.ImgURL;
                        }
                        isExist.ModifiedDate = DateTime.Now;

                        Edit(isExist);
                        Save();

                        dto.ImgURL = isExist.ImgURL;
                    }
                }
                else
                {
                    var objProduct = new TblProductName()
                    {
                        AddedDate = DateTime.Now,
                        Name = dto.ProductName,
                        ImgURL = dto.ImgURL
                    };

                    Add(objProduct);
                    Save();

                    dto.Id = objProduct.Id;
                    
                }
            }

            Response<DtoProductName> res = new Response<DtoProductName>();

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            res.payload = dto;
            return res;
        }

        public Response<bool> DeleteProductName(string Ids)
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
        // public Response<DtoProductNameWithCatAndCode> AddEditProductTest(DtoProductNameWithCatAndCode dto)
        //{
        //    if (dto != null)
        //    {
        //        if (dto.Id > 0)
        //        {
        //            var isExist = FindBy(x => x.Id == dto.Id).FirstOrDefault();

        //        if (isExist != null)
        //            {
        //isExist.Name = dto.ProductName;
        //if (dto.fileUpload != null)
        //{
        //    isExist.ImgURL = dto.ImgURL;
        //}
        //isExist.ModifiedDate = DateTime.Now;

        //Edit(isExist);
        //Save();

        //dto.ImgURL = isExist.ImgURL;
        //            }
        //        }
        //        else
        //        {
        //            //add product
        //            //add product name

        //            var objProduct = new TblProductName()
        //            {
        //                AddedDate = DateTime.Now,
        //                Name = dto.ProductName,
        //                ImgURL = dto.imgURL
        //            };

        //            Add(objProduct);
        //            Save();

        //            dto.Id = objProduct.Id;
        //            var id = objProduct.Id;
        //            var objProductDetails = new TblProducts()
        //            {
        //                ProductCode=dto.productCode,
        //                CategoryId=dto.categoryId
        //            };

        //            Add(objProductDetails);
        //            Save();
        //        }
        //    }

        //    Response<DtoProductNameWithCatAndCode> res = new Response<DtoProductNameWithCatAndCode>();

        //    res.code = StaticApiStatus.ApiSuccess.Code;
        //    res.message = StaticApiStatus.ApiSuccess.MessageAr;
        //    res.status = StaticApiStatus.ApiSuccess.Status;
        //    res.IsSuccess = true;
        //    res.payload = dto;
        //    return res;
        //}
        public Response<List<DtoProductNameWithCatAndCode>> GetAllProductNameCodeCat()
        {
            Response<List<DtoProductNameWithCatAndCode>> res = new Response<List<DtoProductNameWithCatAndCode>>();

            var result =
    (from pro in Context.TblProductName.AsNoTracking().Where(p=>p.IsDeleted==null)
     join proDetails in Context.TblProducts on pro.Id equals proDetails.ProductId
     select new DtoProductNameWithCatAndCode
     {
         Id = pro.Id,
         ProductName = pro.Name,
         ImgURL = pro.ImgURL,
         productCode = proDetails.ProductCode,
         categoryId = proDetails.TblCategory.Id,
         categoryName = proDetails.TblCategory.CategoryName
     }).ToList();

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            res.payload = result;
            return res;
        }
    }
}
