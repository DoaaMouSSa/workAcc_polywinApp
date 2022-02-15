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
    public class FactoringController : ControllerBase
    {
        private readonly IFactorRepository _factorRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FactoringController(IWebHostEnvironment webHostEnvironment, IFactorRepository factorRepository)
        {
            _webHostEnvironment = webHostEnvironment;
            _factorRepository = factorRepository;
        }




        #region Factoring 
        [AllowAnonymous]
        [HttpGet]
        [Route("GetAllFactor")]
        public async Task<IActionResult> GetAllFactor()
        {
            var Factor = _factorRepository.GetAllFactor();
            return Ok(Factor);
        }


        [HttpPost]
        [Route("AddEditFactor")]
        public async Task<IActionResult> AddEditFactor([FromForm] DtoFactor dto)
        {
            if (dto.file != null)
            {
                dto.filePath = ProcessUploadedFileOfFactor(dto.file);
            }

            if (dto.logo != null)
            {
                dto.LogoPath = ProcessUploadedFileOfFactor(dto.logo);
            }

            var result = _factorRepository.AddEditFactor(dto);

            return Ok(result);
        }
        [HttpGet]
        [Route("DeleteFactor")]
        public async Task<IActionResult> DeleteFactor(string Ids)
        {
            var result = _factorRepository.DeleteFactor(Ids);

            return Ok(result);
        }
        #endregion
        private string ProcessUploadedFileOfFactor(IFormFile Photo)
        {
            try
            {
                if (Photo != null)
                {
                    if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\Factor"))
                    {
                        Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\Factor");
                    }

                    var path = _webHostEnvironment.WebRootPath + "\\Factor\\" + Photo.FileName;

                    using (FileStream fileStream = System.IO.File.Create(path))
                    {
                        Photo.CopyTo(fileStream);

                        fileStream.Flush();

                        int length = (path.Length - path.IndexOf("Factor"));

                        string newpath = path.Substring(path.IndexOf("Factor"), length);

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
    }
}
