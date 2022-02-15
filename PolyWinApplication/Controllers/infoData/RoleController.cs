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
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;

        public RoleController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        #region Roles
        [HttpGet]
        [Route("GetAllRole")]
        public async Task<IActionResult> GetAllRole()
        {
            var result = _roleRepository.GetAllRoles();

            return Ok(result);
        }

        [HttpPost]
        [Route("AddEditRole")]
        public async Task<IActionResult> AddEditRole(dtoRole dto)
        {
                var result = _roleRepository.AddEditRole(dto);

                return Ok(result);
            }
  
        

        [HttpGet]
        [Route("DeleteRole")]
        public async Task<IActionResult> DeleteRole(string ids)
        {
        var result = _roleRepository.DeleteRole(ids);

        return Ok(result);
        }
      
        #endregion
    }
}
