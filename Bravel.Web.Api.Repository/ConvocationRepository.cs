using Bravel.Web.Api.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bravel.Web.Api.Repository
{
    public class ConvocationRepository : BaseRepository<Convocation>
    {
        public ConvocationRepository(BravelContext dbContext) : base(dbContext)
        {

        }
    }
}
