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

    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        #region Emps
        [HttpGet]
        [Route("GetAllEmployee")]
        public async Task<IActionResult> GetAllEmployee()
        {
            var result = _employeeRepository.GetAllEmployee();

            return Ok(result);
        }

        [HttpPost]
        [Route("AddEditEmployee")]
        public async Task<IActionResult> AddEditEmployee(DtoEmplyee dto)
        {
            var result = _employeeRepository.AddEditEmployee(dto);

            return Ok(result);
        }
        [HttpGet]
        [Route("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(string ids)
        {
            var result = _employeeRepository.DeleteEmployee(ids);

            return Ok(result);
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("LoginEmployee")]
        public async Task<IActionResult> LoginEmployee(DtoEmplyee dto)
        {
            var result = _employeeRepository.LoginEmployee(dto);
            return Ok(result);
        }

        #endregion
    }
}