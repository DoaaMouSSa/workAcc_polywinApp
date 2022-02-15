using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinDto.Dto
{
    public class DtoClient
    {
        public Guid? userId { get; set; }
        public int? id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public int userType { get; set; }
        public string Name { get; set; }
        public IFormFile Photo { get; set; }
        public string ClientLogoURL { get; set; }
        public string ClientAddress { get; set; }
        public string ClientPhone { get; set; }
        public string UserId { get; set; }
        public string Long { get; set; }
        public string Late { get; set; }
        public int ClientTypeId { get; set; }
        public string device_id { get; set; }
    }

    public class DtoClientForView
    {
        public int? id { get; set; }
        public string Name { get; set; }
        public string ClientAddress { get; set; }
        public string ClientPhone { get; set; }
        public string Email { get; set; }
    }

    public class DtoClientViewModal
    {
        public int? id { get; set; }
        public string Name { get; set; }
        public string ParentName { get; set; }
        public string ClientLogo { get; set; }
        public string userType { get; set; }
        public string ClientPhone { get; set; }
        public string Long { get; set; }
        public string Late { get; set; }
        public string ClientAddress { get; set; }
        public string Email { get; set; } 
    }

    public class DtoClientTypeCount
    {
        public int Id { get; set; }
        public string ClientType { get; set; }
        public int? Count { get; set; }
    }
}
