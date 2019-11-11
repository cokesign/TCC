using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TCC.Helper;
using TCC.Models;

namespace TCC.Controllers
{
    public class UserController : Controller
    {
        private Entities db = new Entities();

        public ActionResult Index()
        {
            ViewBag.Title = "Usuarios";
            return View(db.User.ToList());
        }

        public ActionResult Details(int? id)
        {
            User user = db.User.Find(1);
            return View(user);
        }

        public ActionResult Create()
        {
            ViewBag.Title = "Usuarios";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Login,Password,Name,LastName,Age,Active")] User user)
        {
            if (ModelState.IsValid)
            {
                db.User.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        public ActionResult Edit(int? id)
        {
            ViewBag.Title = "Usuarios";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Login,Password,Name,LastName,Age,Active")] User user)
        {
            ViewBag.Title = "Usuarios";
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            User user = db.User.Find(id);
            db.User.Remove(user);
            db.SaveChanges();
            return Json(new GenericJsonResult() {
                OK = true,
                Message = "Deletado com Sucesso!"
            }, JsonRequestBehavior.DenyGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
