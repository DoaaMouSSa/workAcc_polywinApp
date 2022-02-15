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
using System.Threading.Tasks;

namespace PolyWinApplication.Controllers.infoData
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ColorsController : ControllerBase
    {

        private readonly IColorsRepository _ColorsRepository;



        public ColorsController(
            IColorsRepository ColorsRepository
    

            )
        {

            _ColorsRepository = ColorsRepository;
          
        }
        #region Colors

        [HttpGet]
        [Route("GetAllColors")]
        public IActionResult GetAllColors()
        {
            var result = _ColorsRepository.GetAllColors();
            return Ok(result);
        }
        [HttpGet]
        [Route("GetColorsForWorkShop")]
        public IActionResult GetColorsForWorkShop()
        {
            var result = _ColorsRepository.GetColorsForWorkShop();
            return Ok(result);
        }

        [HttpGet]
        [Route("DeleteColors")]
        public IActionResult DeleteColors(string ids)
        {
            var result = _ColorsRepository.DeleteColors(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("AddEditColors")]
        public IActionResult AddEditColors(DtoColors dto)
        {
            var result = _ColorsRepository.AddEditColors(dto);
            return Ok(result);
        }

        #endregion  Colors
    }
}
