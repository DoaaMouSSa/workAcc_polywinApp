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
    public class CategoryChildGalleryController : ControllerBase
    {

        private readonly ICategoryChildGalleryRepository _categoryChildGalleryRepository;


        public CategoryChildGalleryController(ICategoryChildGalleryRepository categoryChildGalleryRepository)
        {

            _categoryChildGalleryRepository = categoryChildGalleryRepository;

        }

        #region CategoryChildGallery
        [HttpGet]
        [Route("GetAllCategoryChildGallery")]
        public async Task<IActionResult> GetAllCategoryChildGallery()
        {
            var result = _categoryChildGalleryRepository.GetAllCategoryChildGallery();

            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllCategoryChildGalleryForDrop")]
        public async Task<IActionResult> GetAllCategoryChildGalleryForDrop()
        {
            var result = _categoryChildGalleryRepository.GetAllCategoryChildGalleryForDrop();

            return Ok(result);
        }

        [HttpPost]
        [Route("AddEditCategoryChildGallery")]
        public async Task<IActionResult> AddEditCategoryChildGallery(DtoCategoryChildGallery dtoCategoryGallery)
        {
            var result = _categoryChildGalleryRepository.AddEditCategoryName(dtoCategoryGallery);

            return Ok(result);
        }

        [HttpGet]
        [Route("DeleteCategoryChildGallery")]
        public async Task<IActionResult> DeleteCategoryChildGallery(string id)
        {
            var result = _categoryChildGalleryRepository.DeleteCategoryName(id);

            return Ok(result);
        }

        #endregion CategoryChildGallery
    }
}
