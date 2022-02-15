using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Data;

namespace BubbleTea
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        static void RegisterRoutes(RouteCollection routes)
        {
            //routes.MapPageRoute("Uniquename", "Name to shown on Adddress bar AND for redirecting", "Physical Path to the page");
            routes.MapPageRoute("Home", "Home", "~/Default.aspx");
            routes.MapPageRoute("About", "AboutUs", "~/About.aspx");
            routes.MapPageRoute("Default", "Default", "~/Default.aspx");
            routes.MapPageRoute("Shop", "Shop", "~/Shop.aspx");
            routes.MapPageRoute("Search", "Search", "~/Search.aspx");
            routes.MapPageRoute("Login", "Login", "~/Login.aspx");
            routes.MapPageRoute("Register", "Register", "~/Register.aspx");
            routes.MapPageRoute("Cart", "Cart", "~/Cart.aspx");
            routes.MapPageRoute("Checkout", "Checkout", "~/Checkout.aspx");
            routes.MapPageRoute("Verify", "Verify", "~/Verify.aspx");
            routes.MapPageRoute("Dashboard", "Dashboard", "~/Dashboard.aspx");
            routes.MapPageRoute("EUsers", "EUsers", "~/ViewUsers.aspx");
            routes.MapPageRoute("Forgot", "Forgot", "~/ForgotPwd.aspx");
            routes.MapPageRoute("Profile", "Profile", "~/Profile.aspx");
            routes.MapPageRoute("Details", "Details", "~/Details.aspx");
            routes.MapPageRoute("RemoveAcc", "RemoveAcc", "~/RemoveAcc.aspx");
            routes.MapPageRoute("RemoveCart", "RemoveCart", "~/RemoveCart.aspx");
        }

    }
}