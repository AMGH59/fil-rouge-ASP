using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devTalksASP.Services
{
    public class NavService
    {
        private IHttpContextAccessor _accessor;
        public  string PathValue { get => _accessor.HttpContext.Request.Path.Value; }
        public NavService(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public Endpoint E { get => _accessor.HttpContext.GetEndpoint();}
    }
}
