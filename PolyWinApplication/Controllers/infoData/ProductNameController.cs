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

    public class ProductNameController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        private readonly IProductNameRepository _productNameRepository;


        public ProductNameController(IProductNameRepository productNameRepository, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _productNameRepository = productNameRepository;

        }

        #region ProductName

        [HttpGet]
        [Route("GetAllProductName")]
        [AllowAnonymous]
        public IActionResult GetAllProductName()
        {
            var result = _productNameRepository.GetAllProductName();
            return Ok(result);
        }


        [HttpGet]
        [Route("DeleteProductName")]
        public IActionResult DeleteProductName(string ids)
        {
            var result = _productNameRepository.DeleteProductName(ids);
            return Ok(result);
        }

        [HttpPost]
        [Route("AddEditProductName")]
        public IActionResult AddEditProductName([FromForm] DtoProductName dto)
        {
            if (dto.fileUpload != null)
            {
                dto.ImgURL = ProcessUploadedFileOfProducts(dto.fileUpload);
            }
            var result = _productNameRepository.AddEditProductName(dto);
            return Ok(result);
        }

        #endregion ProductName
        private string ProcessUploadedFileOfProducts(IFormFile Photo)
        {
            try
            {
                if (Photo != null)
                {
                    if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\Products"))
                    {
                        Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\Products");
                    }

                    var path = _webHostEnvironment.WebRootPath + "\\Products\\" + Photo.FileName;

                    using (FileStream fileStream = System.IO.File.Create(path))
                    {
                        Photo.CopyTo(fileStream);

                        fileStream.Flush();

                        int length = (path.Length - path.IndexOf("Products"));

                        string newpath = path.Substring(path.IndexOf("Products"), length);

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
