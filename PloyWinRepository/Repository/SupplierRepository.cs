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
    public class SupplierRepository : GenericRepository<ApplicationContext, TblSupplier>, ISupplierRepository
    {
        //public async Task<Response<bool>> AddNewSupplier(DtoSupplier dtoSupplier,ApplicationUser user)
        //{
        //    Response<bool> res = new Response<bool>();
        //    bool result = false;
        //    if (dtoSupplier != null)
        //    {
        //        var objSupplier = new TblSupplier()
        //        {
        //            Name = dtoSupplier.Name,
        //            AddedDate = DateTime.Now,
        //            SupplierCode = dtoSupplier.SupplierCode,
        //            SupplierAddress = dtoSupplier.SupplierAddress,
        //            SupplierEmail = dtoSupplier.SupplierEmail,
        //            SupplierPhone = dtoSupplier.SupplierPhone,
        //            SupplierName = dtoSupplier.SupplierName,
        //            credit_limit = dtoSupplier.credit_limit,
        //            credit_period = dtoSupplier.credit_period,
        //            SupplierTelephone = dtoSupplier.SupplierTelephone,
        //            user_id = user.UserType,
        //            poly_show = 1,
        //            agent_show = (user.UserType == 1) ? 0 : 1
        //        };

        //        Add(objSupplier);
        //        Save();
        //        result = true;
        //    }

        //    res.code = StaticApiStatus.ApiSaveSuccess.Code;
        //    res.message = StaticApiStatus.ApiSaveSuccess.MessageAr;
        //    res.status = StaticApiStatus.ApiSaveSuccess.Status;
        //    res.IsSuccess = true;
        //    res.payload = result;

        //    return res;

        //}
        public async Task<Response<DtoSupplierToAdd>> AddEditSupplier(DtoSupplierToAdd dtoSupplier)
        {
            if (dtoSupplier != null)
            {
                if (dtoSupplier.Id > 0)
                {
                    var isExist = FindBy(x => x.Id == dtoSupplier.Id).FirstOrDefault();
                    
                    if (isExist != null)
                    {
                        if (dtoSupplier.Name != null)
                        {
                            isExist.Name = dtoSupplier.Name;
                        }
                        if (dtoSupplier.SupplierName != null)
                        {
                            isExist.SupplierName = dtoSupplier.SupplierName;
                        }

                        if (dtoSupplier.SupplierAddress != null)
                        {
                            isExist.SupplierAddress = dtoSupplier.SupplierAddress;
                        }
                        if (dtoSupplier.SupplierPhone != null)
                        {
                            isExist.SupplierPhone = dtoSupplier.SupplierPhone;
                        }
                        if (dtoSupplier.SupplierTelephone != null)
                        {
                            isExist.SupplierTelephone = dtoSupplier.SupplierTelephone;
                        }
                        if (dtoSupplier.SupplierEmail != null)
                        {
                            isExist.SupplierEmail = dtoSupplier.SupplierEmail;
                        }
                        if (dtoSupplier.credit_limit != 0)
                        {
                            isExist.credit_limit = dtoSupplier.credit_limit;
                        }
                        if (dtoSupplier.credit_period != null)
                        {
                            isExist.credit_period = dtoSupplier.credit_period;
                        }
                        if (dtoSupplier.SupplierCode != null)
                        {
                            isExist.SupplierCode = dtoSupplier.SupplierCode;
                        }
                        isExist.ModifiedDate = DateTime.Now;

                        Edit(isExist);
                        Save();

                        dtoSupplier.Id = isExist.Id;
                        dtoSupplier.Name = isExist.Name;
                        dtoSupplier.SupplierName = isExist.SupplierName;
                        dtoSupplier.SupplierAddress = isExist.SupplierAddress;
                        dtoSupplier.SupplierPhone = isExist.SupplierPhone;
                        dtoSupplier.SupplierTelephone = isExist.SupplierTelephone;
                        dtoSupplier.SupplierEmail = isExist.SupplierEmail;
                        dtoSupplier.credit_period = isExist.credit_period;
                        dtoSupplier.credit_limit = isExist.credit_limit;
                        dtoSupplier.SupplierCode = isExist.SupplierCode;
                        dtoSupplier.poly_show = 1;
                    }
                }
                else
                {
                    var objSupplier = new TblSupplier()
                    {
                        AddedDate = DateTime.Now,
                        Name = dtoSupplier.Name,
                        SupplierName = dtoSupplier.SupplierName,
                        SupplierCode = dtoSupplier.SupplierCode,
                        SupplierEmail = dtoSupplier.SupplierEmail,
                        SupplierPhone = dtoSupplier.SupplierPhone,
                        SupplierTelephone = dtoSupplier.SupplierTelephone,
                        credit_limit = dtoSupplier.credit_limit,
                        credit_period = dtoSupplier.credit_period,
                        SupplierAddress = dtoSupplier.SupplierAddress,
                        poly_show = 1,
                };

                    Add(objSupplier);
                    Save();

                    dtoSupplier.Id = objSupplier.Id;
                }
            }

            Response<DtoSupplierToAdd> res = new Response<DtoSupplierToAdd>();
            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = dtoSupplier;
            return res;
        }
        public async Task<Response<bool>> DeleteSupplier(string Ids)
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
        public async Task<Response<List<DtoSupplierForDropDown>>> getSuppliersForDropDown()
        {
            var result = (from q in Context.TblSupplier.AsNoTracking().Where(x => x.IsDeleted == null)
                          select new DtoSupplierForDropDown
                          {
                              Id = q.Id,
                              Name = q.Name,                   
                          }).ToList();
            Response<List<DtoSupplierForDropDown>> res = new Response<List<DtoSupplierForDropDown>>();

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            res.payload = result;

            return res;
        }
        public async Task<Response<List<DtoSupplier>>> getSuppliers()
        {
            var result = (from q in Context.TblSupplier.AsNoTracking().Where(x => x.IsDeleted == null)
                          select new DtoSupplier
                          {
                              Id = q.Id,
                              Name = q.Name,
                              SupplierName=q.SupplierName,
                              SupplierAddress=q.SupplierAddress,
                              SupplierPhone=q.SupplierPhone,
                              SupplierCode=q.SupplierCode,
                              SupplierEmail=q.SupplierEmail,
                              SupplierTelephone=q.SupplierTelephone,
                              credit_limit=q.credit_limit,
                              credit_period=q.credit_period
                          }).ToList();

            Response<List<DtoSupplier>> res = new Response<List<DtoSupplier>>();

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            res.payload = result;

            return res;
        }

        public Response<int> GetCountSupplier()
        {
           int result = Context.TblSupplier.AsNoTracking().Where(x => x.IsDeleted == null).Count();
            Response<int> res = new Response<int>();
            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            res.payload = result;
            return res;
        }
    }
}
