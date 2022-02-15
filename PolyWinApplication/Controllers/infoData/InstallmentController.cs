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
    public class InstallmentController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;
        private readonly IInstallmentRepository _installmentRepository;

        public InstallmentController(
            IInstallmentRepository installmentRepository,
            IClientRepository clientRepository

            )
        {
            _installmentRepository = installmentRepository;
            _clientRepository = clientRepository;
        }



        #region Installment

        [HttpPost]
        [Route("CheckInstallment")]
        public async Task<IActionResult> CheckInstallment(DtoInstallment dto)
        {
            var result = _installmentRepository.CheckInstallment(dto);
            return Ok(result);
        }

        [HttpPost]
        [Route("AddNewInstallment")]
        public async Task<IActionResult> AddNewInstallment(int clientId, int ContractId, List<DtoListInstallment> dto)
        {
            var ToUserId = _clientRepository.GetUserIdById(clientId);

            var result = _installmentRepository.AddNewInstallment(ToUserId, ContractId, dto);
            return Ok(result);
        }

        [HttpGet]
        [Route("UpdateInstallment")]
        public async Task<IActionResult> UpdateInstallment(int id)
        {
            var result = _installmentRepository.UpdateInstallment(id);
            return Ok(result);
        }


        [HttpGet]
        [Route("GetAllInstallmentByContractId")]
        public async Task<IActionResult> GetAllInstallmentByContractId(int ContractId)
        {
            var result = _installmentRepository.GetAllInstallmentByContractId(ContractId);
            return Ok(result);
        }

        #endregion Installment

    }
}
