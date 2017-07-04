using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Users.Models {
    public class AppIdentityDbContext : IdentityDbContext<AppUser> {
        public AppIdentityDbContext() : base("HygieneContext") {

        }

        static AppIdentityDbContext() {
            Database.SetInitializer(new IdentityDbInit());
        }

        // OWIN规范
        public static AppIdentityDbContext Create() {
            return new AppIdentityDbContext();
        }
    }

    public class IdentityDbInit : NullDatabaseInitializer<AppIdentityDbContext> {
        //protected override void Seed(AppIdentityDbContext context) {
        //    PerformInitialSetup(context);
        //    base.Seed(context);
        //}
        //public void PerformInitialSetup(AppIdentityDbContext context) {
        //    // initial configuration will go here
        //    // 初始化配置将放在这儿

        //    AppUserManager userMgr = new AppUserManager(new UserStore<AppUser>(context));
        //    AppRoleManager roleMgr = new AppRoleManager(new RoleStore<AppRole>(context));

        //    string roleName = "User";
        //    string userName = "Admin";
        //    string password = "123";
        //    string email = "admin@example.com";
        //    if (!roleMgr.RoleExists(roleName)) {
        //        roleMgr.Create(new AppRole(roleName));
        //    }

        //    AppUser user = userMgr.FindByName(userName);
        //    if (user == null) {
        //        IdentityResult result = userMgr.Create(new AppUser { UserName = userName, Email = email } , password); // No id
        //        if (!result.Succeeded) {
        //            throw new Exception("失败:" + string.Join("\n", result.Errors));
        //        }

        //        IdentityResult re = userMgr.Create(new AppUser { UserName = "test8", Email = "test8@qq.com" }, "123");
        //        if (!re.Succeeded) {
        //            throw new Exception("失败:" + string.Join("\n", re.Errors));
        //        }

        //        user = userMgr.FindByName(userName); // get ID
        //    }

        //    if (!userMgr.IsInRole(user.Id, roleName)) {
        //        userMgr.AddToRole(user.Id, roleName);
        //    }

        //}
    }
}