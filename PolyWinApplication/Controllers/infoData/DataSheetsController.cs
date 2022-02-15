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
    public class DataSheetsController : ControllerBase
    {
        private readonly IDataSheetsRepository _dataSheetsRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DataSheetsController(IWebHostEnvironment webHostEnvironment, IDataSheetsRepository dataSheetsRepository)
        {
            _dataSheetsRepository = dataSheetsRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        #region DataSheets
        [AllowAnonymous]
        [HttpGet]
        [Route("GetAllDataSheet")]
        public async Task<IActionResult> GetAllDataSheet()
        {
            var result = _dataSheetsRepository.GetAllDataSheets();

            return Ok(result);
        }

        [HttpPost]
        [Route("AddEditDataSheets")]
        public async Task<IActionResult> AddEditDataSheets([FromForm] DtoDataSheets dto)
        {
            if (dto.fileUpload != null)
            {
                dto.ImagePath = ProcessUploadedFileOfDataSheets(dto.fileUpload);

                var result = _dataSheetsRepository.AddEditDataSheets(dto);

                return Ok(result);
            }
            else
            {
                var result = _dataSheetsRepository.AddEditDataSheets(dto);

                return Ok(result);
            }

            //return Ok();
        }

        [HttpGet]
        [Route("DeleteDataSheets")]
        public async Task<IActionResult> DeleteDataSheets(string ids)
        {
            var result = _dataSheetsRepository.DeleteDataSheets(ids);

            return Ok(result);
        }
        private string ProcessUploadedFileOfDataSheets(IFormFile Photo)
        {
            try
            {
                if (Photo != null)
                {
                    if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\DataSheets"))
                    {
                        Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\DataSheets");
                    }

                    var path = _webHostEnvironment.WebRootPath + "\\DataSheets\\" + Photo.FileName;

                    using (FileStream fileStream = System.IO.File.Create(path))
                    {
                        Photo.CopyTo(fileStream);

                        fileStream.Flush();

                        int length = (path.Length - path.IndexOf("DataSheets"));

                        string newpath = path.Substring(path.IndexOf("DataSheets"), length);

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
