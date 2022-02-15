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
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierRepository _supplierRepository;


        public SupplierController(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }
        #region supplier

        [HttpPost]
        [Route("AddEditSupplier")]
        public Task<Response<DtoSupplierToAdd>> AddEditSupplier(DtoSupplierToAdd dtosupplier)
        {
            var userClaim = User.Identity as ClaimsIdentity;
            var supplier = _supplierRepository.AddEditSupplier(dtosupplier);
            return supplier;
        }
        [HttpGet]
        [Route("getAllSupplier")]
        public Task<Response<List<DtoSupplier>>> getSuppliers()
        {
            var userClaim = User.Identity as ClaimsIdentity;
            var suppliers = _supplierRepository.getSuppliers();
            return suppliers;
        }
        [HttpGet]
        [Route("getAllSupplierForDropDown")]
        public Task<Response<List<DtoSupplierForDropDown>>> getAllSupplierForDropDown()
        {
            var userClaim = User.Identity as ClaimsIdentity;
            var suppliers = _supplierRepository.getSuppliersForDropDown();
            return suppliers;
        }
        [HttpGet]
        [Route("DeleteSupplier")]
        public Task<Response<bool>> DeleteSupplier(string Ids)
        {
            var Supplier = _supplierRepository.DeleteSupplier(Ids);
            return Supplier;
        }
        [HttpGet]
        [Route("GetSupplierCount")]
        public Response<int> GetSupplierCount()
        {
            Response<int> count = _supplierRepository.GetCountSupplier();
            return count;
        }
        #endregion

    }
}
