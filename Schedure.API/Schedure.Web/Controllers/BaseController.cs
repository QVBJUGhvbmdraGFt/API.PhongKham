using SchedureBUS;
using SchedureDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Schedure.Web.Controllers
{
    public class BaseController : Controller, IToken
    {
        const string TOKEN = "TOKEN";

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Session[TOKEN] == null)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new
                {
                    controller = "Login",
                    action = "Index"
                }));
            }

            base.OnActionExecuting(filterContext);
        }

        public string GetToken()
        {
            return HttpContext.Session[TOKEN] + "";
        }

        public AccountDTO Account
        {
            get
            {
                return new AuthenticateBUS().GetAccount(GetToken());
            }
        }
    }
}