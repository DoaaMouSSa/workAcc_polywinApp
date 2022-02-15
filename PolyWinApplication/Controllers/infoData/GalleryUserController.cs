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
    public class GalleryUserController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IGallaryUserRepository _gallaryUserRepository;


        public GalleryUserController(IWebHostEnvironment webHostEnvironment, IGallaryUserRepository gallaryUserRepository)
        {
            _gallaryUserRepository = gallaryUserRepository;
            _webHostEnvironment = webHostEnvironment;
        }








        #region Gallery

        [HttpPost]
        [Route("AddGalleryUser")]
        public async Task<IActionResult> AddGalleryUser(int? contractItemId, List<IFormFile> files)
        {
            if (files.Count > 0)
            {
                var obj = new List<DtoGalleryUser>();

                foreach (var item in files)
                {
                    if (item != null)
                    {
                        var objRow = new DtoGalleryUser();
                        string PhotoPath = ProcessUploadedFileOfGalleryUser(item);

                        objRow.PhotoPath = PhotoPath;

                        obj.Add(objRow);
                    }
                }

                var result = _gallaryUserRepository.AddGalleryByContract(contractItemId, obj);

                return Ok(result);
            }

            return Ok("No File Uploaded");
        }

        [HttpGet]
        [Route("GetAllGalleryByContractId")]
        public async Task<IActionResult> GetAllGalleryByContractId(int ContractId)
        {
            var result = _gallaryUserRepository.GetAllGalleryByContractId(ContractId);

            return Ok(result);
        }

        [HttpGet]
        [Route("DeleteGalleryById")]
        public async Task<IActionResult> DeleteGalleryById(int Id)
        {
            var result = _gallaryUserRepository.DeleteGalleryById(Id);

            return Ok(result);
        }

        #endregion
        private string ProcessUploadedFileOfGalleryUser(IFormFile Photo)
        {
            try
            {
                if (Photo != null)
                {
                    if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\GalleryUser"))
                    {
                        Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\GalleryUser");
                    }

                    var path = _webHostEnvironment.WebRootPath + "\\GalleryUser\\" + Photo.FileName;

                    using (FileStream fileStream = System.IO.File.Create(path))
                    {
                        Photo.CopyTo(fileStream);

                        fileStream.Flush();

                        int length = (path.Length - path.IndexOf("GalleryUser"));

                        string newpath = path.Substring(path.IndexOf("GalleryUser"), length);

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
