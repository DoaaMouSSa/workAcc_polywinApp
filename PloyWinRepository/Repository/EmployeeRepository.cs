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
    public class EmployeeRepository : GenericRepository<ApplicationContext, TblEmplyees>, IEmployeeRepository
    {
        public Response<DtoEmplyee> AddEditEmployee(DtoEmplyee dto)
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
                            isExist.emp_name = dto.Name;
                        }

                        if (dto.Password != null)
                        {
                            isExist.password = dto.Password;
                        }
                        if (dto.Roles_id != null)
                        {
                            isExist.Roles_id = dto.Roles_id;
                        }
                        isExist.ModifiedDate = DateTime.Now;

                        Edit(isExist);
                        Save();

                        dto.Name = isExist.emp_name;
                        dto.Password = isExist.password;
                    }
                }
                else
                {
                    var objEmp = new TblEmplyees()
                    {
                        AddedDate = DateTime.Now,
                        emp_name = dto.Name,
                        password = dto.Password,
                        Roles_id = dto.Roles_id
                    };

                    Add(objEmp);
                    Save();

                    dto.Id = objEmp.Id;
                }
            }

            Response<DtoEmplyee> res = new Response<DtoEmplyee>();
            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = dto;
            return res;
        }
    
        public Response<bool> DeleteEmployee(string Ids)
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

        public Response<List<DtoEmplyee>> GetAllEmployee()
        {
            var result = (from q in Context.TblEmplyees.AsNoTracking().Where(x => x.IsDeleted == null&&x.Roles_id!=5&&x.Roles_id!=4)
                          select new DtoEmplyee
                          {
                              Id = q.Id,
                              Name = q.emp_name,
                              Password = q.password,
                              Roles_id = q.Roles.Id,
                              Roles_name=q.Roles.Role_Name
                          }).ToList();

            Response<List<DtoEmplyee>> res = new Response<List<DtoEmplyee>>();
            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = result;
            return res;
        }
        public Response<DtoLoginEmployee> LoginEmployee(DtoEmplyee dto)
        {
            var result = (from q in Context.TblEmplyees.AsNoTracking().Where(x => x.IsDeleted == null && x.emp_name == dto.Name && x.password == dto.Password)
                          select new DtoLoginEmployee
                          {
                              Id = q.Id,
                              Name = q.emp_name,
                              Roles_id = q.Roles.Id,
                          }).FirstOrDefault();

            Response<DtoLoginEmployee> res = new Response<DtoLoginEmployee>();
            res.code = StaticApiStatus.ApiSuccess.Code;
            res.message = StaticApiStatus.ApiSuccess.MessageAr;
            res.status = StaticApiStatus.ApiSuccess.Status;
            res.payload = result;
            return res;
        }
    }
}
