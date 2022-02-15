using Microsoft.AspNetCore.Http;
using System;

namespace PloyWinDto.Dto
{
    public class DtoUserAndAgent
    {
        public Guid? userId { get; set; }
        public int? id { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int userType { get; set; }
        public string pserTypeName { get; set; }
        public string name { get; set; }
        public string nameAgent { get; set; }
        public string agentLogo { get; set; }
        public IFormFile Photo { get; set; }
        public string agentGovernorate { get; set; }
        public string agentAddress { get; set; }
        public string agentPhone { get; set; }
        public string Long { get; set; }
        public string Late { get; set; }
    }
}
