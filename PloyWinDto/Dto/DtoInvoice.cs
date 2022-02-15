using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinDto.Dto
{
    public class DtoInvoice
    {
        public int? order { get; set; }
        public int id { get; set; }
        public int? invoicesNumber { get; set; }
        public DateTime? invoicesDate { get; set; }
        public string invoicesDateString { get; set; }
        public bool? isRecived { get; set; }
        public string isRecivedText { get; set; }
        public string describtion { get; set; }
        public decimal? totalInvoices { get; set; }
        public decimal? descountInvoices { get; set; }
        public decimal? totalWithInvoices { get; set; }
        public decimal? totalPayed { get; set; }
        public decimal? totalAmount { get; set; }
        public List<DtoInvoiceDetails> details { get; set; }
        public string fromUserId { get; set; }
        public string toUserId { get; set; }
        public string Agent { get; set; }

    }

    public class DtoInvoicesOrder
    {
        public int id { get; set; }
        public int? order { get; set; }
        public int? invoicesNumber { get; set; }
        public DateTime? invoicesDate { get; set; }
        public string Agent { get; set; }
        public string ToUserId { get; set; }
        public string describtion { get; set; }
    }
}
