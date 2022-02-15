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
    public class CatalogController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ICatalogueRepository _catalogueRepository;


        public CatalogController(ICatalogueRepository catalogueRepository, IWebHostEnvironment webHostEnvironment)
        {
            _catalogueRepository = catalogueRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        #region Catalogue
        [AllowAnonymous]
        [HttpGet]
        [Route("GetAllCatalogue")]
        public async Task<IActionResult> GetAllCatalogue()
        {
            var result = _catalogueRepository.GetAllCatalogue();

            return Ok(result);
        }

        [HttpPost]
        [Route("AddEditCatalogue")]
        public async Task<IActionResult> AddEditCatalogue([FromForm] DtoCatalogue dto)
        {
            if (dto.file != null)
            {
                dto.filePath = ProcessUploadedFileOfCatalogue(dto.file);
            }

            if (dto.logo != null)
            {
                dto.LogoPath = ProcessUploadedFileOfCatalogue(dto.logo);
            }

            var result = _catalogueRepository.AddEditCatalogue(dto);

            return Ok(result);
        }

        [HttpGet]
        [Route("DeleteCatalogue")]
        public async Task<IActionResult> DeleteCatalogue(string Ids)
        {
            var result = _catalogueRepository.DeleteCatalogue(Ids);

            return Ok(result);
        }
        private string ProcessUploadedFileOfCatalogue(IFormFile Photo)
        {
            try
            {
                if (Photo != null)
                {
                    if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\Catalogue"))
                    {
                        Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\Catalogue");
                    }

                    var path = _webHostEnvironment.WebRootPath + "\\Catalogue\\" + Photo.FileName;

                    using (FileStream fileStream = System.IO.File.Create(path))
                    {
                        Photo.CopyTo(fileStream);

                        fileStream.Flush();

                        int length = (path.Length - path.IndexOf("Catalogue"));

                        string newpath = path.Substring(path.IndexOf("Catalogue"), length);

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
