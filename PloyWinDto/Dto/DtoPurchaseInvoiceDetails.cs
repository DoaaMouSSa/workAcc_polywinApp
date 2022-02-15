using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinDto.Dto
{
    public class DtoPurchaseInvoiceDetails
    {
        public int Id { get; set; }
        public int? Inv_Id { get; set; }
        public int Product_Id { get; set; }
        public int Product_IdName { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public decimal TPrice_product { get; set; }
    }
    public class DtoPurchaseInvoiceDetailsForShow
    {
        public int Id { get; set; }
        public int? Inv_Id { get; set; }
        public int Product_Id { get; set; }
        public string Product_Code { get; set; }
        public int Product_IdName { get; set; }
        public string Product_Name { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public decimal TPrice_product { get; set; }
    }
}
