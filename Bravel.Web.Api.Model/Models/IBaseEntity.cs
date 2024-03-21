using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bravel.Web.Api.Model.Models
{
    public interface IBaseEntity
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
    }
    public class BaseEntity : IBaseEntity
    {
        [Key]
        public int Id { get; set; }
        public bool Deleted { get; set; }
    }
}
