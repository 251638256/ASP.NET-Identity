using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Users.Models {
    public class GlobalAuthorizeAttribute : AuthorizeAttribute {
        protected override bool AuthorizeCore(HttpContextBase httpContext) {
            //return false; // 阻止授权
            return base.AuthorizeCore(httpContext);
        }
    }
}