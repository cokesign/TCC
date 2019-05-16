using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TCC.Controllers
{
    public class SharedController : Controller
    {
        public ActionResult SideBar()
        {
            return View();
        }

        public ActionResult NavBar()
        {
            ViewBag.User = "Pedro";
            return View();
        }
    }
}