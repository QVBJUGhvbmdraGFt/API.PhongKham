using Schedure.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Schedure.API.Controllers
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public string[] Role { get; }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (CheckToken(actionContext) == false)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }

            base.OnAuthorization(actionContext);
        }

        private bool CheckToken(HttpActionContext actionContext)
        {
            var acc = LoginHelper.GetAccount();
            var res = acc != null;
            if (res && Role.Length > 0)
            {
                res = res && Role.Any(q => q.Equals(acc.POSITION + "", StringComparison.CurrentCultureIgnoreCase));
            }
            return res;
        }

        public BasicAuthenticationAttribute(params string[] Role)
        {
            this.Role = Role;
        }
    }
}
