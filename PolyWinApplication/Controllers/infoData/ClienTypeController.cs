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
    public class ClienTypeController : ControllerBase
    {
        private readonly IClientTypeRepository _clientTypeRepository;
    

        public ClienTypeController(IClientTypeRepository clientTypeRepository)
        {

            _clientTypeRepository = clientTypeRepository;

        }




        #region clienType
        [HttpGet]
        [Route("GetAllClientType")]
        public async Task<IActionResult> GetAllClientType()
        {
            var result = _clientTypeRepository.GetAllClientType();

            return Ok(result);
        }
        #endregion


    }
}
