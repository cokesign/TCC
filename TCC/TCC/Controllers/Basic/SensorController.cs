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

namespace TCC.Controllers
{
    public class SensorController : Controller
    {
        private Entities db = new Entities();

        public ActionResult Index()
        {
            ViewBag.Title = "Sensores";
            return View(db.Sensor.ToList());
        }

        public ActionResult Details(int? id)
        {
            ViewBag.Title = "Sensores";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sensor sensor = db.Sensor.Find(id);
            if (sensor == null)
            {
                return HttpNotFound();
            }
            return View(sensor);
        }

        public ActionResult Create()
        {
            ViewBag.Title = "Sensores";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,Active")] Sensor sensor)
        {
            ViewBag.Title = "Sensores";
            if (ModelState.IsValid)
            {
                db.Sensor.Add(sensor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sensor);
        }

        public ActionResult Edit(int? id)
        {
            ViewBag.Title = "Sensores";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sensor sensor = db.Sensor.Find(id);
            if (sensor == null)
            {
                return HttpNotFound();
            }
            return View(sensor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,Active")] Sensor sensor)
        {
            ViewBag.Title = "Sensores";
            if (ModelState.IsValid)
            {
                db.Entry(sensor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sensor);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            Sensor sensor = db.Sensor.Find(id);
            db.Sensor.Remove(sensor);
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
