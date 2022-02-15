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
    public class CategoryTypeController : ControllerBase
    {
        private readonly ICategoryTypeRepository _categoryTypeRepository;


        public CategoryTypeController(ICategoryTypeRepository categoryTypeRepository)
        {
            _categoryTypeRepository = categoryTypeRepository;
        }




        #region CategoryType

        [HttpGet]
        [Route("GetAllCategoryType")]
        public async Task<IActionResult> GetAllCategoryType()
        {
            var result = _categoryTypeRepository.GetAllCategoryType();

            return Ok(result);
        }


        [HttpPost]
        [Route("AddEditCategoryType")]
        public async Task<IActionResult> AddEditCategoryType(DtoCategoryType dto)
        {
            var result = _categoryTypeRepository.AddEditCategoryType(dto);

            return Ok(result);
        }

        [HttpGet]
        [Route("DeleteCategoryType")]
        public async Task<IActionResult> DeleteCategoryType(string id)
        {
            var result = _categoryTypeRepository.DeleteCategoryType(id);

            return Ok(result);
        }


        #endregion CategoryType

    }
}
