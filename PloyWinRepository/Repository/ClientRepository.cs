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
    public class ClientRepository : GenericRepository<ApplicationContext, TblClient>, IClientRepository
    {
        private readonly IUserControlService _userControlService;

        public ClientRepository(IUserControlService userControlService)
        {
            _userControlService = userControlService;
        }

        public async Task<Response<bool>> AddNewCLient(DtoClient client)
        {
            Response<bool> res = new Response<bool>();

            bool result = false;

            if (client != null)
            {
                var objClient = new TblClient()
                {
                    AddedDate = DateTime.Now,
                    Name = client.Name,
                    ClientLogo = client.ClientLogoURL,
                    ClientAddress = client.ClientAddress,
                    ClientPhone = client.ClientPhone,
                    UserId = client.userId.ToString(),
                    ClientTypeId = client.ClientTypeId,
                    Late = client.Late,
                    Long = client.Long,
                    Email = client.email,
                    device_id=client.device_id
                };

                Add(objClient);
                Save();

                result = true;
            }

            res.code = StaticApiStatus.ApiSaveSuccess.Code;
            res.message = StaticApiStatus.ApiSaveSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSaveSuccess.Status;
            res.IsSuccess = true;
            res.payload = result;

            return res;
        }

        public string GetUserIdById(int Id)
        {
            var result = FindBy(x => x.Id == Id).FirstOrDefault().UserId;

            return result;
        }

        public int GetCliendIdByUserId(string userId)
        {
            var result = FindBy(x => x.UserId == userId).FirstOrDefault().Id;

            return result;
        }

        public Response<List<DtoClientForView>> GetAllClientByUserLogIn(string userId)
        {
            List<DtoClientForView> listClient = new List<DtoClientForView>();
            Response<List<DtoClientForView>> res = new Response<List<DtoClientForView>>();

            var ListClient = _userControlService.GetUserIdReleatedManagerId(userId);

            if (ListClient != null)
            {
                foreach (var item in ListClient)
                {
                    var objClient = FindBy(x => x.UserId == item).FirstOrDefault();

                    if (objClient != null)
                    {
                        listClient.Add(new DtoClientForView
                        {
                            id = objClient.Id,
                            Name = objClient.Name,
                            ClientAddress = objClient.ClientAddress,
                            ClientPhone = objClient.ClientPhone,
                            Email = objClient.Email
                        });
                    }
                }
            }

            res.code = StaticApiStatus.ApiSaveSuccess.Code;
            res.message = StaticApiStatus.ApiSaveSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSaveSuccess.Status;
            res.IsSuccess = true;
            res.payload = listClient;

            return res;
        }

        public Response<List<DtoClientViewModal>> GetAllClientInfoByUserLogIn(string userId)
        {
            List<DtoClientViewModal> listClient = new List<DtoClientViewModal>();
            Response<List<DtoClientViewModal>> res = new Response<List<DtoClientViewModal>>();

            var ListClient = _userControlService.GetUserIdReleatedManagerId(userId);

            if (ListClient != null)
            {
                foreach (var item in ListClient)
                {
                    var objClient = FindBy(x => x.UserId == item).FirstOrDefault();

                    if (objClient != null)
                    {
                        listClient.Add(new DtoClientViewModal
                        {
                            id = objClient.Id,
                            Name = objClient.Name,
                            ClientAddress = objClient.ClientAddress,
                            ClientPhone = objClient.ClientPhone,
                            Email = objClient.Email
                            //userType = objClient.TblClientType.Name
                        });
                    }
                }
            }

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            res.payload = listClient;

            return res;
        }

        public DtoClientViewModal GetClientInfoById(string Id)
        {
            var result = FindBy(x => x.UserId == Id).Select(x => new DtoClientViewModal
            {
                id = x.Id,
                Name = x.Name,
                ClientAddress = x.ClientAddress,
                ClientPhone = x.ClientPhone,
                Email = x.Email
            }).FirstOrDefault();

            return result;
        }

        public Response<List<DtoClientTypeCount>> GetClientTypeCount()
        {
            Response<List<DtoClientTypeCount>> res = new Response<List<DtoClientTypeCount>>();

            List<DtoClientTypeCount> result = new List<DtoClientTypeCount>();

            var clientType = Context.TblClientType.Where(x => x.IsDeleted == null).Select(x =>
                         new DtoClientTypeCount
                         {
                             Id = x.Id,
                             ClientType = x.Name
                         }).ToList();

            foreach (var item in clientType)
            {
                var clientCount = FindBy(x => x.IsDeleted == null && x.ClientTypeId == item.Id).Count();

                result.Add(new DtoClientTypeCount { ClientType = item.ClientType, Count = clientCount });
            }

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            res.payload = result;

            return res;

        }

        public Response<List<DtoClientViewModal>> GetClientTypeDetails()
        {
            Response<List<DtoClientViewModal>> res = new Response<List<DtoClientViewModal>>();

            List<DtoClientViewModal> result = new List<DtoClientViewModal>();

            var clientType = Context.Users.Where(x => x.isDeleted == null && x.UserType == 4 && x.IsActive == true).Select(x => new { Id = x.Id, managerId = x.ManagerId }).ToList();

            foreach (var item in clientType)
            {

                var obj = Context.TblClient.AsNoTracking().Where(x => x.UserId == item.Id).Select(x =>
                  new DtoClientViewModal
                  {
                      id = x.Id,
                      Name = x.Name,
                      ClientAddress = x.ClientAddress,
                      ClientPhone = x.ClientPhone,
                      Email = x.Email,
                      userType = x.TblClientType.Name,
                      ClientLogo = x.ClientLogo,
                      Late = x.Late,
                      Long = x.Long
                  }).FirstOrDefault();

                if (obj != null)
                {
                    obj.ParentName = Context.TblAgent.AsNoTracking().Where(x => x.UserId == item.managerId).Select(x => x.NameAgent).FirstOrDefault();
                    result.Add(obj);
                }
            }

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            res.payload = result;

            return res;

        }
    }
}
