using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinDto.Dto
{
    public class DtoEmplyee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int? Roles_id { get; set; }
        public string Roles_name  { get; set; }
    }
    public class DtoLoginEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Roles_id { get; set; }
    }
}
