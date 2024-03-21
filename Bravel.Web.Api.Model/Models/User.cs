using System;
using System.Collections.Generic;

namespace Bravel.Web.Api.Model.Models
{
    public partial class User : BaseEntity
    {
        public User()
        {
            Applications = new HashSet<Application>();
            Convocations = new HashSet<Convocation>();
        }

        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public DateTime LastLogin { get; set; }
        public string RecoveryQuestion { get; set; } = null!;
        public byte[] RecoveryAnwser { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public DateTime DateOfbirth { get; set; }
        public bool Status { get; set; }
        public string? RelationshipType { get; set; }
        public int? RoleId { get; set; }

        public virtual Role? Role { get; set; }
        public virtual ICollection<Application> Applications { get; set; }
        public virtual ICollection<Convocation> Convocations { get; set; }
    }
}
