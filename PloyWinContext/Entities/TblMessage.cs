using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PloyWinContext.Entities
{
    public class TblMessage:BaseEntity
    {
        //[Required]
        [StringLength(15)]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [StringLength(11)]
        public string Phone { get; set; }
        //[Required]
        [StringLength(255)]
        public string Message { get; set; }

    }
}
