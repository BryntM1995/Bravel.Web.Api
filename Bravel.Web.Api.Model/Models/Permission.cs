using System;
using System.Collections.Generic;
using System.Security;

namespace Bravel.Web.Api.Model.Models
{
    public partial class Permission : BaseEntity
    {
        public string? PermissioName { get; set; }
        public int? RoleId { get; set; }

        public virtual Role? Role { get; set; }
    }
}