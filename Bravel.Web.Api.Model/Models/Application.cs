using System;
using System.Collections.Generic;

namespace Bravel.Web.Api.Model.Models
{
    public partial class Application : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? IdentityNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? UserId { get; set; }
        public int? ConvocationId { get; set; }
        public byte[]? StudentPhoto { get; set; }
        public byte[]? StudentDocuments { get; set; }
        public DateTime? ApplicationDate { get; set; }
        public bool? IsApproved { get; set; }

        public virtual Convocation? Convocation { get; set; }
        public virtual User? User { get; set; }
    }
}
