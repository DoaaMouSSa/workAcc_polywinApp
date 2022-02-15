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
    public class PayedContractController : ControllerBase
    {
        private readonly IUserControlService _userControlService;
        private readonly IClientRepository _clientRepository;
        private readonly IPayedContractClientRepository _payedContractClientRepository;
     
        public PayedContractController(
            IPayedContractClientRepository payedContractClientRepository,
            IClientRepository clientRepository, 
            IUserControlService userControlService

            )
        {
            _payedContractClientRepository = payedContractClientRepository;
            _clientRepository = clientRepository;
            _userControlService = userControlService;
        }


        

        


        

        #region PayedContract

        [HttpGet]
        [Route("UpdateBulkInvoice")]
        public async Task<IActionResult> UpdateBulkInvoice(int id)
        {
            var result = _payedContractClientRepository.UpdateBulkInvoice(id);

            return Ok(result);
        }

        [HttpPost]
        [Route("AddPayedOfContract")]
        public async Task<IActionResult> AddPayedOfContract(DtoPayedClient dtoPayedClient)
        {
            if (dtoPayedClient.ClientId > 0)
            {
                var userId = _clientRepository.GetUserIdById(dtoPayedClient.ClientId);
                dtoPayedClient.UserId = userId;
                var result = _payedContractClientRepository.AddPayedOfContract(dtoPayedClient);

                return Ok(result);
            }

            return Ok("Please Choose Client");
        }

        [HttpGet]
        [Route("GetAllPayedByWorkShop")]
        public async Task<IActionResult> GetAllPayedByWorkShop(int clientId, int ContractId)
        {
            var userId = _clientRepository.GetUserIdById(clientId);

            var result = _payedContractClientRepository.GetAllPayedByClientId(userId, ContractId);

            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllPayedByClientId")]
        public async Task<IActionResult> GetAllPayedByClientId(int ContractId)
        {
            var userClaim = User.Identity as ClaimsIdentity;
            var userId = _userControlService.GetUserByName(userClaim.Name);

            var result = _payedContractClientRepository.GetAllPayedByClientId(userId.Id, ContractId);

            return Ok(result);
        }

        #endregion

    }
}
