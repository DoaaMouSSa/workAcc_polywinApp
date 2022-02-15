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
using System.Threading.Tasks;


namespace PolyWinApplication.Controllers.infoData
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class ParentProductCategoryController : ControllerBase
    {
      
        private readonly IParentProductCategoryRepository _parentProductCategoryRepository;
    

        public ParentProductCategoryController(IParentProductCategoryRepository parentProductCategoryRepository)
        {
            _parentProductCategoryRepository = parentProductCategoryRepository;
        }
        #region ParentProductCategory

        [HttpGet]
        [Route("GetAllParentProductCategory")]
        public IActionResult GetAllParentProductCategory()
        {
            var result = _parentProductCategoryRepository.GetAllParentProductCategory();
            return Ok(result);
        }


        [HttpGet]
        [Route("DeleteParentProductCategory")]
        public IActionResult DeleteParentProductCategory(string ids)
        {
            var result = _parentProductCategoryRepository.DeleteParentProductCategory(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("AddEditParentProductCategory")]
        public IActionResult AddEditParentProductCategory(DtoParentProductCategory dto)
        {
            var result = _parentProductCategoryRepository.AddEditParentProductCategory(dto);
            return Ok(result);
        }

        #endregion ParentProductCategory
    }
}
