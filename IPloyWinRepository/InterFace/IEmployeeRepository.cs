using PloyWinContext.Entities;
using PloyWinDto.Dto;
using PloyWinContext.Entities;
using PloyWinDto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPloyWinRepository.InterFace
{
   public interface IEmployeeRepository : IGenericRepository<TblEmplyees>
    {
        Response<List<DtoEmplyee>> GetAllEmployee();
        Response<bool> DeleteEmployee(string Ids);
        Response<DtoEmplyee> AddEditEmployee(DtoEmplyee dto);
        Response<DtoLoginEmployee> LoginEmployee(DtoEmplyee dto);
    }
}
