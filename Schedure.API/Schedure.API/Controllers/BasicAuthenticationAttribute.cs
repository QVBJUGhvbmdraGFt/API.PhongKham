using Schedure.API.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Schedure.API.Controllers
{
    public class LogFilterAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            Debug.WriteLine($">>{actionContext.Request.Method}:{actionContext.Request.RequestUri.OriginalString}");
            base.OnAuthorization(actionContext);
        }
    }

    public class BasicAuthenticationAttribute : LogFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            bool fail = false;
            if (CheckToken() == false)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            $"BasicAuthenticationAttribute OnAuthorization {(fail ? "FAIL" : "SUCCESS")} on ({actionContext.Request.RequestUri.OriginalString}).".DebugLog();

            base.OnAuthorization(actionContext);
        }

        public virtual bool CheckToken()
        {
            var acc = LoginHelper.GetAccount();
            return acc != null;
        }
    }

    public class AdminAuthenticationAttribute : LogFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            bool fail = false;
            if (CheckToken() == false)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            $"AdminAuthenticationAttribute OnAuthorization {(fail ? "FAIL" : "SUCCESS")} on ({actionContext.Request.RequestUri.OriginalString}).".DebugLog();

            base.OnAuthorization(actionContext);
        }

        private bool CheckToken()
        {
            var acc = LoginHelper.GetAccountNV();
            return acc != null;
        }

        public string[] Roles { get; private set; }
        public AdminAuthenticationAttribute(params string[] Roles)
        {
            this.Roles = Roles;
        }
    }
}
