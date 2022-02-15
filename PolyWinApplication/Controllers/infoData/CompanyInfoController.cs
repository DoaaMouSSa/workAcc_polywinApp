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
    public class CompanyInfoController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ICompanyInfoRepository _companyInfoRepository;


        public CompanyInfoController(ICompanyInfoRepository companyInfoRepository, IWebHostEnvironment webHostEnvironment)
        {
            _companyInfoRepository = companyInfoRepository;
            _webHostEnvironment = webHostEnvironment;
        }








        #region CompanyInfo
        [AllowAnonymous]
        [HttpGet]
        [Route("GetCompanyInfo")]
        public async Task<IActionResult> GetCompanyInfo()
        {
            var result = _companyInfoRepository.GetCompanyInfo();

            return Ok(result);
        }


        [HttpPost]
        [Route("AddEditCompanyInfo")]
        public async Task<IActionResult> AddEditCompanyInfo([FromForm] DtoCompanyInfo dto)
        {
            if (dto.file != null)
            {
                dto.CompanyFile = ProcessUploadedFileOfCompanyInfo(dto.file);
            }

            var result = _companyInfoRepository.AddEditCompanyInfo(dto);

            return Ok(result);
        }

        #endregion
        private string ProcessUploadedFileOfCompanyInfo(IFormFile Photo)
        {
            try
            {
                if (Photo != null)
                {
                    if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\CompanyInfo"))
                    {
                        Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\CompanyInfo");
                    }

                    var path = _webHostEnvironment.WebRootPath + "\\CompanyInfo\\" + Photo.FileName;

                    using (FileStream fileStream = System.IO.File.Create(path))
                    {
                        Photo.CopyTo(fileStream);

                        fileStream.Flush();

                        int length = (path.Length - path.IndexOf("CompanyInfo"));

                        string newpath = path.Substring(path.IndexOf("CompanyInfo"), length);

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
