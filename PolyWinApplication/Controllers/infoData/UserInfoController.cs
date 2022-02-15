using IPloyWinRepository.InterFace;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using PloyWinContext.Entities;
using PloyWinDto.Dto;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static PloyWinRepository.EnumData.StaticApiStatus;
namespace PolyWinApplication.Controllers.infoData
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserInfoController : ControllerBase
    {
        private readonly IAgentRepository _agentRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUserControlService _userControlService;
        private readonly IDescountRepository _descountRepository;
        private readonly IConfiguration _configuration;

        public UserInfoController(IAgentRepository agentRepository,
            IWebHostEnvironment webHostEnvironment,
            IUserControlService userControlService , IDescountRepository descountRepository, IConfiguration configuration
            )
        {
            _webHostEnvironment = webHostEnvironment;
            _userControlService = userControlService;
            _agentRepository = agentRepository;
            _descountRepository = descountRepository; _configuration = configuration;

        }


        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {

            var user = _userControlService.CheckValidUser(model.UserName, model.Password);
            // var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null)
            {
                //if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
                //{
                //if (user.device_id != "")
                //{
                //    user.device_id = model.device_id;
                //    var userLogin = FindBy(x => x.Id == user.Id).FirstOrDefault();
                //}
                var authClaims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("Id", user.Id.ToString()),
                    new Claim("UserName", user.UserName),
                };

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:Issuer"],
                    audience: _configuration["JWT:Audience"],
                    expires: DateTime.Now.AddDays(7),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );
                return Ok(new Response<User>
                {
                    code = "200",
                    message = "Sucess Login",
                    status = ApiSuccess.Status,
                    payload = new User()
                    {
                        Token = new JwtSecurityTokenHandler().WriteToken(token),
                        EndDate = token.ValidTo,
                        UserName = user.UserName,
                        Email = user.Email,
                        UserId = user.Id,
                        UserType = user.UserType,
                        ListDescount = _descountRepository.GetDescountByType(user.UserType),
                    }
                });
                //  }
            }


            Response<string> response = new Response<string>();
            response.code = "401";
            response.message = "Un Auth";
            response.status = ApiFaild.Status;
            return Unauthorized(response);
        }

        #region Users

        [HttpPost]
        [Route("ChangePassword")]
        public async Task<bool> ChangePassword([FromBody] ChanagePasswordViewModel model)
        {
            var currentUserName = HttpContext.User.Identity.Name.ToString();
            var response = await _userControlService.ChangePassword(currentUserName, model);

            return response;
        }


        [HttpGet]
        [Route("GetUserNotActive")]
        public async Task<IActionResult> GetUserNotActive()
        {
            var user = await _userControlService.GetUserNotActive();
            return Ok(user);
        }

        [HttpGet]
        [Route("ActiveAccounts")]
        public async Task<IActionResult> ActiveAccounts(string ids)
        {
            var user = await _userControlService.ActiveAccounts(ids);
            return Ok(user);
        }

        [HttpGet]
        [Route("ActiveNotActiveAccounts")]
        public async Task<IActionResult> ActiveNotActiveAccounts(string ids)
        {
            var user = await _userControlService.ActiveNotActiveAccounts(ids);
            return Ok(user);
        }

        [HttpGet]
        [Route("ResetPassword")]
        public async Task<IActionResult> ResetPassword(string ids)
        {
            string token = Request.Headers[HeaderNames.Authorization];

            string[] newtoken = token.Split(" ");

            var user = await _userControlService.ResetPassword(ids, newtoken[1]);
            return Ok(user);
        }

        [HttpPost]
        [Route("CreateNewAccount")]
        public async Task<IActionResult> CreateNewAccount([FromForm] DtoUserAndAgent user)
        {
            var userClaim = User.Identity as ClaimsIdentity;
            var managerId = _userControlService.GetUserByName(userClaim.Name);
            var _user = await _userControlService.InsertUser(user, managerId);

            if (_user.payload != "False")
            {
                user.agentLogo = ProcessUploadedFileOfAgent(user.Photo);
                user.userId = user.userId;

                var result = _agentRepository.AddNewAgent(user);
            }

            return Ok(_user);
        }


        [HttpGet]
        [Route("GetAllUserTypeAgentCount")]
        public async Task<IActionResult> GetAllUserTypeAgentCount()
        {
            var user = await _userControlService.GetAllUserTypeAgentCount();
            return Ok(user);
        }

        [HttpGet]
        [Route("GetAllUserTypeWorkShopCount")]
        public async Task<IActionResult> GetAllUserTypeWorkShopCount()
        {
            var user = await _userControlService.GetAllUserTypeWorkShopCount();
            return Ok(user);
        }

        [HttpGet]
        [Route("GetAgentInfo")]
        public async Task<IActionResult> GetAgentInfo()
        {
            var userClaim = User.Identity as ClaimsIdentity;
            var user = _userControlService.GetUserByName(userClaim.Name);

            var result = await _agentRepository.GetAgentInfo(user);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllUserTypeAgentDetails")]
        public async Task<IActionResult> GetAllUserTypeAgentDetails()
        {
            var agent = _agentRepository.GetAllUserTypeAgentDetails();
            return Ok(agent);
        }

        [HttpGet]
        [Route("GetAllUserTypeWorkShopDetails")]
        public async Task<IActionResult> GetAllUserTypeWorkShopDetails()
        {
            var agent = _agentRepository.GetAllUserTypeWorkShopDetails();
            return Ok(agent);
        }

        [HttpGet]
        [Route("GetAllAccounts")]
        public async Task<IActionResult> GetAllAccounts()
        {
            var agent = _agentRepository.GetAllAccounts();
            return Ok(agent);
        }

        [HttpPost]
        [Route("UpdateAgentInfo")]
        public async Task<IActionResult> UpdateAgentInfo([FromForm] DtoUserAndAgent user)
        {
            var userClaim = User.Identity as ClaimsIdentity;
            var _user = _userControlService.GetUserByName(userClaim.Name);

            if (user.Photo != null)
            {
                user.agentLogo = ProcessUploadedFileOfAgent(user.Photo);
            }

            var result = _agentRepository.UpdateAgentInfo(user, _user.Id);
            return Ok(result);
        }

        #endregion
        private string ProcessUploadedFileOfAgent(IFormFile Photo)
        {
            try
            {
                if (Photo != null)
                {
                    if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\img"))
                    {
                        Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\img");
                    }

                    var path = _webHostEnvironment.WebRootPath + "\\img\\" + Photo.FileName;

                    using (FileStream fileStream = System.IO.File.Create(path))
                    {
                        Photo.CopyTo(fileStream);

                        fileStream.Flush();

                        int length = (path.Length - path.IndexOf("img"));

                        string newpath = path.Substring(path.IndexOf("img"), length);

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
