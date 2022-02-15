using PloyWinContext.Entities;
using PloyWinDto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPloyWinRepository.InterFace
{
    public interface IClientRepository : IGenericRepository<TblClient>
    {
        Task<Response<bool>> AddNewCLient(DtoClient client);
        string  GetUserIdById(int Id);
        int GetCliendIdByUserId(string userId);
        Response<List<DtoClientForView>> GetAllClientByUserLogIn(string userId);
        DtoClientViewModal GetClientInfoById(string Id);
        Response<List<DtoClientViewModal>> GetAllClientInfoByUserLogIn(string userId);
        Response<List<DtoClientTypeCount>> GetClientTypeCount();
        Response<List<DtoClientViewModal>> GetClientTypeDetails();
    }
}
