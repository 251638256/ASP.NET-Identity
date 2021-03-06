﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Users.Models;

namespace Users.Controllers
{
    public class ClaimsController : Controller
    {
        // GET: Claims
        [Authorize]
        public ActionResult Index() {
            ClaimsIdentity ident = HttpContext.User.Identity as ClaimsIdentity;

            if (ident == null) {
                return View("Error", new string[] { "No claims available" });
            }
            else {
                return View(ident.Claims);
            }
        }

        [Authorize(Roles = "DCStaff", Users = "")]
        public string OtherAction() {
            return "This is the protected action";
        }

        [ClaimsAccess(Issuer = "RemoteClaims", ClaimType = ClaimTypes.PostalCode,Value = "DC 20500")]
        public string ActionResult() {
            return "这是使用自定义授权的";
        }
    }
}