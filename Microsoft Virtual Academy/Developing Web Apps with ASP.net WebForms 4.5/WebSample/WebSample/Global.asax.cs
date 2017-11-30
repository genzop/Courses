//base libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using WebSample;

//added imports
using System.Data.Entity;
using WebSample.BLL.Model;

namespace WebSample
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterOpenAuth();

            Database.SetInitializer<ProductContext>(new ProductModelInitializer());

            //add the routing tables to the application
            RouteTable.Routes.MapPageRoute("Categories", "SiteAdministration/Categories", "~/SiteAdministration/CategoriesRep.aspx");
            RouteTable.Routes.MapPageRoute("Products", "SiteAdministration/Products", "~/SiteAdministration/ProductsRep.aspx");

            RouteTable.Routes.MapPageRoute("NewCategory", "SiteAdministration/Categories/New",
                "~/SiteAdministration/CategoryDetailsRep.aspx", false, new RouteValueDictionary { { "Command", "new" } });
            RouteTable.Routes.MapPageRoute("NewProduct", "SiteAdministration/Poducts/New",
               "~/SiteAdministration/ProductDetailsRep.aspx", false, new RouteValueDictionary { { "Command", "new" } });

            //add the complex routes to allow the viewing of details for a product / category
            RouteTable.Routes.MapPageRoute("CategoryDetails", "SiteAdministration/Categories/{id}",
                "~/SiteAdministration/CategoryDetailsRep.aspx");
            RouteTable.Routes.MapPageRoute("ProductDetails", "SiteAdministration/Products/{id}",
               "~/SiteAdministration/ProductDetailsRep.aspx");
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }
    }
}
