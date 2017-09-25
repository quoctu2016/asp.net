using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Configuration;
using System.Web.SessionState;

namespace benhvien
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DbSql.DbSql.connectionString = WebConfigurationManager.ConnectionStrings["db_name"].ToString();
        }
        protected void Session_Start(object sender, EventArgs e)
        {
            //Session["admin"] = false;
            Session["username"] = "";
            Session["id_loainv"] = "";
            Session["id"] = "";
        }
    }
}