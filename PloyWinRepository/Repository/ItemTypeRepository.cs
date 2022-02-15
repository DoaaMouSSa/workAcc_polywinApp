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
    public class ItemTypeRepository : GenericRepository<ApplicationContext, TblItemType>, IItemTypeRepository
    {
        public async Task<Response<DtoItemType>> AddEditItemType(DtoItemType dtoItemType)
        {
            if (dtoItemType != null)
            {
                if (dtoItemType.Id > 0)
                {
                    var isExist = FindBy(x => x.Id == dtoItemType.Id).FirstOrDefault();

                    if (isExist != null)
                    {
                        if (dtoItemType.NameItemType != null)
                        {
                            isExist.NameItemType = dtoItemType.NameItemType;
                        }

                        isExist.ModifiedDate = DateTime.Now;

                        Edit(isExist);
                        Save();

                        dtoItemType.Id = isExist.Id;
                        dtoItemType.NameItemType = isExist.NameItemType;
                     
                    }
                }
                else
                {
                    var objItemType = new TblItemType()
                    {
                        AddedDate = DateTime.Now,
                        NameItemType = dtoItemType.NameItemType
                        
                    };

                    Add(objItemType);
                    Save();

                    dtoItemType.Id = objItemType.Id;
                }
            }

            Response<DtoItemType> res = new Response<DtoItemType>();
            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = dtoItemType;
            return res;
        }

        public async Task<Response<bool>> DeleteItemType(string Ids)
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


        public async Task<Response<List<DtoItemType>>> getItemType()
        {
            var result = (from q in Context.TblItemType.AsNoTracking().Where(x => x.IsDeleted == null)
                          select new DtoItemType
                          {
                              Id = q.Id,
                              NameItemType = q.NameItemType,
                          }).ToList();
            Response<List<DtoItemType>> res = new Response<List<DtoItemType>>();

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            res.payload = result;

            return res;
        }
    }
}
