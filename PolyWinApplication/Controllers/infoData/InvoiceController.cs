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
    public class InvoiceController : ControllerBase
    {
        private readonly IUserControlService _userControlService;

        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IInvoiceDetailsRepository _invoiceDetailsRepository;

        public InvoiceController(
            IUserControlService userControlService, IInvoiceRepository invoiceRepository, IInvoiceDetailsRepository invoiceDetailsRepository)
        {
            _invoiceRepository = invoiceRepository;
            _userControlService = userControlService;
            _invoiceDetailsRepository = invoiceDetailsRepository;
        }
        #region  invoice 

        [HttpGet]
        [Route("GetMaxNumberIncoices")]
        public async Task<IActionResult> GetMaxNumberIncoices()
        {
            var result = await _invoiceRepository.GetMaxNumberIncoices();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllInvoices")]
        public async Task<IActionResult> GetAllInvoices(bool? isResived)
        {
            var result = await _invoiceRepository.GetAllInvoicesByResived(isResived);
            return Ok(result);
        }

        [HttpPost]
        [Route("AddNewInvoices")]
        public async Task<IActionResult> AddNewInvoices(DtoInvoice dtoInvoice)
        {
            var userClaim = User.Identity as ClaimsIdentity;
            var _user = _userControlService.GetUserByName(userClaim.Name);

            var result = await _invoiceRepository.AddNewInvoices(dtoInvoice, _user);
            return Ok(result);
        }


        [HttpGet]
        [Route("GetAllInvoicesFromPolyWin")]
        public async Task<IActionResult> GetAllInvoicesFromPolyWin(int? isRecived)
        {
            var userClaim = User.Identity as ClaimsIdentity;
            var _user = _userControlService.GetUserByName(userClaim.Name);

            var result = await _invoiceRepository.GetAllInvoicesFromPolyWin(isRecived, _user);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllInvoicesByRecived")]
        public async Task<IActionResult> GetAllInvoicesByRecived(int? isRecived)
        {
            var userClaim = User.Identity as ClaimsIdentity;
            var _user = _userControlService.GetUserByName(userClaim.Name);

            var result = await _invoiceRepository.GetAllInvoicesByRecived(isRecived, _user);
            return Ok(result);
        }


        [HttpGet]
        [Route("GetAllInvoicesFromAgentOrWorkShop")]
        public async Task<IActionResult> GetAllInvoicesFromAgentOrWorkShop(int? isRecived)
        {
            var userClaim = User.Identity as ClaimsIdentity;
            var _user = _userControlService.GetUserByName(userClaim.Name);

            var result = await _invoiceRepository.GetAllInvoicesFromAgentOrWorkShop(isRecived, _user);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetStatisticsForAgent")]
        public async Task<IActionResult> GetStatisticsForAgent(int userType)
        {
            var result = await _invoiceRepository.GetStatisticsForAgent(userType);
            return Ok(result);
        }

        [HttpGet]
        [Route("UpdateInvoices")]
        public async Task<IActionResult> UpdateInvoices(int invoiceId, string description, bool isRecived, double? totalinvoices, double? descount, double? totalwithdescount)
        {
            var result = await _invoiceRepository.UpdateInvoices(invoiceId, description, isRecived, totalinvoices, descount, totalwithdescount);

            if (result.payload == true)
            {
                _invoiceDetailsRepository.UpdateInvoicesDetailsWithInvoices(invoiceId, isRecived, description);
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("UpdateQuantityInvoicesDetails")]
        public async Task<IActionResult> UpdateQuantityInvoicesDetails(int Id, int Qty)
        {
            var result = _invoiceDetailsRepository.UpdateQuantityInvoicesDetails(Id, Qty);

            return Ok(result);
        }

        #endregion invoice

        #region invoicesDetails

        [HttpPost]
        [Route("AddInvoicesDetails")]
        public async Task<IActionResult> AddInvoicesDetails(int invoiceId, List<DtoInvoiceDetails> dtoInvoiceDetails)
        {
            var result = await _invoiceDetailsRepository.AddInvoicesDetails(invoiceId, dtoInvoiceDetails);

            return Ok(result);
        }

        [HttpGet]
        [Route("GetInvoicesDetailsByInvoiceId")]
        public async Task<IActionResult> GetInvoicesDetailsByInvoiceId(int invoiceId)
        {
            var user = await _invoiceDetailsRepository.GetInvoicesDetails(invoiceId);
            return Ok(user);
        }

        [HttpPost]
        [Route("UpdateInvoicesDetails")]
        public async Task<IActionResult> UpdateInvoicesDetails(int invoiceId, List<DtoUpdateInvoiceDetails> ids)
        {
            var user = await _invoiceDetailsRepository.UpdateInvoicesDetails(ids);

            if (user == true)
            {
                _invoiceRepository.UpdateInvoicesRescived(invoiceId);
            }


            return Ok(user);
        }

        [HttpPost]
        [Route("DeleteInvoices")]
        public async Task<IActionResult> DeleteInvoices(string ids)
        {
            var user = _invoiceRepository.DeleteInvoices(ids);

            return Ok(user);
        }

        #endregion
    }
}
