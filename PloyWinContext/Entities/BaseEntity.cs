using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinContext.Entities
{
   public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime? AddedDate { get; set; }
        public DateTime? ModifiedDate { get; set; } 
        public DateTime? DeletedDate { get; set; }
        public bool? IsDeleted { get; set; } 
    }
}
