using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinContext.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base() => Id = Guid.NewGuid().ToString();

        public string ManagerId { get; set; }
        public int UserType { get; set; }
        public bool? IsActive { get; set; }
        public bool? isDeleted { get; set; }
        public string device_id { get; set; }
    }
}
