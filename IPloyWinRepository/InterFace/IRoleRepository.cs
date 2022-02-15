using PloyWinContext.Entities;
using PloyWinDto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPloyWinRepository.InterFace
{
    public interface IRoleRepository : IGenericRepository<Roles>
    {
        Response<List<dtoRole>> GetAllRoles();
        Response<bool> DeleteRole(string Ids);
        Response<dtoRole> AddEditRole(dtoRole dto);
    }
}
