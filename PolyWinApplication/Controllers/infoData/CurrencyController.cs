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
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyRepository _currencyRepository;
        public CurrencyController(
                   ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }
        #region Currency
        [HttpPost]
        [Route("AddEditCurrency")]
        public Task<Response<DtoCurrency>> AddEditCurrency(DtoCurrency dtoCurrency)
        {
            var Currency = _currencyRepository.AddEditCurrency(dtoCurrency);
            return Currency;
        }

        [HttpGet]
        [Route("getCurrency")]
        public Task<Response<List<DtoCurrency>>> getCurrency()
        {

            var Currency = _currencyRepository.getCurrency();
            return Currency;
        }

        [HttpGet]
        [Route("DeleteCurrency")]
        public Task<Response<bool>> DeleteCurrency(string ids)
        {
            var Currency = _currencyRepository.DeleteCurrency(ids);
            return Currency;
        }
        #endregion

    }
}
