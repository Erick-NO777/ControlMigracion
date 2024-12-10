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
    public class DOCUMENTOesController : Controller
    {
        private ControlMigracionEntities1 db = new ControlMigracionEntities1();

        // GET: DOCUMENTOes
        public ActionResult Index()
        {
            var dOCUMENTOes = db.DOCUMENTOes.Include(d => d.VIAJERO);
            return View(dOCUMENTOes.ToList());
        }

        // GET: DOCUMENTOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOCUMENTO dOCUMENTO = db.DOCUMENTOes.Find(id);
            if (dOCUMENTO == null)
            {
                return HttpNotFound();
            }
            return View(dOCUMENTO);
        }

        // GET: DOCUMENTOes/Create
        public ActionResult Create()
        {
            ViewBag.IdViajero = new SelectList(db.VIAJEROS, "Id", "Nombre");
            return View();
        }

        // POST: DOCUMENTOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TipoDocumento,NumeroDocumento,FechaExpiracion,IdViajero")] DOCUMENTO dOCUMENTO)
        {
            if (ModelState.IsValid)
            {
                db.DOCUMENTOes.Add(dOCUMENTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdViajero = new SelectList(db.VIAJEROS, "Id", "Nombre", dOCUMENTO.IdViajero);
            return View(dOCUMENTO);
        }

        // GET: DOCUMENTOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOCUMENTO dOCUMENTO = db.DOCUMENTOes.Find(id);
            if (dOCUMENTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdViajero = new SelectList(db.VIAJEROS, "Id", "Nombre", dOCUMENTO.IdViajero);
            return View(dOCUMENTO);
        }

        // POST: DOCUMENTOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TipoDocumento,NumeroDocumento,FechaExpiracion,IdViajero")] DOCUMENTO dOCUMENTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dOCUMENTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdViajero = new SelectList(db.VIAJEROS, "Id", "Nombre", dOCUMENTO.IdViajero);
            return View(dOCUMENTO);
        }

        // GET: DOCUMENTOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOCUMENTO dOCUMENTO = db.DOCUMENTOes.Find(id);
            if (dOCUMENTO == null)
            {
                return HttpNotFound();
            }
            return View(dOCUMENTO);
        }

        // POST: DOCUMENTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DOCUMENTO dOCUMENTO = db.DOCUMENTOes.Find(id);
            db.DOCUMENTOes.Remove(dOCUMENTO);
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
