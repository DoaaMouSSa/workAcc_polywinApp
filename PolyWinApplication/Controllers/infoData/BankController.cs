using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
    public class BankController : ControllerBase
    {
        private readonly IBankRepository _bankRepository;
        public BankController(IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }
        #region bank
        [HttpPost]
        [Route("AddEditBank")]
        public Task<Response<DtoBank>> AddEditBank(DtoBank dtoBank)
        {
            var Bank = _bankRepository.AddEditBank(dtoBank);
            return Bank;
        }

        [HttpGet]
        [Route("getBank")]
        public Task<Response<List<DtoBank>>> getBank()
        {

            var Bank = _bankRepository.getBank();
            return Bank;
        }

        [HttpGet]
        [Route("DeleteBank")]
        public Task<Response<bool>> DeleteBank(string ids)
        {
            var Bank = _bankRepository.DeleteBank(ids);
            return Bank;
        }
  
        #endregion
    }
}
