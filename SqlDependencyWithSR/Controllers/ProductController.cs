using SqlDependencyWithSR.Hubs;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace SqlDependencyWithSR.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Get()
        {
            using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbContext"].ConnectionString))
            {


                using (SqlCommand command = new SqlCommand("SELECT * FROM PRODUCTS", sqlConnection))
                {
                    command.Notification = null;
                    SqlDependency sqlDependency = new SqlDependency(command);
                    sqlDependency.OnChange += SqlDependency_OnChange;
                    sqlConnection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    var list = reader.Cast<IDataRecord>().Select(x => new
                    {
                        Id = (int)x["Id"],
                        Name = (string)x["Name"],
                        Buying = (decimal)x["BuyingPrice"],
                        Selling = (decimal)x["SellingPrice"]
                    }).ToList();

                    return Json(list, JsonRequestBehavior.AllowGet);
                }
            }
        }

        private void SqlDependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
           
            ProductHub.Show();
        }
    }
}