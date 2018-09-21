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
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (CheckToken(actionContext) == false)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }

            base.OnAuthorization(actionContext);
        }

        public virtual bool CheckToken(HttpActionContext actionContext)
        {
            var acc = LoginHelper.GetAccount();
            var res = acc != null;
            return res;
        }
    }

    public class AdminAuthenticationAttribute : AuthorizationFilterAttribute
    {
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
            var acc = LoginHelper.GetAccountNV();
            var res = acc != null;
            return res;
        }

        public string[] Roles { get; private set; }
        public AdminAuthenticationAttribute(params string[] Roles)
        {
            this.Roles = Roles;
        }
    }
}
