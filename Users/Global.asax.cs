using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Users.Models;

namespace Users
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            
            // 添加全局自定义过滤去
            GlobalFilters.Filters.Add(new GlobalAuthorizeAttribute());
        }
    }
}
