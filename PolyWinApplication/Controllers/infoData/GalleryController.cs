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
    public class GalleryController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IGalleryRepository _galleryRepository;

        public GalleryController(IGalleryRepository galleryRepository, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _galleryRepository = galleryRepository;
        }


        #region Gallery

        [HttpPost]
        [Route("AddEditGallery")]
        public async Task<IActionResult> AddEditGallery([FromForm] DtoGalleryViewModal dto)
        {
            if (dto.fileUpload != null)
            {
                dto.filePath = ProcessUploadedFileOfGallery(dto.fileUpload);

                var result = _galleryRepository.AddEditGalleryImage(dto);

                return Ok(result);
            }
            else
            {
                var result = _galleryRepository.AddEditGalleryImage(dto);

                return Ok(result);
            }
        }

        [HttpGet]
        [Route("DeleteGallery")]
        public async Task<IActionResult> DeleteGallery(string id)
        {
            var result = _galleryRepository.DeleteGallery(id);

            return Ok(result);
        }


        [HttpGet]
        [Route("GetAllGallery")]
        public async Task<IActionResult> GetAllGallery(int type)
        {
            var result = _galleryRepository.GetAllGallery(type);

            return Ok(result);
        }
        private string ProcessUploadedFileOfGallery(IFormFile Photo)
        {
            try
            {
                if (Photo != null)
                {
                    if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\Gallery"))
                    {
                        Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\Gallery");
                    }

                    var path = _webHostEnvironment.WebRootPath + "\\Gallery\\" + Photo.FileName;

                    using (FileStream fileStream = System.IO.File.Create(path))
                    {
                        Photo.CopyTo(fileStream);

                        fileStream.Flush();

                        int length = (path.Length - path.IndexOf("Gallery"));

                        string newpath = path.Substring(path.IndexOf("Gallery"), length);

                        newpath = newpath.Replace('\\', '/');

                        return newpath;
                    }
                }

                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion

    }
}
