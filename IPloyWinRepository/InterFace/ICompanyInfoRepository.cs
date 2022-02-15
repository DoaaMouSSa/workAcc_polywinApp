using PloyWinContext.Entities;
using PloyWinDto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPloyWinRepository.InterFace
{
    public interface ICompanyInfoRepository : IGenericRepository<TblCompanyInfo>
    {
        Response<DtoCompanyInfo> GetCompanyInfo();
        Response<DtoCompanyInfo> AddEditCompanyInfo(DtoCompanyInfo dto);
    }
}
