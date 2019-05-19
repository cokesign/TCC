using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TCC.Models;

namespace TCC.Controllers
{
    public class SensorController : Controller
    {
        private Entities db = new Entities();

        // GET: Sensor
        public ActionResult Index()
        {
            ViewBag.Title = "Sensores";
            return View(db.Sensor.ToList());
        }

        // GET: Sensor/Details/5
        public ActionResult Details(int? id)
        {
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

        // GET: Sensor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sensor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,Active")] Sensor sensor)
        {
            if (ModelState.IsValid)
            {
                db.Sensor.Add(sensor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sensor);
        }

        // GET: Sensor/Edit/5
        public ActionResult Edit(int? id)
        {
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

        // POST: Sensor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,Active")] Sensor sensor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sensor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sensor);
        }

        // GET: Sensor/Delete/5
        public ActionResult Delete(int? id)
        {
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

        // POST: Sensor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sensor sensor = db.Sensor.Find(id);
            db.Sensor.Remove(sensor);
            db.SaveChanges();
            return RedirectToAction("Index");
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
