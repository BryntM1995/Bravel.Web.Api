using System;
using System.Collections.Generic;

namespace Bravel.Web.Api.Model.Models
{
    public partial class Convocation : BaseEntity
    {
        public Convocation()
        {
            Applications = new HashSet<Application>();
        }

        public int? ConvocationType { get; set; }
        public int? ApplicationLevel { get; set; }
        public string? DocumentTypes { get; set; }
        public int? QuotaLimit { get; set; }
        public DateTime? OpeningDate { get; set; }
        public DateTime? Deadline { get; set; }
        public string? ConvocationStatus { get; set; }
        public int? CreatedByUserId { get; set; }

        public virtual User? CreatedByUser { get; set; }
        public virtual ICollection<Application> Applications { get; set; }
    }
}
