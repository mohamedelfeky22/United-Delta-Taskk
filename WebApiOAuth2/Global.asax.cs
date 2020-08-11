using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebApiOAuth2.Models;

namespace WebApiOAuth2
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DefaultUser();
        }
        private void DefaultUser()
        {
            var userMnager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            if (userMnager.FindByEmail("abanob1994@gmail.com") == null)
            {
                userMnager.Create(new ApplicationUser()
                {
                    UserName = "abanob1994@gmail.com",
                    Email = "abanob1994@gmail.com",
                    PhoneNumber = "034948217"

                }, "Abanob@1234");
            }
        }
    }
}
