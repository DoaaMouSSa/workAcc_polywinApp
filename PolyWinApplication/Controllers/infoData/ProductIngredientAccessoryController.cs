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
using System.Security.Claims;
using System.Threading.Tasks;

namespace PolyWinApplication.Controllers.infoData
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProductIngredientAccessoryController : ControllerBase
    {

        private readonly IproductIngredientAccessoryRepository _productIngredientAccessoryRepository;


        public ProductIngredientAccessoryController(IproductIngredientAccessoryRepository productIngredientAccessoryRepository)
        {

            _productIngredientAccessoryRepository = productIngredientAccessoryRepository;

        }

        #region ProductIngredientAccessory

        [HttpGet]
        [Route("GetAllProductIngredientAccessory")]
        public async Task<IActionResult> GetAllProductIngredientAccessory()
        {
            var prodcut = _productIngredientAccessoryRepository.GetAllProductIngredientAccessory();

            return Ok(prodcut);
        }


        [HttpGet]
        [Route("DeleteProductIngredientAccessory")]
        public async Task<IActionResult> DeleteProductIngredientAccessory(string ids)
        {
            var result = _productIngredientAccessoryRepository.DeleteProductIngredientAccessory(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("AddEditProductIngredientAccessory")]
        public async Task<IActionResult> AddEditProductIngredientAccessory(DtoProductIngredientAccessory dto)
        {
            var result = _productIngredientAccessoryRepository.AddEditProductIngredientAccessory(dto);
            return Ok(result);
        }

        #endregion ProductIngredientAccessory
    }
}
