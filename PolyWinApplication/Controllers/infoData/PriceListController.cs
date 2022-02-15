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
    public class PriceListController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IPriceListRepository _priceListRepository;

        public PriceListController(IWebHostEnvironment webHostEnvironment, IPriceListRepository priceListRepository)
        {
            _webHostEnvironment = webHostEnvironment;
            _priceListRepository = priceListRepository;
        }






        #region PriceLst 
        [HttpGet]
        [Route("GetAllPriceLst")]
        public async Task<IActionResult> GetAllPriceLst()
        {
            var PriceLst = _priceListRepository.GetAllPriceLst();
            return Ok(PriceLst);
        }


        [HttpPost]
        [Route("AddEditPriceLst")]
        public async Task<IActionResult> AddEditPriceLst([FromForm] DtoPriceList dto)
        {
            if (dto.file != null)
            {
                dto.filePath = ProcessUploadedFileOfPriceLst(dto.file);
            }

            if (dto.logo != null)
            {
                dto.LogoPath = ProcessUploadedFileOfPriceLst(dto.logo);
            }

            var result = _priceListRepository.AddEditPriceLst(dto);

            return Ok(result);
        }
        [HttpGet]
        [Route("DeletePriceLst")]
        public async Task<IActionResult> DeletePriceLst(string Ids)
        {
            var result = _priceListRepository.DeletePriceLst(Ids);

            return Ok(result);
        }
        #endregion
        private string ProcessUploadedFileOfPriceLst(IFormFile Photo)
        {
            try
            {
                if (Photo != null)
                {
                    if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\PriceLst"))
                    {
                        Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\PriceLst");
                    }

                    var path = _webHostEnvironment.WebRootPath + "\\PriceLst\\" + Photo.FileName;

                    using (FileStream fileStream = System.IO.File.Create(path))
                    {
                        Photo.CopyTo(fileStream);

                        fileStream.Flush();

                        int length = (path.Length - path.IndexOf("PriceLst"));

                        string newpath = path.Substring(path.IndexOf("PriceLst"), length);

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
