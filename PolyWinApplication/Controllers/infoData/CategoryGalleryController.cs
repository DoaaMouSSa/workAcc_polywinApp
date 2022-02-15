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
    public class CategoryGalleryController : ControllerBase
    {
        private readonly ICategoryGalleryRepository _categoryGalleryRepository;

        public CategoryGalleryController(ICategoryGalleryRepository categoryGalleryRepository)
        {
            _categoryGalleryRepository = categoryGalleryRepository;
        }


        #region categoryGallery


        [HttpGet]
        [Route("GetAllCategoryGallery")]
        public async Task<IActionResult> GetAllCategoryGallery()
        {
            var result = _categoryGalleryRepository.GetAllCategoryGallery();

            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllCategoryGalleryForDrop")]
        public async Task<IActionResult> GetAllCategoryGalleryForDrop()
        {
            var result = _categoryGalleryRepository.GetAllCategoryGalleryForDrop();

            return Ok(result);
        }


        [HttpPost]
        [Route("AddEditCategoryName")]
        public async Task<IActionResult> AddEditCategoryName(DtoCategoryGallery dtoCategoryGallery)
        {
            var result = _categoryGalleryRepository.AddEditCategoryName(dtoCategoryGallery);

            return Ok(result);
        }

        [HttpGet]
        [Route("DeleteCategoryGallery")]
        public async Task<IActionResult> DeleteCategoryGallery(string id)
        {
            var result = _categoryGalleryRepository.DeleteCategoryName(id);

            return Ok(result);
        }

        #endregion

    }
}
