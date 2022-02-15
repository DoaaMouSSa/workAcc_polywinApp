using PloyWinContext.Entities;
using PloyWinDto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPloyWinRepository.InterFace
{
    public interface ISupplierRepository : IGenericRepository<TblSupplier>
    {
        Task<Response<DtoSupplierToAdd>> AddEditSupplier(DtoSupplierToAdd dtoSupplier);
        Task<Response<bool>> DeleteSupplier(string Ids);
        Task<Response<List<DtoSupplierForDropDown>>> getSuppliersForDropDown();
        Task<Response<List<DtoSupplier>>> getSuppliers();
        Response<int> GetCountSupplier();

    }
}
