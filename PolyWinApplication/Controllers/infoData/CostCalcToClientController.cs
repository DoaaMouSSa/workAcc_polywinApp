using IPloyWinRepository.InterFace;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PloyWinDto.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PolyWinApplication.Controllers.infoData
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CostCalcToClientController : ControllerBase
    {
        private readonly IUserControlService _userControlService;

        private readonly IClientRepository _clientRepository;
        private readonly ICostCalculationRepository _costCalculationRepository;

        public CostCalcToClientController(
            ICostCalculationRepository costCalculationRepository,
            IClientRepository clientRepository,
            IUserControlService userControlService

            )
        {
            _costCalculationRepository = costCalculationRepository;
            _clientRepository = clientRepository;
            _userControlService = userControlService;
        }
        #region CostCalcToClient
        [HttpGet]
        [Route("UpdateCostCalcToClient")]
        public async Task<IActionResult> UpdateCostCalcToClient(int? CostCalcId, int? ClientId)
        {
            var result = _costCalculationRepository.UpdateCostCalcToClient(CostCalcId, ClientId);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetCostCalcByClientId")]
        public async Task<IActionResult> GetCostCalcByClientId()
        {
            var userClaim = User.Identity as ClaimsIdentity;
            var userId = _userControlService.GetUserByName(userClaim.Name);
            var ClientId = _clientRepository.GetCliendIdByUserId(userId.Id);
            var result = _costCalculationRepository.GetCostCalcByClientId(ClientId);
            return Ok(result);
        }



        [HttpGet]
        [Route("GetCostCalcAssignClientId")]
        public async Task<IActionResult> GetCostCalcAssignClientId(int ClientId)
        {
            var result = _costCalculationRepository.GetCostCalcByClientId(ClientId);
            return Ok(result);
        }


        [HttpGet]
        [Route("DeleteCostCalc")]
        public async Task<IActionResult> DeleteCostCalc(int Id)
        {
            var result = _costCalculationRepository.DeleteCostCalc(Id);
            return Ok(result);
        }

        #endregion CostCalcToClient
    }
}