using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Users.Models {
    public class GlobalAuthorizeAttribute : AuthorizeAttribute {
        protected override bool AuthorizeCore(HttpContextBase httpContext) {
            if (httpContext.Request.ContentLength > 0) {
                return false;
            }
            return base.AuthorizeCore(httpContext);
        }
    }
}