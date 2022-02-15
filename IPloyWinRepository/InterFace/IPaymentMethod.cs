using PloyWinContext.Entities;
using PloyWinDto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPloyWinRepository.InterFace
{
   public interface IPaymentMethod : IGenericRepository<TblPaymentMethods>
    {
        Task<Response<DtoPaymentMethod>> AddEditPaymentMethod(DtoPaymentMethod dtoPaymentMethod);
        Task<Response<bool>> DeletePaymentMethod(string Ids);
        Task<Response<List<DtoPaymentMethod>>> getPaymentMethod();
    }
}
