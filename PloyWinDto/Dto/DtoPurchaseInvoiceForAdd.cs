using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PloyWinContext.Entities;
namespace PloyWinDto.Dto
{
    public class DtoPurchaseInvoiceForAdd
    {
        public int Id { get; set; }
        public string Inv_Code { get; set; }
        public string Date { get; set; }
        public int Supplier_Id { get; set; }
        public string Client_Name { get; set; }
        public string Type { get; set; }
        public decimal inv_total { get; set; }
        public int Currency_Id { get; set; }
        public List<DtoPurchaseInvoiceDetails> AllProducts { get; set; }
    }
    public class DtoPurchaseInvoiceForShow
    {
        public int Id { get; set; }
        //سند استلام
        public string Inv_Code { get; set; }
        public string Date { get; set; }
        public int Supplier_Id { get; set; }
        public string Supplier_Name { get; set; }
        public string Client_Name { get; set; }
        public string Type { get; set; }
        public decimal inv_total { get; set; }
        public int Currency_Id { get; set; }
        public string Currency_Name { get; set; }
        public List<TblPurchase_Invoices_Details> AllProducts { get; set; }
    }
  
}
