using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SqlDependencyWithSR.Hubs
{
    [HubName("products")]
    public class ProductHub:Hub
    {
        public static void Show()
        {
            IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<ProductHub>();
            hubContext.Clients.All.displayProducts();

        }
    }
}