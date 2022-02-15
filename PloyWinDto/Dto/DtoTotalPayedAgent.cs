using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinDto.Dto
{
    public class DtoTotalPayedAgent
    {
        public string AgentName { get; set; }
        public decimal TotalInvoices { get; set; }
        public decimal TotalPayed { get; set; }
        public string AgentLogo { get; set; }
    }
}
