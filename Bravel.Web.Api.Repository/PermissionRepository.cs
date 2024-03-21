using Bravel.Web.Api.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bravel.Web.Api.Repository
{
    public class PermissionRepository : BaseRepository<Permission>
    {
        public PermissionRepository(BravelContext dbContext) : base(dbContext)
        {

        }
    }
}
