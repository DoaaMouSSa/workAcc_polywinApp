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
    public class StoreController : ControllerBase
    {
        private readonly IUserControlService _userControlService;

        private readonly IStoreRepository _storeRepository;
        public StoreController(
IStoreRepository storeRepository,
                 IUserControlService userControlService

            )
        {
            _userControlService = userControlService;
            _storeRepository = storeRepository;
        }
        #region store

        [HttpGet]
        [Route("GetAllStoreByUserId")]
        public async Task<IActionResult> GetAllStoreByUserId()
        {

            var userClaim = User.Identity as ClaimsIdentity;
            var _user = _userControlService.GetUserByName(userClaim.Name);

            var result = _storeRepository.GetAllStoreByUserId(_user);

            return Ok(result);
        }
        [HttpGet]
        [Route("GetAllStore")]
        public async Task<IActionResult> GetAllStore()
        {
            var userClaim = User.Identity as ClaimsIdentity;
            var _user = _userControlService.GetUserByName(userClaim.Name);
            var result = _storeRepository.GetAllStore(_user);
            return Ok(result);
        }

        [HttpPost]
        [Route("AddProductToStore")]
        public bool AddProductToStore(DtoToAddToStore dtostore)
        {
            var userClaim = User.Identity as ClaimsIdentity;
            var _user = _userControlService.GetUserByName(userClaim.Name);

            var result = _storeRepository.AddProductToStore(dtostore, _user);

            return result;
        }
        [HttpPost]
        [Route("AddProductToStoreAfterPurchase")]
        public bool AddProductToStoreAfterPurchase(DtoStoreFromPurchase dtostore)
        {

            var result = _storeRepository.AddProductToStoreAfterPurchase(dtostore);

            return result;
        }
        #endregion

    }
}
