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
    public class PurchaseInvoiceController : ControllerBase
    {
        private readonly IPurchaseInvoiceRepository _purchaseInvoiceRepository;
        public PurchaseInvoiceController(IPurchaseInvoiceRepository purchaseInvoiceRepository)
        {
            _purchaseInvoiceRepository = purchaseInvoiceRepository;
        }
        [HttpPost]
        [Route("AddInvoicePurchase")]
        public Task<Response<DtoPurchaseInvoiceForAdd>> AddInvoicePurchase(DtoPurchaseInvoiceForAdd dto)
        {
            var inv = _purchaseInvoiceRepository.AddEditPurchaseInvoice(dto);
            return inv;
        }
        [HttpGet]
        [Route("GetAllPurchaseInvoices")]
        public Response<List<DtoPurchaseInvoiceForShow>> GetAllPurchaseInvoices()
        {
            var inv = _purchaseInvoiceRepository.GetAllInvoices();
            return inv;
        }
    }
}
