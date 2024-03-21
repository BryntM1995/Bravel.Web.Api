using System;
using System.Collections.Generic;
using System.Security;

namespace Bravel.Web.Api.Model.Models
{
    public partial class Role : BaseEntity
    {
        public Role()
        {
            Permissions = new HashSet<Permission>();
            Users = new HashSet<User>();
        }
        public string? RoleName { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
