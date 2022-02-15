using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinDto.Dto
{
    public class DtoWarranty
    {
        public int? ContractId { get; set; }
        public int? ContractItemId { get; set; }
        //public DateTime? StartWarrantyDate { get; set; }
        //public DateTime? EndWarrantyDate { get; set; }
        //public int? NumberWarranty { get; set; }
        //public int? TypeWarranty { get; set; }
    }

    public class DtoWarrantyForView
    {
        public int Id { get; set; } 
        public string ProductName { get; set; }
        public int? ContractItemId { get; set; }
        public string StartSectorsWarrantyDate { get; set; }
        public string EndSectorsWarrantyDate { get; set; }
        public string StartAccessoresWarrantyDate { get; set; }
        public string EndAccessoresWarrantyDate { get; set; }
        public List<string> ListImage { get; set; }
    }
}
