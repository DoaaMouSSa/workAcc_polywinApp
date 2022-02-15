using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinDto.Dto
{
    public class DtoPurchase
    {
        public int id { get; set; }
        public int? product_id { get; set; }
        public int? supplier_id { get; set; }
        public int? unit_id { get; set; }
        public int? Currency_id { get; set; }
        public decimal priceForOnePiece { get; set; }
        //عدد القطع داخل الكرتونه
        public int NumberOfPieces { get; set; }
        //سعر القطع==سعر الكرتونه مثلا
        public decimal PriceOfAllPieces { get; set; }
        //عدد الكرتون مثلا
        public int qty { get; set; }
        //اجمالى الدفع
        public decimal totalPrice_purchase { get; set; }
    }
    public class DtoPurchaseForShow
    {
        public int id { get; set; }
        public int productId { get; set; }
        public string productName { get; set; }
        public int supplierId { get; set; }
        public string supplierName { get; set; }
        public int ItemtypeId { get; set; }
        public string nameItemType { get; set; }
        public int CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public decimal priceForOnePiece { get; set; }
        //عدد القطع داخل الكرتونه
        public int NumberOfPieces { get; set; }
        //سعر القطع==سعر الكرتونه مثلا
        public decimal PriceOfAllPieces { get; set; }
        //عدد الكرتون مثلا
        public int qty { get; set; }
        //اجمالى الدفع
        public decimal totalPrice_purchase { get; set; }
        public string Added_Date { get; set; }
    }
}
