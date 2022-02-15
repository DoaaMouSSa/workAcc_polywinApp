using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinDto.Dto
{
  public  class DtoParentProductCategory
    {
        public int Id { get; set; }
        public string CatgoryName { get; set; }
        public bool? haveIron { get; set; }
        public string haveIronString { get; set; }
    }
}
