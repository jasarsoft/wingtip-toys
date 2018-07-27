using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Data.Entity;
using WingtipToys.Models;
using WingtipToys.Logic;



namespace WingtipToys
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Initialize the product database.
            Database.SetInitializer<ProductContext>(new ProductDatabaseInitializer());

            using (var context = new ProductContext())
            {
                context.Database.Initialize(true);
            }

            // Create the custom role and user.
            RoleActions roleActions = new RoleActions();
            roleActions.AddUserAndRole();
        }
    }
}