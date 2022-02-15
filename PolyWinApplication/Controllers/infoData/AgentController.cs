using IPloyWinRepository.InterFace;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using PloyWinDto.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
namespace PolyWinApplication.Controllers.infoData
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AgentController : ControllerBase
    {
        private readonly IUserControlService _userControlService;

        private readonly IAgentRepository _agentRepository;

        public AgentController(
            IAgentRepository agentRepository,
                 IUserControlService userControlService)
        {

            _agentRepository = agentRepository;
            _userControlService = userControlService;


        }
        [AllowAnonymous]
        [HttpGet]
        [Route("GetAllAgents")]
        public async Task<IActionResult> GetAllAgents()
        {
            var result = await _agentRepository.GetAllAgent();
            return Ok(result);
        }

        #region agent

        [HttpGet]
        [Route("GetWorkShopByUserLogin")]
        public async Task<IActionResult> GetWorkShopByUserLogin()
        {
            var userClaim = User.Identity as ClaimsIdentity;
            var _user = _userControlService.GetUserByName(userClaim.Name);

            var result = _agentRepository.GetWorkShopInfo(_user.Id);

            return Ok(result);
        }

        [HttpGet]
        [Route("GetAgentandWorkShopInfo")]
        public async Task<IActionResult> GetAgentandWorkShopInfo()
        {
            var userClaim = User.Identity as ClaimsIdentity;
            var _user = _userControlService.GetUserByName(userClaim.Name);

            var result = _agentRepository.GetWorkShopInfo(_user.Id);

            return Ok(result);
        }

        [HttpGet]
        [Route("GetWorkShopByClient")]
        public async Task<IActionResult> GetWorkShopByClient()
        {
            var userClaim = User.Identity as ClaimsIdentity;
            var _user = _userControlService.GetUserByName(userClaim.Name);

            var result = _agentRepository.GetWorkShopByClient(_user.ManagerId);

            return Ok(result);
        }

        [HttpGet]
        [Route("DeleteAgent")]
        public async Task<IActionResult> DeleteAgent(int Id)
        {
            var result = _agentRepository.DeleteAgent(Id);

            return Ok(result);
        }

        [HttpPost]
        [Route("EditAgent")]
        public async Task<IActionResult> EditAgent(DtoUserAndAgent user)
        {
            var result = _agentRepository.EditAgent(user);

            return Ok(result);
        }

        #endregion

    }
}
