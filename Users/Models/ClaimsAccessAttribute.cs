using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Users.Models {
    /// <summary>
    /// 自定义基于Claims的权限过滤器
    /// </summary>
    public class ClaimsAccessAttribute : AuthorizeAttribute {
        public string Issuer { get; set; }
        public string ClaimType { get; set; }
        public string Value { get; set; }
        protected override bool AuthorizeCore(HttpContextBase context) {
            return context.User.Identity.IsAuthenticated
            && context.User.Identity is ClaimsIdentity
            && ((ClaimsIdentity)context.User.Identity).HasClaim(x =>
            x.Issuer == Issuer && x.Type == ClaimType && x.Value == Value
            );
        }
    }
}
