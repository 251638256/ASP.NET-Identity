using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Users.Models;

namespace Users.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [Authorize]
        public ActionResult Index()
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("Placeholder", "Placeholder");
            return View(data);
        }

        /// <summary>
        /// 登录后角色认证失败 依然跳到了登录页面 (fixed)
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "User")]
        public ActionResult OtherAction() {
            return View("Index", GetData("OtherAction"));
        }

        private Dictionary<string, object> GetData(string actionName) {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("Action", actionName);
            dict.Add("User", HttpContext.User.Identity.Name);
            dict.Add("Authenticated", HttpContext.User.Identity.IsAuthenticated);
            dict.Add("Auth Type", HttpContext.User.Identity.AuthenticationType);
            dict.Add("In Users Role", HttpContext.User.IsInRole("Users"));
            return dict;
        }

        [Authorize]
        public ActionResult UserProps() {
            return View(CurrentUser);
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> UserProps(Cities city) {
            AppUser user = CurrentUser;
            user.City = city;
            user.SetCountryFromCity(city);
            await UserManager.UpdateAsync(user);
            return View(user);
        }

        /// <summary>
        /// 不需要权限的方法
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public string AllowAnonymousAction() {
            return "授权成功";
        }

        private AppUser CurrentUser {
            get {
                return UserManager.FindByName(HttpContext.User.Identity.Name);
            }
        }
        private AppUserManager UserManager {
            get {
                return HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            }
        }
    }
}