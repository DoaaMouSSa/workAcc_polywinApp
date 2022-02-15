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
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseRepository _purchaseRepository;

        public PurchaseController(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }
        #region purchase
        [HttpPost]
        [Route("AddEditPurchase")]
        public Task<Response<DtoPurchase>> AddEditPurchase(DtoPurchase dtoPurchase)
        {
            var pro = _purchaseRepository.AddEditPurchase(dtoPurchase);
            return pro;
        }

        [HttpGet]
        [Route("getPurchase")]
        public Task<Response<List<DtoPurchaseForShow>>> getPurchase()
        {
            var pro = _purchaseRepository.getPurchase();
            return pro;
        }

        [HttpGet]
        [Route("DeletePurchase")]
        public Task<Response<bool>> DeletePurchase(string ids)
        {
            var pro = _purchaseRepository.DeletePurchase(ids);
            return pro;
        }
        #endregion
    }
}
