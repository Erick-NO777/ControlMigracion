using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ControlMigracion.Controllers
{
    public class VIAJEROesController : Controller
    {
        private ControlMigracionEntities1 db = new ControlMigracionEntities1();

        // GET: VIAJEROes
        public ActionResult Index()
        {
            return View(db.VIAJEROS.ToList());
        }

        // GET: VIAJEROes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VIAJERO vIAJERO = db.VIAJEROS.Find(id);
            if (vIAJERO == null)
            {
                return HttpNotFound();
            }
            return View(vIAJERO);
        }

        // GET: VIAJEROes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VIAJEROes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,SegundoNombre,Apellido1,Apellido2,FechaNacimiento,Nacionalidad,CorreoElectronico,Genero,Telefono")] VIAJERO vIAJERO)
        {
            if (ModelState.IsValid)
            {
                db.VIAJEROS.Add(vIAJERO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vIAJERO);
        }

        // GET: VIAJEROes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VIAJERO vIAJERO = db.VIAJEROS.Find(id);
            if (vIAJERO == null)
            {
                return HttpNotFound();
            }
            return View(vIAJERO);
        }

        // POST: VIAJEROes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,SegundoNombre,Apellido1,Apellido2,FechaNacimiento,Nacionalidad,CorreoElectronico,Genero,Telefono")] VIAJERO vIAJERO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vIAJERO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vIAJERO);
        }

        // GET: VIAJEROes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VIAJERO vIAJERO = db.VIAJEROS.Find(id);
            if (vIAJERO == null)
            {
                return HttpNotFound();
            }
            return View(vIAJERO);
        }

        // POST: VIAJEROes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VIAJERO vIAJERO = db.VIAJEROS.Find(id);
            db.VIAJEROS.Remove(vIAJERO);
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
