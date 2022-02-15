using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinDto.Dto
{
    public class DtoDescount
    {
        public int id { get; set; }
        public int? typeOfDescount { get; set; }
        public string typeOfDescountName { get; set; }
        public decimal? descount { get; set; }
        public int? typeofCategory { get; set; }
        public string typeofCategoryName { get; set; }
        public string typeDescountName { get; set; }
    }

    public class DtoDescountEdit
    {
        public int id { get; set; }
        public int? typeOfDescount { get; set; }
        public decimal? descount { get; set; }
        public bool? typeDescount { get; set; }
        public string typeOfDescountName { get; set; }
        public string typeDescountName { get; set; }
        public int? typeofCategory { get; set; }
        public string typeofCategoryName { get; set; }
    }

    public class DtoDescountAdded
    {
        public int? typeOfDescount { get; set; }
        public decimal? descount { get; set; }
        public int? typeofProduct { get; set; }
        public bool? typeDescount { get; set; }
    }
}
