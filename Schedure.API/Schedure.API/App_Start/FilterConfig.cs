using Schedure.API.Controllers;
using System.Web;
using System.Web.Mvc;

namespace Schedure.API
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
