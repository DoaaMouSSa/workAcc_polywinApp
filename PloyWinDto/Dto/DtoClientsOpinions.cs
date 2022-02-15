using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinDto.Dto
{
    public class DtoClientsOpinions
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public string ImgPath { get; set; }
        public IFormFile Img { get; set; }
        public string VidPath { get; set; }
        public IFormFile Vid { get; set; }
    }
}
