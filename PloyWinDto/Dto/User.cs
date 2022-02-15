using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinDto.Dto
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Token { get; set; }
        public string Password { get; set; }
        public DateTime EndDate { get; set; }
        public string Roles { get; set; }
        public string UserId { get; set; }
        public int  UserType { get; set; }
        public string UserTypeName { get; set; }
        public string ManagerId { get; set; }
        public string device_id { get; set; }
        public List<DtoDescount> ListDescount { get; set; }
    }

    public class UserWithManager
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Token { get; set; }
        public string Password { get; set; }
        public DateTime EndDate { get; set; }
        public string Roles { get; set; }
        public string UserId { get; set; }
        public int UserType { get; set; }
        public string UserTypeName { get; set; }
        public string ManagerId { get; set; }
        public string managerName { get; set; }
        public List<DtoDescount> ListDescount { get; set; }
    }
    public class ChanagePasswordViewModel
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
