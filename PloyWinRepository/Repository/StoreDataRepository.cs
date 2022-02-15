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
    public class StoreDataRepository : GenericRepository<ApplicationContext, TblStoreData>, IStoreDataRepository
    {
        //public async Task<Response<DtoStoreDataToAdd>> AddEditStore(DtoStoreDataToAdd dtoStore,ApplicationUser user)
        //{
        //    if (dtoStore != null)
        //    {
        //        if (dtoStore.Id > 0)
        //        {
        //            var isExist = FindBy(x => x.Id == dtoStore.Id).FirstOrDefault();

        //            if (isExist != null)
        //            {
        //                if (dtoStore.StoreName != null)
        //                {
        //                    isExist.StoreName = dtoStore.StoreName;
        //                }
        //                if (dtoStore.StorePhone != null)
        //                {
        //                    isExist.StorePhone = dtoStore.StorePhone;
        //                }

        //                if (dtoStore.StoreAddress != null)
        //                {
        //                    isExist.StoreAddress = dtoStore.StoreAddress;
        //                }
        //                if (dtoStore.StoreBranch != null)
        //                {
        //                    isExist.StoreBranch = dtoStore.StoreBranch;
        //                }
        //                if (dtoStore.StoreWorker != null)
        //                {
        //                    isExist.StoreWorker = dtoStore.StoreWorker;
        //                }
        //                if (dtoStore.StoreIs_Active != false)
        //                {
        //                    isExist.StoreIs_Active = true;
        //                }
                        
                        
        //                isExist.ModifiedDate = DateTime.Now;

        //                Edit(isExist);
        //                Save();

        //                dtoStore.Id = isExist.Id;
        //                dtoStore.StoreName = isExist.StoreName;
        //                dtoStore.StoreAddress = isExist.StoreAddress;
        //                dtoStore.StorePhone = isExist.StorePhone;
        //                dtoStore.StoreWorker = isExist.StoreWorker;
        //                dtoStore.StoreBranch = isExist.StoreBranch;
        //                dtoStore.StoreIs_Active = isExist.StoreIs_Active;
        //                dtoStore.user_id = user.UserType;
        //                dtoStore.poly_show = 1;
        //                dtoStore.agent_show = (user.UserType == 1) ? 0 : 1;
        //            }
        //        }
        //        else
        //        {
        //            var objStore = new TblStoreData()
        //            {
        //                AddedDate = DateTime.Now,
        //                StoreName = dtoStore.StoreName,
        //                StoreAddress = dtoStore.StoreAddress,
        //                StorePhone = dtoStore.StorePhone,
        //                StoreWorker = dtoStore.StoreWorker,
        //                StoreBranch = dtoStore.StoreBranch,
        //                StoreIs_Active = dtoStore.StoreIs_Active, 
        //                user_id = user.UserType,
        //                poly_show = 1,
        //                agent_show = (user.UserType == 1) ? 0 : 1
        //            };

        //            Add(objStore);
        //            Save();

        //            dtoStore.Id = objStore.Id;
        //        }
        //    }

        //    Response<DtoStoreDataToAdd> res = new Response<DtoStoreDataToAdd>();
        //    res.code = StaticApiStatus.ApiSuccess.Code;
        //    res.message = StaticApiStatus.ApiSuccess.MessageAr;
        //    res.status = StaticApiStatus.ApiSuccess.Status;
        //    res.payload = dtoStore;
        //    return res;
        //}

        //public async Task<Response<bool>> DeleteStore(string Ids)
        //{
        //    var listId = Ids.Split(',').ToList();

        //    bool dd = false;

        //    foreach (var Id in listId)
        //    {
        //        var result = FindBy(x => x.Id == Convert.ToInt32(Id)).FirstOrDefault();


        //        if (result != null)
        //        {
        //            result.IsDeleted = true;
        //            result.DeletedDate = DateTime.Now;

        //            Edit(result);
        //            Save();

        //            dd = true;
        //        }
        //    }

        //    Response<bool> res = new Response<bool>();
        //    res.code = StaticApiStatus.ApiSuccess.Code;
        //    res.message = StaticApiStatus.ApiSuccess.MessageAr;
        //    res.status = StaticApiStatus.ApiSuccess.Status;
        //    res.payload = dd;
        //    return res;
        //}

        ////public async Task<Response<List<DtoStoreData>>> getStores(ApplicationUser user)
        ////{
        ////    var result = (from q in Context.TblStoreData.AsNoTracking().Where(x => x.IsDeleted == null&& user.UserType==1)
        ////                  select new DtoStoreData
        ////                  {
        ////                      Id = q.Id,
        ////                    StoreName=q.StoreName,
        ////                    StoreAddress=q.StoreAddress,
        ////                    StorePhone=q.StorePhone,
        ////                    StoreWorker=q.StoreWorker,
        ////                    StoreBranch=q.StoreBranch,
        ////                    StoreIs_Active=q.StoreIs_Active
        ////                  }).ToList();

        ////    Response<List<DtoStoreData>> res = new Response<List<DtoStoreData>>();

        ////    res.code = StaticApiStatus.ApiSuccess.Code;
        ////    res.message = StaticApiStatus.ApiSuccess.MessageAr;
        ////    res.status = StaticApiStatus.ApiSuccess.Status;
        ////    res.IsSuccess = true;
        ////    res.payload = result;

        ////    return res;
        ////}

        //public async Task<Response<List<DtoStoreDataForDropDown>>> getStoresForDropDown(ApplicationUser user)
        //{
        //    var result = (from q in Context.TblStoreData.AsNoTracking().Where(x => x.IsDeleted == null && user.UserType == 1)
        //                  select new DtoStoreDataForDropDown
        //                  {
        //                      Id = q.Id,
        //                      StoreName = q.StoreName,
                       
        //                  }).ToList();

        //    Response<List<DtoStoreDataForDropDown>> res = new Response<List<DtoStoreDataForDropDown>>();

        //    res.code = StaticApiStatus.ApiSuccess.Code;
        //    res.message = StaticApiStatus.ApiSuccess.MessageAr;
        //    res.status = StaticApiStatus.ApiSuccess.Status;
        //    res.IsSuccess = true;
        //    res.payload = result;

        //    return res;
        //}
    }
}
