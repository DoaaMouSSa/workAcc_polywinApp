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
    public class DiscountController : ControllerBase
    {
        private readonly IDescountRepository _descountRepository;

        public DiscountController(IInstallmentRepository installmentRepository,
            IDescountRepository descountRepository
            )
        {

            _descountRepository = descountRepository;
           
        }


      



        #region Descount

        [HttpGet]
        [Route("GetAllDescount")]
        public async Task<IActionResult> GetAllDescount()
        {
            var Descount = _descountRepository.GetAllDescount();
            return Ok(Descount);
        }

        [HttpGet]
        [Route("GetDescountByType")]
        public async Task<IActionResult> GetDescountByType(int UserType)
        {
            var Descount = _descountRepository.GetDescountByType(UserType);
            return Ok(Descount);
        }

        [HttpPost]
        [Route("AddDescount")]
        public async Task<IActionResult> AddDescount(DtoDescountAdded dtoDescountAdded)
        {
            var descount = _descountRepository.AddDescount(dtoDescountAdded);

            return Ok(descount);
        }

        [HttpPost]
        [Route("AddEditDescount")]
        public async Task<IActionResult> AddEditDescount(DtoDescountEdit dtoDescountAdded)
        {
            var descount = _descountRepository.AddEditDescount(dtoDescountAdded);

            return Ok(descount);
        }


        [HttpGet]
        [Route("DeleteDescount")]
        public async Task<IActionResult> DeleteDescount(string Id)
        {
            var Descount = _descountRepository.DeleteDescount(Id);
            return Ok(Descount);
        }

        #endregion

    }
}
