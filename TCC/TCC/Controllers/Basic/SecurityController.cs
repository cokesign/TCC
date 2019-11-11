using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using TCC.Models;
using TCC.ViewModels;

namespace TCC.Controllers
{
    public class SecurityController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Login";
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var DB = new Entities()){
                var user = DB.User.FirstOrDefault(f => f.Login == model.Login);

                if (user != null && user.Password == model.Password)
                    return RedirectToAction("Index", "Home");
                else
                    return View("Index");
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Logout(LoginViewModel model)
        {
            return View("Index", "Security");
        }
    }
}