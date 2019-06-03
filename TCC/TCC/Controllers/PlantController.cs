using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TCC.Helper;
using TCC.Models;
using TCC.ViewModels;

namespace TCC.Controllers
{
    public class PlantController : Controller
    {
        private Entities db = new Entities();

        public ActionResult Index()
        {
            ViewBag.Title = "Plantas";
            return View(db.Plant.ToList());
        }

        public ActionResult Details(int? id)
        {
            ViewBag.Title = "Plantas";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plant plant = db.Plant.Find(id);
            if (plant == null)
            {
                return HttpNotFound();
            }
            return View(plant);
        }

        public ActionResult Create()
        {
            ViewBag.Title = "Plantas";
            var Plant = new PlantViewModel() {
                Category = new SelectList(db.Category, "Id", "Description", null)
            };
            return View(Plant);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdCategory,Description,Active,MinMoisture,MaxMoisture")] PlantViewModel plant)
        {
            if (ModelState.IsValid)
            {
                var Plant = new Plant();
                Helper.Helper.Mapper(Plant,plant);
                db.Plant.Add(Plant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(plant);
        }

        public ActionResult Edit(int? id)
        {
            ViewBag.Title = "Plantas";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plant plant = db.Plant.Find(id);
            if (plant == null)
            {
                return HttpNotFound();
            }
            var Plant = new PlantViewModel();
            Helper.Helper.Mapper(Plant, plant);
            Plant.Category = new SelectList(db.Category.AsNoTracking().Where(w => w.Active), "Id", "Description", plant.IdCategory ?? null);
            return View(Plant);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdCategory,Description,Active,MinMoisture,MaxMoisture")] PlantViewModel plant)
        {
            ViewBag.Title = "Plantas";
            if (ModelState.IsValid)
            {
                var Plant = new Plant();
                Helper.Helper.Mapper(Plant, plant);
                db.Entry(Plant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(plant);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            Plant plant = db.Plant.Find(id);
            db.Plant.Remove(plant);
            db.SaveChanges();
            return Json(new GenericJsonResult()
            {
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
