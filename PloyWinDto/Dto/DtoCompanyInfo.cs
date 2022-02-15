using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinDto.Dto
{
    public class DtoCompanyInfo
    {
        public int Id { get; set; }
        public string FutureInfo { get; set; }
        public string CompanyFile { get; set; }
        public string CompanyInfo { get; set; }
        public IFormFile file { get; set; }
    }
}
