using PloyWinContext.Entities;
using PloyWinDto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPloyWinRepository.InterFace
{
    public interface IClientOpinionRepository:IGenericRepository<TblClientOpinions>
    {
        Response<List<DtoClientsOpinions>> GetAllClientsOpinion();
        Response<bool> DeleteClientsOpinion(string Ids);
        Response<DtoClientsOpinions> AddEditClientsOpinion(DtoClientsOpinions dto);
    }
}
