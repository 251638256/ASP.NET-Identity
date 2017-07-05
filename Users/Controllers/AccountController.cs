using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Users.Models;
using Microsoft.Owin.Security;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Users.Controllers
{
    [Authorize]
    public class AccountController : Controller {

        [AllowAnonymous]
        public ActionResult Login(string returnUrl) {

            if (HttpContext.User.Identity.IsAuthenticated) {
                return View("Error", new string[] { "没有权限访问!" });
            }

            if (ModelState.IsValid) {

            }
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel details, string returnUrl) {

            if (ModelState.IsValid) {
                AppUser user = await UserManager.FindAsync(details.Name,
                details.Password);
                if (user == null) {
                    ModelState.AddModelError("", "Invalid name or password.");
                }
                else {
                    // WHAT IS THIS?
                    ClaimsIdentity ident = await UserManager.CreateIdentityAsync(user ,DefaultAuthenticationTypes.ApplicationCookie);
                    ident.AddClaims(LocationClaimsProvider.GetClaims(ident)); // 添加一些模拟的远程Claims (声明)
                    ident.AddClaims(ClaimsRoles.CreateRolesFromClaims(ident)); // 判断下如果本身具有A角色 就给他动态添加B角色 
                    AuthManager.SignOut(); // 删掉cookie
                    AuthManager.SignIn(new AuthenticationProperties { IsPersistent = false }, ident); // 创建cookie 持久化的(永不过期)
                    return Redirect(returnUrl);
                }
            }
            ViewBag.returnUrl = returnUrl;
            return View(details);
        }

        [Authorize]
        public ActionResult Logout() {
            AuthManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        private IAuthenticationManager AuthManager {
            get {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        private AppUserManager UserManager {
            get {
                return HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            }
        }
    }
}