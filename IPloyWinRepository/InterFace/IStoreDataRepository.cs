using PloyWinContext.Entities;
using PloyWinDto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPloyWinRepository.InterFace
{
    public interface IStoreDataRepository:IGenericRepository<TblStoreData>
    {
        //Task<Response<DtoStoreDataToAdd>> AddEditStore(DtoStoreDataToAdd dtoStore, ApplicationUser user);
        //Task<Response<bool>> DeleteStore(string Ids);
        //Task<Response<List<DtoStoreDataForDropDown>>> getStoresForDropDown(ApplicationUser user);
        //Task<Response<List<DtoStoreData>>> getStores(ApplicationUser user);
    }
}
