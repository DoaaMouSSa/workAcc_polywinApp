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
    public class BanqueController : ControllerBase
    {
        private readonly IBanqueRepository _banqueRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BanqueController(IBanqueRepository banqueRepository, IWebHostEnvironment webHostEnvironment)
        {
            _banqueRepository = banqueRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        //المعاملات اليوميه الى بتحصل فى الخزينه
        #region banque
        [HttpPost]
        [Route("AddEditBanque")]
        public Task<Response<DtoBanque>> AddEditBanque(DtoBanque dtoBanque)
        {
           
            var Bank = _banqueRepository.AddEditBanque(dtoBanque);
            return Bank;
        }

        [HttpGet]
        [Route("getBanque")]
        public Task<Response<List<DtoBankForDepositForShow>>> getBanque()
        {

            var Bank = _banqueRepository.getBanque();
            return Bank;
        }

        [HttpGet]
        [Route("DeleteBanque")]
        public Task<Response<bool>> DeleteBanque(string ids)
        {
            var Bank = _banqueRepository.DeleteBanque(ids);
            return Bank;
        }
        [HttpPost]
        [Route("AddDeposit")]
        public Task<Response<DtoBankForDepositForAdd>> AddDeposit([FromForm] DtoBankForDepositForAdd dto)
        {
            if (dto.logo != null)
            {
                dto.LogoPath = ProcessUploadedFileOfCheck(dto.logo);
            }
            var Bank = _banqueRepository.AddDeposit(dto);
            return Bank;
        }
        [HttpPost]
        [Route("DecreaseDeposit")]
        public Task<Response<DtoBankForDepositForAdd>> DecreaseDeposit([FromForm] DtoBankForDepositForAdd dto)
        {
            if (dto.logo != null)
            {
                dto.LogoPath = ProcessUploadedFileOfCheck(dto.logo);
            }
            var Bank = _banqueRepository.DecreaseDeposit(dto);
            return Bank;
        }
        private string ProcessUploadedFileOfCheck(IFormFile Photo)
        {
            try
            {
                if (Photo != null)
                {
                    if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\Checks"))
                    {
                        Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\Checks");
                    }

                    var path = _webHostEnvironment.WebRootPath + "\\Checks\\" + Photo.FileName;

                    using (FileStream fileStream = System.IO.File.Create(path))
                    {
                        Photo.CopyTo(fileStream);

                        fileStream.Flush();

                        int length = (path.Length - path.IndexOf("Checks"));

                        string newpath = path.Substring(path.IndexOf("Checks"), length);

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
