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
    public class DescountRepository : GenericRepository<ApplicationContext, TblDescount>, IDescountRepository
    {
        public Response<List<DtoDescount>> GetAllDescount()
        {
            Response<List<DtoDescount>> res = new Response<List<DtoDescount>>();

            var result = (from q in Context.TblDescount.AsNoTracking().Where(x => x.IsDeleted == null)
                          select new DtoDescount
                          {
                              id = q.Id,
                              descount = q.Descount,
                              typeOfDescount = q.TypeOfDescount,
                              typeOfDescountName = q.TypeOfDescount == 2 ? "الوكيل" : "الورش",
                              typeofCategory = q.TypeOfCategory,
                              typeofCategoryName = q.TblParentProductCategory.CatgoryName, //.TypeOfProduct == 1 ? "قطاعات" : (q.TypeOfProduct == 2 ? "اكسسوارات" : (q.TypeOfProduct == 3 ? "قطاعات أقتصادى" : "الماكينات"))
                              typeDescountName = q.TypeDescount == true ? "نسبة مئوية" : "رقم صحيح"
                          }).ToList();


            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = result;
            return res;
        }

        public List<DtoDescount> GetDescountByType(int? type)
        {
            Response<List<DtoDescount>> res = new Response<List<DtoDescount>>();

            var result = (from q in Context.TblDescount.AsNoTracking().Where(x => x.IsDeleted == null && x.TypeOfDescount == type)
                          select new DtoDescount
                          {
                              id = q.Id,
                              descount = q.Descount,
                              typeOfDescount = q.TypeOfDescount,
                              typeOfDescountName = q.TypeOfDescount == 2 ? "الوكيل" : "الورش",
                              typeofCategory = q.TypeOfCategory,
                              typeofCategoryName = q.TblParentProductCategory.CatgoryName, //TypeOfProduct == 1 ? "قطاعات" : (q.TypeOfProduct == 2 ? "اكسسوارات" : (q.TypeOfProduct == 3 ? "قطاعات أقتصادى" : "الماكينات"))
                              typeDescountName = q.TypeDescount == true ? "نسبة مئوية" : "رقم صحيح"
                          }).ToList();

            return result;
        }

        public Response<DtoDescountEdit> AddEditDescount(DtoDescountEdit dtoDescount)
        { 
            Response<DtoDescountEdit> res = new Response<DtoDescountEdit>();

            if (dtoDescount != null)
            {
                if (dtoDescount.id > 0)
                {
                    var objDescount = FindBy(x => x.Id == dtoDescount.id).FirstOrDefault();

                    if (objDescount != null)
                    {
                        objDescount.Descount = dtoDescount.descount;
                        objDescount.ModifiedDate = DateTime.Now;
                        objDescount.TypeOfDescount = dtoDescount.typeOfDescount;
                        objDescount.TypeOfCategory = dtoDescount.typeofCategory;
                        objDescount.TypeDescount = dtoDescount.typeDescount;


                        Edit(objDescount);
                        Save();

                        dtoDescount.typeDescountName = dtoDescount.typeDescount == true ? "نسبة مئوية" : "رقم صحيح";
                        dtoDescount.typeOfDescountName = dtoDescount.typeOfDescount == 2 ? "الوكيل" : "الورش";
                        dtoDescount.typeofCategoryName = Context.TblParentProductCategory.AsNoTracking().Where(x => x.Id == dtoDescount.typeofCategory).FirstOrDefault().CatgoryName;
                    }
                }
                else
                {
                    TblDescount obj = new TblDescount()
                    {
                        Descount = dtoDescount.descount,
                        AddedDate = DateTime.Now,
                        TypeOfCategory = dtoDescount.typeofCategory,
                        TypeOfDescount = dtoDescount.typeOfDescount,
                        TypeDescount = dtoDescount.typeDescount
                    };

                    Add(obj);
                    Save();

                    dtoDescount.typeDescountName = dtoDescount.typeDescount == true ? "نسبة مئوية" : "رقم صحيح";
                    dtoDescount.typeOfDescountName = dtoDescount.typeOfDescount == 2 ? "الوكيل" : "الورش";
                    dtoDescount.typeofCategoryName = Context.TblParentProductCategory.AsNoTracking().Where(x => x.Id == dtoDescount.typeofCategory).FirstOrDefault().CatgoryName;
                }
            }

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = dtoDescount;
            return res;
        }

        public Response<bool> AddDescount(DtoDescountAdded dtoDescount)
        {
            bool result = false;
            Response<bool> res = new Response<bool>();

            if (dtoDescount != null)
            {
                TblDescount obj = new TblDescount()
                {
                    Descount = dtoDescount.descount,
                    AddedDate = DateTime.Now,
                    TypeOfCategory = dtoDescount.typeofProduct,
                    TypeOfDescount = dtoDescount.typeOfDescount,
                    TypeDescount = dtoDescount.typeDescount
                };

                Add(obj);
                Save();

                result = true;

            }

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = result;
            return res;
        }

        public Response<bool> DeleteDescount(string id)
        {
            var listId = id.Split(',').ToList();

            bool dd = false;

            foreach (var item in listId)
            {
                var result = FindBy(x => x.Id == Convert.ToInt32(item)).FirstOrDefault();

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
