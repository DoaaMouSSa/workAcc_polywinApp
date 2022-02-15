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
    public class ContractController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;
        private readonly IContractClientRepository _contractClientRepository;
        private readonly IUserControlService _userControlService;

        public ContractController(IContractClientRepository contractClientRepository, IClientRepository clientRepository, IUserControlService userControlService)
        {
            _clientRepository = clientRepository;
            _userControlService = userControlService;
            _contractClientRepository = contractClientRepository;
        }
        #region Contract

        [HttpPost]
        [Route("AddNewContract")]
        public async Task<IActionResult> AddNewContract(DtoContractClient contract)
        {
            var userClaim = User.Identity as ClaimsIdentity;
            var FromUserId = _userControlService.GetUserByName(userClaim.Name);
            var ToUserId = _clientRepository.GetUserIdById(contract.ClientId);

            contract.ToUserId = ToUserId;
            contract.FromUserId = FromUserId.Id;

            var InvoiceId = _contractClientRepository.AddNewContract(contract);

            return Ok(InvoiceId);
        }


        [HttpGet]
        [Route("UpdateContractForRecived")]
        public async Task<IActionResult> UpdateContractForRecived(int id, bool isRecived)
        {
            var result = _contractClientRepository.UpdateContract(id, isRecived);

            return Ok(result);
        }

        [HttpGet]
        [Route("GetContractNumber")]
        public async Task<IActionResult> GetContractNumber()
        {
            var result = _contractClientRepository.GetContractNumber();

            return Ok(result);
        }


        [HttpGet]
        [Route("GetAllContractByWorkShop")]
        public async Task<IActionResult> GetAllContractByWorkShop()
        {
            var userClaim = User.Identity as ClaimsIdentity;
            var FromUserId = _userControlService.GetUserByName(userClaim.Name);

            var result = _contractClientRepository.GetAllContractByWorkShop(FromUserId.Id);

            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllContractByClient")]
        public async Task<IActionResult> GetAllContractByClient()
        {
            var userClaim = User.Identity as ClaimsIdentity;
            var ToUserId = _userControlService.GetUserByName(userClaim.Name);

            var result = _contractClientRepository.GetAllContractByClient(ToUserId.Id);

            return Ok(result);
        }

        [HttpGet]
        [Route("GetContractInfoByContractId")]
        public async Task<IActionResult> GetContractInfoByContractId(int? contractId)
        {
            var result = _contractClientRepository.GetContractInfoByContractId(contractId);

            return Ok(result);
        }

        #endregion

    }
}
