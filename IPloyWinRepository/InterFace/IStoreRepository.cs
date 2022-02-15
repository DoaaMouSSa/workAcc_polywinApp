using PloyWinContext.Entities;
using PloyWinDto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPloyWinRepository.InterFace
{
    public interface IStoreRepository : IGenericRepository<TblStores>
    {
        Response<List<DtoStores>> GetAllStore(ApplicationUser user);
        Response<List<DtoStoresGroupBy>> GetAllStoreByUserId(ApplicationUser user);
        bool AddProductToStore(DtoToAddToStore dtoStores, ApplicationUser user);
        bool AddProductToStoreAfterPurchase(DtoStoreFromPurchase dtoStores);
    }
}
