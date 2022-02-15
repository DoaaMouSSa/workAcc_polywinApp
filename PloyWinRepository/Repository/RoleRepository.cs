using IPloyWinRepository.InterFace;
using Microsoft.EntityFrameworkCore;
using PloyWinContext.Context;
using PloyWinContext.Entities;
using PloyWinDto.Dto;
using PloyWinRepository.EnumData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinRepository.Repository
{
    public class RoleRepository : GenericRepository<ApplicationContext, Roles>, IRoleRepository
    {
        public Response<dtoRole> AddEditRole(dtoRole dto)
        {
            if (dto != null)
            {
                if (dto.Id > 0)
                {
                    var isExist = FindBy(x => x.Id == dto.Id).FirstOrDefault();

                    if (isExist != null)
                    {
                        if (dto.Name != null)
                        {
                            isExist.Role_Name = dto.Name;
                        }
                       
                        isExist.ModifiedDate = DateTime.Now;

                        Edit(isExist);
                        Save();

                        dto.Name = isExist.Role_Name;
                    }
                }
                else
                {
                    var objRole = new Roles()
                    {
                        AddedDate = DateTime.Now,
                        Role_Name = dto.Name
                    };

                    Add(objRole);
                    Save();

                    dto.Id = objRole.Id;
                }
            }

            Response<dtoRole> res = new Response<dtoRole>();
            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = dto;
            return res;
        }

        public Response<bool> DeleteRole(string Ids)
        {
            var listId = Ids.Split(',').ToList();

            bool dd = false;

            foreach (var Id in listId)
            {
                var result = FindBy(x => x.Id == Convert.ToInt32(Id)).FirstOrDefault();


                if (result != null)
                {
                    result.IsDeleted = true;
                    result.DeletedDate = DateTime.Now;

                    Edit(result);
                    Save();

                    dd = true;
                }
            }

            Response<bool> res = new Response<bool>();
            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = dd;
            return res;
        }

        public Response<List<dtoRole>> GetAllRoles()
        {
            var result = (from q in Context.Roles.AsNoTracking().Where(x => x.IsDeleted == null&&x.Id !=5&x.Id!=4)
                          select new dtoRole
                          {
                              Id = q.Id,
                              Name = q.Role_Name,
                       
                          }).ToList();

            Response<List<dtoRole>> res = new Response<List<dtoRole>>();
            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = result;
            return res;
        }
    }
}
