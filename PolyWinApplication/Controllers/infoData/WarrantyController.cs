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
    public class WarrantyController : ControllerBase
    {
        private readonly IWarrantyContractsRepository _warrantyContractsRepository;
        private readonly IUserControlService _userControlService;
        
        public WarrantyController(
            IWarrantyContractsRepository warrantyContractsRepository,
            IUserControlService userControlService
            
            )
        {
            _warrantyContractsRepository = warrantyContractsRepository;
            _userControlService = userControlService;
        }




        #region Warranty

        [HttpPost]
        [Route("AddNewWarranty")]
        public async Task<IActionResult> AddNewWarranty(DtoWarranty dto)
        {
            var result = _warrantyContractsRepository.AddNewWarranty(dto);
            return Ok(result);
        }


        [HttpGet]
        [Route("GetAllWarrantyByClientId")]
        public async Task<IActionResult> GetAllWarrantyByClientId()
        {
            var userClaim = User.Identity as ClaimsIdentity;
            var ToUserId = _userControlService.GetUserByName(userClaim.Name);
            var result = _warrantyContractsRepository.GetAllWarrantyByClientId(ToUserId.Id);
            return Ok(result);
        }

        #endregion Warranty
    }
}
