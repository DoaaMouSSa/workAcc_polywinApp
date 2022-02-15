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
    public class AgentRepository : GenericRepository<ApplicationContext, TblAgent>, IAgentRepository
    {
        private readonly IUserControlService _userControlService;
        public AgentRepository(IUserControlService userControlService)
        {
            _userControlService = userControlService;
        }

        public async Task<Response<List<DtoAgent>>> GetAllAgent()
        {
            Response<List<DtoAgent>> res = new Response<List<DtoAgent>>();

            List<DtoAgent> agent = new List<DtoAgent>();

            var result = (from q in Context.TblAgent.AsNoTracking().Where(x => x.IsDeleted == null)
                          select new DtoAgent
                          {
                              id = q.Id,
                              name = q.Name ?? "",
                              agentAddress = q.AgentAddress ?? "",
                              agentGovernorate = q.AgentGovernorate ?? "",
                              agentLogo = q.AgentLogo ?? "",
                              agentPhone = q.AgentPhone ?? "",
                              nameAgent = q.NameAgent ?? "",
                              UserId = q.UserId,
                              Email = q.Email,
                              Long = q.Long,
                              Late = q.Late
                          }).ToList();

            foreach (var item in result)
            {
                var userType = Context.Users.AsNoTracking().Where(x => x.Id == item.UserId).Select(x => x.UserType).FirstOrDefault();

                if (userType == 2)
                {
                    agent.Add(item);
                }
            }

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            res.payload = agent;

            return res;
        }

        public async Task<Response<DtoAgent>> GetAgentById(int id)
        {
            var result = (from q in Context.TblAgent.AsNoTracking().Where(x => x.IsDeleted == null && x.Id == id)
                          select new DtoAgent
                          {
                              id = q.Id,
                              name = q.Name ?? "",
                              agentAddress = q.AgentAddress ?? "",
                              agentGovernorate = q.AgentGovernorate ?? "",
                              agentLogo = q.AgentLogo ?? "",
                              agentPhone = q.AgentPhone ?? "",
                              nameAgent = q.NameAgent ?? "",
                              Long = q.Long,
                              Late = q.Late,
                              Email = q.Email
                          }).FirstOrDefault();
            Response<DtoAgent> res = new Response<DtoAgent>();

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            res.payload = result;

            return res;
        }

        public async Task<Response<DtoAgent>> GetAgentInfo(ApplicationUser user)
        {
            var result = (from q in Context.TblAgent.AsNoTracking().Where(x => x.IsDeleted == null && x.UserId == user.Id)
                          select new DtoAgent
                          {
                              id = q.Id,
                              name = q.Name ?? "",
                              agentAddress = q.AgentAddress ?? "",
                              agentGovernorate = q.AgentGovernorate ?? "",
                              agentLogo = q.AgentLogo ?? "",
                              agentPhone = q.AgentPhone ?? "",
                              nameAgent = q.NameAgent ?? "",
                              Long = q.Long,
                              Late = q.Late,
                              Email = q.Email
                          }).FirstOrDefault();

            Response<DtoAgent> res = new Response<DtoAgent>();

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            res.payload = result;

            return res;
        }

        public Response<bool> UpdateAgentInfo(DtoUserAndAgent user, string Id)
        {
            var result = FindBy(x => x.UserId == Id).FirstOrDefault();
            bool gg = false;
            if (result != null)
            {
                result.Name = user.name;
                result.ModifiedDate = DateTime.Now;
                result.NameAgent = user.nameAgent;
                if (user.agentLogo != null)
                {
                    result.AgentLogo = user.agentLogo;
                }

                result.AgentGovernorate = user.agentGovernorate;
                result.AgentAddress = user.agentAddress;
                result.AgentPhone = user.agentPhone;
                result.Long = user.Long;
                result.Late = user.Late;
                result.Email = user.email;
                Edit(result);
                Save();
                gg = true;
            }

            Response<bool> res = new Response<bool>();

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            res.payload = gg;

            return res;
        }

        public async Task<Response<bool>> AddNewAgent(DtoUserAndAgent user)
        {
            Response<bool> res = new Response<bool>();
            bool result = false;

            if (user != null)
            {
                var objAgent = new TblAgent()
                {
                    Name = user.name,
                    AddedDate = DateTime.Now,
                    NameAgent = user.nameAgent,
                    AgentLogo = user.agentLogo,
                    AgentGovernorate = user.agentGovernorate,
                    AgentAddress = user.agentAddress,
                    AgentPhone = user.agentPhone,
                    UserId = user.userId.ToString(),
                    Long = user.Long,
                    Late = user.Late,
                    Email = user.email
                };

                Add(objAgent);
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

        public async Task<Response<bool>> EditAgent(DtoUserAndAgent user)
        {
            Response<bool> res = new Response<bool>();
            bool result = false;

            if (user != null)
            {
                if (user.id > 0)
                {
                    var isExist = FindBy(x => x.Id == user.id).FirstOrDefault();

                    if (isExist != null)
                    {
                        isExist.Name = user.name;
                        isExist.ModifiedDate = DateTime.Now;
                        isExist.NameAgent = user.nameAgent;
                        isExist.AgentLogo = user.agentLogo;
                        isExist.AgentGovernorate = user.agentGovernorate;
                        isExist.AgentAddress = user.agentAddress;
                        isExist.AgentPhone = user.agentPhone;
                        isExist.Long = user.Long;
                        isExist.Late = user.Late;
                        isExist.Email = user.email;

                        Edit(isExist);
                        Save();

                        result = true;
                    }
                }
            }

            res.code = StaticApiStatus.ApiSaveSuccess.Code;
            res.message = StaticApiStatus.ApiSaveSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSaveSuccess.Status;
            res.IsSuccess = true;
            res.payload = result;

            return res;
        }

        public async Task<Response<bool>> DeleteAgent(int id)
        {
            Response<bool> res = new Response<bool>();
            bool result = false;

            var isExist = FindBy(x => x.Id == id).FirstOrDefault();

            if (isExist != null)
            {
                isExist.IsDeleted = true;
                isExist.DeletedDate = DateTime.Now;

                Edit(isExist);
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


        public async Task<Response<List<DtoAgent>>> GetWorkShopInfo(string ManagerId)
        {
            Response<List<DtoAgent>> res = new Response<List<DtoAgent>>();

            var listUsers = _userControlService.GetUserIdReleatedManagerId(ManagerId);

            var result = FindBy(x => listUsers.Contains(x.UserId) && x.IsDeleted == null).Select(x => new DtoAgent
            {
                id = x.Id,
                name = x.Name,
                agentAddress = x.AgentAddress,
                agentGovernorate = x.AgentGovernorate,
                agentLogo = x.AgentLogo,
                agentPhone = x.AgentPhone,
                nameAgent = x.NameAgent,
                Email = x.Email,
                Late = x.Late,
                Long = x.Long
            }).ToList();

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            res.payload = result;

            return res;
        }

        public async Task<Response<List<DtoAgent>>> GetAgentandWorkShopInfo(string ManagerId)
        {
            Response<List<DtoAgent>> res = new Response<List<DtoAgent>>();

            var listUsers = _userControlService.GetUserIdReleatedManagerId(ManagerId);

            var result = FindBy(x => listUsers.Contains(x.UserId) && x.IsDeleted == null).Select(x => new DtoAgent
            {
                id = x.Id,
                name = x.Name,
                agentAddress = x.AgentAddress,
                agentGovernorate = x.AgentGovernorate,
                agentLogo = x.AgentLogo,
                agentPhone = x.AgentPhone,
                nameAgent = x.NameAgent,
                Email = x.Email,
                Late = x.Late,
                Long = x.Long
            }).ToList();

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            res.payload = result;

            return res;
        }

        public async Task<Response<List<DtoAgent>>> GetWorkShopByClient(string ManagerId)
        {
            Response<List<DtoAgent>> res = new Response<List<DtoAgent>>();

            var result = FindBy(x => x.UserId == ManagerId && x.IsDeleted == null).Select(x => new DtoAgent
            {
                id = x.Id,
                name = x.Name,
                agentAddress = x.AgentAddress,
                agentGovernorate = x.AgentGovernorate,
                agentLogo = x.AgentLogo,
                agentPhone = x.AgentPhone,
                nameAgent = x.NameAgent,
                Email = x.Email,
                Late = x.Late,
                Long = x.Long
            }).ToList();

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            res.payload = result;

            return res;
        }
        public async Task<Response<List<DtoByWorkShopByGov>>> GetWorkShopByGov()
        {
            Response<List<DtoByWorkShopByGov>> res = new Response<List<DtoByWorkShopByGov>>();

            var listUsers = _userControlService.getListWorkShop();


            var result = FindBy(x => listUsers.Contains(x.UserId) && x.IsDeleted == null).Select(x => new DtoAgent
            {
                id = x.Id,
                name = x.Name,
                agentAddress = x.AgentAddress,
                agentGovernorate = x.AgentGovernorate,
                agentLogo = x.AgentLogo,
                agentPhone = x.AgentPhone,
                nameAgent = x.NameAgent,
                Email = x.Email,
                Late = x.Late,
                Long = x.Long
            }).ToList();
            if (result.Count() > 0)
            {
                var groupByGov = (from workshop in result
                                  group workshop by workshop.agentGovernorate
                                         into egroup
                                  orderby egroup.Key
                                  select new DtoByWorkShopByGov
                                  {
                                      agentGovernorate = egroup.Key,
                                      listAgent = egroup.ToList()
                                  }).ToList();

                res.code = StaticApiStatus.ApiSuccess.Code;
                res.message = StaticApiStatus.ApiSuccess.MessageAr;
                res.status = StaticApiStatus.ApiSuccess.Status;
                res.IsSuccess = true;
                res.payload = groupByGov;
            }


            return res;
        }
        public async Task<Response<List<DtoAgent>>> GetWorkShopByOneGov(string govName)
        {
            Response<List<DtoAgent>> res = new Response<List<DtoAgent>>();
            var listUsers = _userControlService.getListWorkShop();


            var result = FindBy(x => listUsers.Contains(x.UserId) && x.IsDeleted == null && x.AgentGovernorate == govName).Select(x => new DtoAgent
            {
                id = x.Id,
                name = x.Name,
                agentAddress = x.AgentAddress,
                agentGovernorate = x.AgentGovernorate,
                agentLogo = x.AgentLogo,
                agentPhone = x.AgentPhone,
                nameAgent = x.NameAgent,
                Email = x.Email,
                UserId = x.UserId,
                Late = x.Late,
                Long = x.Long
            }).ToList();

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            res.payload = result;
            return res;
        }


        public async Task<Response<List<DtoAgent>>> GetAllUserTypeWorkShopDetails()
        {
            Response<List<DtoAgent>> res = new Response<List<DtoAgent>>();

            List<DtoAgent> data = new List<DtoAgent>();

            var countWorkShop = Context.Users.Where(x => x.isDeleted == null && x.UserType == 3 && x.IsActive == true).Select(x => new { Id = x.Id, ManagerId = x.ManagerId }).ToList();

            foreach (var item in countWorkShop)
            {
                var obj = Context.TblAgent.AsNoTracking().Where(x => x.UserId == item.Id).Select(x => new DtoAgent
                {
                    id = x.Id,
                    name = x.Name,
                    agentAddress = x.AgentAddress,
                    agentGovernorate = x.AgentGovernorate,
                    agentLogo = x.AgentLogo,
                    agentPhone = x.AgentPhone,
                    nameAgent = x.NameAgent,
                    Email = x.Email,
                    Late = x.Late,
                    Long = x.Long
                }).FirstOrDefault();



                if (obj != null)
                {
                    obj.ParentName = Context.TblAgent.AsNoTracking().Where(x => x.UserId == item.ManagerId).Select(x => x.NameAgent).FirstOrDefault();
                    data.Add(obj);
                }
            }

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSaveSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            res.payload = data;

            return res;
        }

        public async Task<Response<List<DtoAgent>>> GetAllUserTypeAgentDetails()
        {
            Response<List<DtoAgent>> res = new Response<List<DtoAgent>>();

            List<DtoAgent> data = new List<DtoAgent>();

            var countWorkShop = Context.Users.Where(x => x.isDeleted == null && x.UserType == 2 && x.IsActive == true).Select(x => new { Id = x.Id, ManagerId = x.ManagerId }).ToList();

            foreach (var item in countWorkShop)
            {
                var obj = Context.TblAgent.AsNoTracking().Where(x => x.UserId == item.Id).Select(x => new DtoAgent
                {
                    id = x.Id,
                    name = x.Name,
                    agentAddress = x.AgentAddress,
                    agentGovernorate = x.AgentGovernorate,
                    agentLogo = x.AgentLogo,
                    agentPhone = x.AgentPhone,
                    nameAgent = x.NameAgent,
                    Email = x.Email,
                    Late = x.Late,
                    Long = x.Long
                }).FirstOrDefault();

                if (obj != null)
                {
                    obj.ParentName = Context.TblAgent.AsNoTracking().Where(x => x.UserId == item.ManagerId).Select(x => x.NameAgent).FirstOrDefault();

                    data.Add(obj);
                }
            }

            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSaveSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            res.payload = data;

            return res;
        }

        public List<DtoAccountDetails> GetAllAccounts()

        {
            var result = (from q in Context.Users.AsNoTracking().Where(x => x.isDeleted == null && x.ManagerId != null)
                          let clientInfo = Context.TblClient.Where(x => x.UserId == q.Id).Select(x => new { Name = x.Name, Phone = x.ClientPhone }).FirstOrDefault()
                          let agentInfo = Context.TblAgent.Where(x => x.UserId == q.Id).Select(x => new { Name = x.Name, Phone = x.AgentPhone }).FirstOrDefault()
                          select new DtoAccountDetails
                          {
                              id = q.Id,
                              ActiveType = q.IsActive == true ? "مفعل" : "غير مفعل",
                              UserType = q.UserType == 4 ? "عميل" : (q.UserType == 3 ? "ورشة" : "وكيل"),
                              Username = q.UserName,
                              Password = q.PasswordHash,
                              Name = q.UserType == 4 ? clientInfo.Name : agentInfo.Name,
                              Phone = q.UserType == 4 ? clientInfo.Phone : agentInfo.Phone
                          }).ToList();

            return result;

        }
        public Response<List<DtoAgentLogo>> GetAgentLogos()
        {
            Response<List<DtoAgentLogo>> res = new Response<List<DtoAgentLogo>>();
            var result = (from q in Context.TblAgent.AsNoTracking().Where(x => x.IsDeleted == null)
                          select new DtoAgentLogo {agentLogo = q.AgentLogo ?? "",}).ToList();
            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.IsSuccess = true;
            res.payload = result;
            return res;
        }
    }
}
