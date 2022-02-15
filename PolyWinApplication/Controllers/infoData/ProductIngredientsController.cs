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
    public class ProductIngredientsController : ControllerBase
    {
        private readonly IUserControlService _userControlService;
        IUserControlService userControlService;
        private readonly IProductIngredientsRepository _productIngredientsRepository;


        public ProductIngredientsController(IProductIngredientsRepository productIngredientsRepository, IUserControlService userControlService)
        {

            _productIngredientsRepository = productIngredientsRepository;
            _userControlService = userControlService;
        }
        #region _productIngredients 
        [HttpGet]
        [Route("GetAllProductIngredient")]
        public async Task<IActionResult> GetAllProductIngredient()
        {
            var prodcut = _productIngredientsRepository.GetAllProductIngredients();

            return Ok(prodcut);
        }


        [HttpGet]
        [Route("DeleteProductIngredient")]
        public async Task<IActionResult> DeleteProductIngredient(string ids)
        {
            var result = _productIngredientsRepository.DeleteProductIngredient(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("AddEditProductIngredient")]
        public async Task<IActionResult> AddEditProductIngredient(DtoProductIngredients dto)
        {
            var result = _productIngredientsRepository.AddEditProductIngredient(dto);
            return Ok(result);
        }


        [HttpGet]
        [Route("GetCalcProduct")]
        public async Task<IActionResult> GetCalcProduct(int productId, string width, string height)
        {
            var Product = _productIngredientsRepository.GetNewCalcProduct(productId, width, height);//GetCalcProduct(productId, width, height);
            return Ok(Product);
        }


        [HttpPost]
        [Route("GetTotalPriceWithItems")]
        public async Task<IActionResult> GetTotalPriceWithItems(DtoProductCost dto)
        {
            var userClaim = User.Identity as ClaimsIdentity;
            var _user = _userControlService.GetUserByName(userClaim.Name);

            var Product = _productIngredientsRepository.GetTotalPriceWithItems(dto, _user.UserType);
            return Ok(Product);
        }

        #endregion _productIngredients
    }
}
