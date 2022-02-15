using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinContext.Entities
{
   public class ApplicationRole : IdentityRole
    {
        public string Access { get; set; }
        public ApplicationRole() : base() => Id = Guid.NewGuid().ToString();
    }
}
