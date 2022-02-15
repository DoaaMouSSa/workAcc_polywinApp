using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinDto.Dto
{
    public class DtoContractClient
    {
        public int InvoicesNumber { get; set; }
        public int ClientId { get; set; }
        public string FromUserId { get; set; }
        public string ToUserId { get; set; }
        public DateTime? InvoicesDate { get; set; }
        public string Describtion { get; set; }
        public decimal? TotalInvoices { get; set; }
        public decimal? DescountInvoices { get; set; }
        public decimal? TotalWithInvoices { get; set; }
        public string NumberOfCostCalc { get; set; }
    }

    public class DtoContractClientForView
    {
        public int Id { get; set; }
        public int? InvoicesNumber { get; set; }
        public string ClientName { get; set; }
        public string ClientTypeName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public decimal? TotalContract { get; set; }
        public string WorkShopName { get; set; }
        public string WorkShopAddress { get; set; }
        public string WorkShopPhone { get; set; }
        public string EmailWorkShop { get; set; }
        public string lat { get; set; }
        public string lang { get; set; }
        public string ImgWorkShop { get; set; }
        public List<ListProduct> listItem{ get; set; }
   

    }

    public class ListProduct
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public string ProductName { get; set; }
    }


    public class ContractInfo
    {
        public string InvoiceDate{ get; set; }
        public string WorkShopName { get; set; }
        public string WorkShopUserName { get; set; }
        public string WorkShopAddress { get; set; }
        public string WorkShopLogo { get; set; }
        public string ClientName { get; set; }
        public string ClientAddress { get; set; }
        public string ClientPhone { get; set; }
        public string Total { get; set; }

        public List<ItemList> ItemList { get; set; }
    }

    public class ItemList
    {
        public string ProductName { get; set; }
        public string Width { get; set; }
        public string heigth { get; set; }
        public string Color { get; set; }
    }
}
