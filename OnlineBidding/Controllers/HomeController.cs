using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineBidding.DataInitializer;

namespace OnlineBidding.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            TestDataHelper.InitializeSchemaAndData(System.Web.HttpContext.Current.Server.MapPath("~/App_Data/TestData.xml"));
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}