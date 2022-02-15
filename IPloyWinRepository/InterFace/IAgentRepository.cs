using PloyWinContext.Entities;
using PloyWinDto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPloyWinRepository.InterFace
{
    public interface IAgentRepository : IGenericRepository<TblAgent>
    {
        Task<Response<DtoAgent>> GetAgentInfo(ApplicationUser user);
        Response<bool> UpdateAgentInfo(DtoUserAndAgent user,string Id);
        Task<Response<List<DtoAgent>>> GetAllAgent();
        Task<Response<bool>> EditAgent(DtoUserAndAgent user);
        Task<Response<bool>> AddNewAgent(DtoUserAndAgent user);
        Task<Response<bool>> DeleteAgent(int id);
        Task<Response<List<DtoAgent>>> GetWorkShopInfo(string ManagerId);
        Task<Response<List<DtoAgent>>> GetAgentandWorkShopInfo(string ManagerId);
        Task<Response<List<DtoAgent>>> GetWorkShopByClient(string ManagerId);
        Task<Response<List<DtoByWorkShopByGov>>> GetWorkShopByGov();
        Task<Response<List<DtoAgent>>> GetWorkShopByOneGov(string govName);
        Task<Response<DtoAgent>> GetAgentById(int id);
        Task<Response<List<DtoAgent>>> GetAllUserTypeAgentDetails();
        Task<Response<List<DtoAgent>>> GetAllUserTypeWorkShopDetails();
        List<DtoAccountDetails> GetAllAccounts();
    }
}
