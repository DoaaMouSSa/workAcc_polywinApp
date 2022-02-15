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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
  
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IWarrantyContractsRepository _warrantyContractsRepository;
        private readonly IUserControlService _userControlService;


        public CategoryController(IInstallmentRepository installmentRepository,
            IWarrantyContractsRepository warrantyContractsRepository,
            IWebHostEnvironment webHostEnvironment,
            ICategoryRepository categoryRepository,
           IUserControlService userControlService

            )
        {
            _warrantyContractsRepository = warrantyContractsRepository;
            _webHostEnvironment = webHostEnvironment;
            _categoryRepository = categoryRepository;
            _userControlService = userControlService;
        }

        [HttpGet]
        [Route("GetAllCategory")]
        public Response<List<DTOCategory>> GetAllCategory()
        {
            var user = _categoryRepository.GetAllCategory();
            return user;
        }

        [HttpGet]
        [Route("GetAllCategoryForDrop")]
        public Response<List<DTOCategory>> GetAllCategoryForDrop()
        {
            var user = _categoryRepository.GetAllCategoryForDrop();
            return user;
        }

        [HttpGet]
        [Route("GetAllCategoryWithProduct")]
        public async Task<IActionResult> GetAllCategoryWithProduct()
        {
            var user = await _categoryRepository.GetAllCategoryWithProduct();
            return Ok(user);
        }

        [HttpGet]
        [Route("GetCateoryType")]
        public Response<List<DTOCategoryNamed>> GetCategoryType()
        {
            var Cateory = _categoryRepository.GetCategoryType();
            return Cateory;
        }

        [HttpPost]
        [Route("AddEditCategory")]
        public Response<DTOCategoryAddEdit> AddEditCategory(DTOCategoryAddEdit dTOCategoryAddEdit)
        {
            var Cateory = _categoryRepository.AddEditCategory(dTOCategoryAddEdit);
            return Cateory;
        }

        [HttpGet]
        [Route("DeleteCategory")]
        public Response<bool> DeleteCategory(string ids)
        {
            var Cateory = _categoryRepository.DeleteCategory(ids);
            return Cateory;
        }


        [HttpGet]
        [Route("GetParenrCategorywithProduct")]
        public Response<List<DtoGroupCategoryWithProduct>> GetParenrCategorywithProduct()
        {
            var userClaim = User.Identity as ClaimsIdentity;
            var _user = _userControlService.GetUserByName(userClaim.Name);

            var Cateory = _categoryRepository.GetParenrCategorywithProduct(_user);
            return Cateory;
        }
    }
}
