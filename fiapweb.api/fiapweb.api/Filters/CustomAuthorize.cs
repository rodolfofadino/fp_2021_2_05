using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fiapweb.api.Filters
{
    public class CustomAuthorize :ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
           if(  context.HttpContext.Request.Headers["x-api-key"].Count ==0
                ||
                context.HttpContext.Request.Headers["x-api-key"].FirstOrDefault() != "EQ1e12e2!@#")
            {
                context.Result = new UnauthorizedResult();
            }
        }

    }
}
