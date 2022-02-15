using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinDto.Dto
{
    public class DtoPayedClient
    {
        public int ClientId { get; set; }
        public string UserId { get; set; }
        public int NumberOfPayments { get; set; }
        public decimal? TotalContract { get; set; }
        public int ContractId { get; set; }
    }

    public class DtoPayedAfterCreate
    {
        public int Id { get; set; }
        public decimal? MoneyPerMonth { get; set; }
        public DateTime? VisicalDate { get; set; }
    }

    public class DtoPayedBeforeCreate
    {
        public int Id { get; set; }
        public decimal? MoneyPerMonth { get; set; }
        public DateTime? VisicalDate { get; set; }
        public DateTime? CreationDate { get; set; }
        public string IsPayed { get; set; }
    }
}
