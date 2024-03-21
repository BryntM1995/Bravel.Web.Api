using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bravel.Web.Api.Service.DTOs
{
    public interface IBaseDto
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
    }

    public class BaseDto : IBaseDto
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
    }
}
