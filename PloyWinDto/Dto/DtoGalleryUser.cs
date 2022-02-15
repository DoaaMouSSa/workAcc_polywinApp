using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinDto.Dto
{
    public class DtoGalleryUser
    {
        public int Id { get; set; }        
        public string PhotoPath { get; set; }
        public IFormFile Photo { get; set; }
    }
}
