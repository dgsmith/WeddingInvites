using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeddingInvites.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Wedding invites description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Wedding invites contact page.";

            return View();
        }
    }
}