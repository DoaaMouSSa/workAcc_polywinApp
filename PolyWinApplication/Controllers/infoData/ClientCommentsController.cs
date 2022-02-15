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
    public class ClientCommentsController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IClientOpinionRepository _clientOpinionRepository;

        public ClientCommentsController(
            IWebHostEnvironment webHostEnvironment,
            IClientOpinionRepository clientOpinionRepository
            )
        {
            _webHostEnvironment = webHostEnvironment;
            _clientOpinionRepository = clientOpinionRepository;
            
            
        }


     
        #region ClientComments
        [HttpGet]
        [Route("GetAllClientOpinions")]
        public async Task<IActionResult> GetAllClientOpinions()
        {
            var ClientComm = _clientOpinionRepository.GetAllClientsOpinion();
            return Ok(ClientComm);
        }


        [HttpPost]
        [Route("AddEditClientOpinions")]
        public async Task<IActionResult> AddEditClientOpinions([FromForm] DtoClientsOpinions dto)
        {
            if (dto.Img != null)
            {
                dto.ImgPath = ProcessUploadedFileOfClientComm(dto.Img);
            }

            if (dto.Vid != null)
            {
                dto.VidPath = ProcessUploadedFileVideoOfClientComm(dto.Vid);
            }

            var result = _clientOpinionRepository.AddEditClientsOpinion(dto);

            return Ok(result);
        }
        [HttpGet]
        [Route("DeleteClientOpinions")]
        public async Task<IActionResult> DeleteClientOpinions(string Ids)
        {
            var result = _clientOpinionRepository.DeleteClientsOpinion(Ids);

            return Ok(result);
        }
        #endregion
        private string ProcessUploadedFileVideoOfClientComm(IFormFile Video)
        {
            try
            {
                if (Video != null)
                {
                    if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\ClientCommVid"))
                    {
                        Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\ClientCommVid");
                    }

                    var Vidpath = _webHostEnvironment.WebRootPath + "\\ClientCommVid\\" + Video.FileName;

                    using (FileStream fileStream = System.IO.File.Create(Vidpath))
                    {
                        Video.CopyTo(fileStream);

                        fileStream.Flush();

                        int length = (Vidpath.Length - Vidpath.IndexOf("ClientCommVid"));

                        string Vidnewpath = Vidpath.Substring(Vidpath.IndexOf("ClientCommVid"), length);

                        Vidnewpath = Vidnewpath.Replace('\\', '/');

                        return Vidnewpath;
                    }
                }

                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        private string ProcessUploadedFileOfClientComm(IFormFile Photo)
        {
            try
            {
                if (Photo != null)
                {
                    if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\ClientComm"))
                    {
                        Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\ClientComm");
                    }

                    var Imgpath = _webHostEnvironment.WebRootPath + "\\ClientComm\\" + Photo.FileName;

                    using (FileStream fileStream = System.IO.File.Create(Imgpath))
                    {
                        Photo.CopyTo(fileStream);

                        fileStream.Flush();

                        int length = (Imgpath.Length - Imgpath.IndexOf("ClientComm"));

                        string Imgnewpath = Imgpath.Substring(Imgpath.IndexOf("ClientComm"), length);

                        Imgnewpath = Imgnewpath.Replace('\\', '/');

                        return Imgnewpath;
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
