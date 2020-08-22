using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace webSede.Models
{
    public class SedesController : Controller
    {
        private dbsedesEntities db = new dbsedesEntities();

        // GET: Sedes
        public ActionResult Index()
        {
            return View(db.Sede.ToList());
        }

        // GET: Sedes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sede sede = db.Sede.Find(id);
            if (sede == null)
            {
                return HttpNotFound();
            }
            return View(sede);
        }

        // GET: Sedes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sedes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_sede,nombre,direccion,presupuesto,tipo_sede,num_complejo")] Sede sede)
        {
            if (ModelState.IsValid)
            {
                db.Sede.Add(sede);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sede);
        }

        // GET: Sedes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sede sede = db.Sede.Find(id);
            if (sede == null)
            {
                return HttpNotFound();
            }
            return View(sede);
        }

        // POST: Sedes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_sede,nombre,direccion,presupuesto,tipo_sede,num_complejo")] Sede sede)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sede).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sede);
        }

        // GET: Sedes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sede sede = db.Sede.Find(id);
            if (sede == null)
            {
                return HttpNotFound();
            }
            return View(sede);
        }

        // POST: Sedes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sede sede = db.Sede.Find(id);
            db.Sede.Remove(sede);
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
