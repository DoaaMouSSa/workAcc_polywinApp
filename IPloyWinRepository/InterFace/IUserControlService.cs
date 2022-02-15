using PloyWinContext.Entities;
using PloyWinDto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPloyWinRepository.InterFace
{
    public interface IUserControlService : IGenericRepository<ApplicationUser>
    {
        List<User> GetUsers(string searchTerm);
        ApplicationUser GetUserByName(string userName);
        ApplicationUser CheckValidUser(string userName, string password);
        Task<Response<User>> GetUser(string id);
        Task<Response<string>> InsertUser(DtoUserAndAgent user, ApplicationUser _user);
        Task<Response<string>> InsertClient(DtoClient user, ApplicationUser ManagerId);
        Task<Response<bool>> UpdateUser(User user);
        Task<Response<bool>> DeleteUser(string id);
        Task<Response<List<UserWithManager>>> GetUserNotActive();
        Task<Response<string>> ActiveAccounts(string ids);
        Task<Response<string>> ActiveNotActiveAccounts(string ids);
        Task<Response<string>> ResetPassword(string ids, string Token);
        Task<Response<int>> GetAllUserTypeAgentCount();
        Task<Response<int>> GetAllUserTypeWorkShopCount();
        List<string> GetUserIdReleatedManagerId(string ManagerId);
        List<string> getListWorkShop();
        Task<bool> ChangePassword(string userName, ChanagePasswordViewModel model);
        public string GetAgentNameFromToken(string token);
    }
}
