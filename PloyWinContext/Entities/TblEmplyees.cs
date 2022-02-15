using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinContext.Entities
{
    public class TblEmplyees:BaseEntity
    {
        public string emp_name { get; set; }
        public string password { get; set; }
        [ForeignKey(nameof(Roles))]
        public int? Roles_id { get; set; }
        public virtual Roles Roles { get; set; }
    }
}
