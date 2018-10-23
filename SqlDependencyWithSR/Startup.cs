using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
[assembly: OwinStartupAttribute(typeof(SqlDependencyWithSR.Startup))]
namespace SqlDependencyWithSR
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           // ConfigureAuth(app);
            app.MapSignalR();
        }

       
    }
}