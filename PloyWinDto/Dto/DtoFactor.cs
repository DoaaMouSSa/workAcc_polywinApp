using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinDto.Dto
{
    public class DtoFactor
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string filePath { get; set; }
        public IFormFile file { get; set; }
        public string LogoPath { get; set; }
        public IFormFile logo { get; set; }
    }
}
