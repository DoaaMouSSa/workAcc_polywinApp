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
    public class ItemTypesController : ControllerBase
    {

        private readonly IItemTypeRepository _itemTypeRepository;

        public ItemTypesController(IItemTypeRepository itemTypeRepository)
        {
            _itemTypeRepository = itemTypeRepository;
        }

        #region ItemTypes
        [HttpPost]
        [Route("AddEditItemType")]
        public Task<Response<DtoItemType>> AddEditItemType(DtoItemType dtoItemType)
        {
            var ItemType = _itemTypeRepository.AddEditItemType(dtoItemType);
            return ItemType;
        }

        [HttpGet]
        [Route("getAllItemType")]
        public Task<Response<List<DtoItemType>>> getAllItemType()
        {

            var ItemType = _itemTypeRepository.getItemType();
            return ItemType;
        }

        [HttpGet]
        [Route("DeleteItemType")]
        public Task<Response<bool>> DeleteItemType(string ids)
        {
            var ItemType = _itemTypeRepository.DeleteItemType(ids);
            return ItemType;
        }
        #endregion
     
    }
}
