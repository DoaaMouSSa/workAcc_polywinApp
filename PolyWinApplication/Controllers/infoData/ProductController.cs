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
    public class ProductController : ControllerBase
    {
        private readonly IProductNameRepository _productNameRepository;
        private readonly IUserControlService _userControlService;
        private readonly IProductsRepository _productsRepository;
        public ProductController(IProductNameRepository productNameRepository, IUserControlService userControlService,IProductsRepository productsRepository)
        {
            _productNameRepository = productNameRepository;
            _userControlService = userControlService;
            _productsRepository = productsRepository;

        }







        #region ProductNameCodeCatJoin
        [HttpGet]
        [Route("GetAllProductNameCodeCat")]
        public IActionResult GetAllProductNameCodeCat()
        {
            var result = _productNameRepository.GetAllProductNameCodeCat();
            return Ok(result);
        }
        #endregion

        #region Product

        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var Product = await _productsRepository.GetAllProduct();
            return Ok(Product);
        }

        [HttpGet]
        [Route("GetAllProductPerCategory")]
        public async Task<IActionResult> GetAllProductPerCategory()
        {
            var userClaim = User.Identity as ClaimsIdentity;
            var _user = _userControlService.GetUserByName(userClaim.Name);

            var Product = _productsRepository.GetAllProductPerCategory(_user.UserType);
            return Ok(Product);
        }

        [HttpGet]
        [Route("SearchProduct")]
        public async Task<IActionResult> SearchProduct(string search)
        {
            var userClaim = User.Identity as ClaimsIdentity;
            var _user = _userControlService.GetUserByName(userClaim.Name);
            var Product = _productsRepository.SearchProduct(search, _user.UserType);
            return Ok(Product);
        }

        [HttpGet]
        [Route("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var Product = _productsRepository.DeleteProduct(id);
            return Ok(Product);
        }

        [HttpGet]
        [Route("GetAllProductWithColor")]
        public async Task<IActionResult> GetAllProductWithColor()
        {
            var Product = _productsRepository.GetAllProductWithColor();
            return Ok(Product);
        }


        [HttpPost]
        [Route("AddEditProduct")]
        public async Task<IActionResult> AddEditProduct(DtoProducts dtoProducts)
        {
            var Product = await _productsRepository.AddEditProduct(dtoProducts);
            return Ok(Product);
        }


        #endregion

    }
}
