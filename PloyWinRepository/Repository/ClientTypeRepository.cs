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
    public class ClientTypeRepository : GenericRepository<ApplicationContext, TblClientType>, IClientTypeRepository
    {
        public Response<List<DtoClientType>> GetAllClientType()
        {
            Response<List<DtoClientType>> res = new Response<List<DtoClientType>>();

            var result = (from q in Context.TblClientType.AsNoTracking().Where(x => x.IsDeleted == null)
                          select new DtoClientType
                          {
                              Id = q.Id,
                              Name = q.Name
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
