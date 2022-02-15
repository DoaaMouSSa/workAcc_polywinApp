using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinDto.Dto
{
    public class DtoAgent
    {
        public int id { get; set; }
        public string ParentName { get; set; }
        public string name { get; set; }
        public string nameAgent { get; set; }
        public string agentLogo { get; set; }
        public string agentGovernorate { get; set; }
        public string agentAddress { get; set; }
        public string agentPhone { get; set; }
        public string UserId { get; set; }
        public string Email { get; set; }
        public string Long { get; set; }
        public string Late { get; set; }
    }
    public class DtoAgentLogo
    {
        public string agentLogo { get; set; }
    }
    public class DtoByWorkShopByGov
    {
        public int id { get; set; }
        public string agentGovernorate { get; set; }
        public List<DtoAgent> listAgent { get; set; }
    }

    public class DtoAccountDetails
    {
        public string id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        public string ActiveType { get; set; }
    }
}