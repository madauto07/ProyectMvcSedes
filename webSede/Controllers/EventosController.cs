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
    public class EventosController : Controller
    {
        private dbsedesEntities db = new dbsedesEntities();

        // GET: Eventos
        public ActionResult Index()
        {
            var eventos = db.Eventos.Include(e => e.Sede_Complejo);
            return View(eventos.ToList());
        }

        // GET: Eventos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eventos eventos = db.Eventos.Find(id);
            if (eventos == null)
            {
                return HttpNotFound();
            }
            return View(eventos);
        }

        // GET: Eventos/Create
        public ActionResult Create()
        {
            ViewBag.id_complejo = new SelectList(db.Sede_Complejo, "id_complejo", "nombre");
            return View();
        }

        // POST: Eventos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_evento,id_complejo,nombre,fecha,duracion,num_participante,num_comisario,tipo")] Eventos eventos)
        {
            if (ModelState.IsValid)
            {
                db.Eventos.Add(eventos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_complejo = new SelectList(db.Sede_Complejo, "id_complejo", "nombre", eventos.id_complejo);
            return View(eventos);
        }

        // GET: Eventos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eventos eventos = db.Eventos.Find(id);
            if (eventos == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_complejo = new SelectList(db.Sede_Complejo, "id_complejo", "nombre", eventos.id_complejo);
            return View(eventos);
        }

        // POST: Eventos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_evento,id_complejo,nombre,fecha,duracion,num_participante,num_comisario,tipo")] Eventos eventos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_complejo = new SelectList(db.Sede_Complejo, "id_complejo", "nombre", eventos.id_complejo);
            return View(eventos);
        }

        // GET: Eventos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eventos eventos = db.Eventos.Find(id);
            if (eventos == null)
            {
                return HttpNotFound();
            }
            return View(eventos);
        }

        // POST: Eventos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Eventos eventos = db.Eventos.Find(id);
            db.Eventos.Remove(eventos);
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
