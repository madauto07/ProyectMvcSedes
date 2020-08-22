using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using webSede.Models;

namespace webSede.Controllers
{
    public class ComplejoController : Controller
    {
        private dbsedesEntities db = new dbsedesEntities();

        // GET: Complejo
        public ActionResult Index()
        {
            var sede_Complejo = db.Sede_Complejo.Include(s => s.Sede);
            return View(sede_Complejo.ToList());
        }

        // GET: Complejo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sede_Complejo sede_Complejo = db.Sede_Complejo.Find(id);
            if (sede_Complejo == null)
            {
                return HttpNotFound();
            }
            return View(sede_Complejo);
        }

        // GET: Complejo/Create
        public ActionResult Create()
        {
            ViewBag.id_sede = new SelectList(db.Sede, "id_sede", "nombre");
            return View();
        }

        // POST: Complejo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_complejo,id_sede,tipo_sede,nombre,area,localizacion,Jefe_organizacion")] Sede_Complejo sede_Complejo)
        {
            if (ModelState.IsValid)
            {
                db.Sede_Complejo.Add(sede_Complejo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_sede = new SelectList(db.Sede, "id_sede", "nombre", sede_Complejo.id_sede);
            return View(sede_Complejo);
        }

        // GET: Complejo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sede_Complejo sede_Complejo = db.Sede_Complejo.Find(id);
            if (sede_Complejo == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_sede = new SelectList(db.Sede, "id_sede", "nombre", sede_Complejo.id_sede);
            return View(sede_Complejo);
        }

        // POST: Complejo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_complejo,id_sede,tipo_sede,nombre,area,localizacion,Jefe_organizacion")] Sede_Complejo sede_Complejo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sede_Complejo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_sede = new SelectList(db.Sede, "id_sede", "nombre", sede_Complejo.id_sede);
            return View(sede_Complejo);
        }

        // GET: Complejo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sede_Complejo sede_Complejo = db.Sede_Complejo.Find(id);
            if (sede_Complejo == null)
            {
                return HttpNotFound();
            }
            return View(sede_Complejo);
        }

        // POST: Complejo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sede_Complejo sede_Complejo = db.Sede_Complejo.Find(id);
            db.Sede_Complejo.Remove(sede_Complejo);
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
