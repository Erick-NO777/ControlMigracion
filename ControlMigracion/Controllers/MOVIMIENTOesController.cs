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
    public class MOVIMIENTOesController : Controller
    {
        private ControlMigracionEntities1 db = new ControlMigracionEntities1();

        // GET: MOVIMIENTOes
        public ActionResult Index()
        {
            var mOVIMIENTOS = db.MOVIMIENTOS.Include(m => m.PAIS).Include(m => m.PAIS1).Include(m => m.USUARIO).Include(m => m.VIAJERO);
            return View(mOVIMIENTOS.ToList());
        }

        // GET: MOVIMIENTOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MOVIMIENTO mOVIMIENTO = db.MOVIMIENTOS.Find(id);
            if (mOVIMIENTO == null)
            {
                return HttpNotFound();
            }
            return View(mOVIMIENTO);
        }

        // GET: MOVIMIENTOes/Create
        public ActionResult Create()
        {
            ViewBag.Destino = new SelectList(db.PAISES, "Id", "NombrePais");
            ViewBag.Origen = new SelectList(db.PAISES, "Id", "NombrePais");
            ViewBag.IdUsuario = new SelectList(db.USUARIOS, "Id", "NombreUsuario");
            ViewBag.IdViajero = new SelectList(db.VIAJEROS, "Id", "Nombre");
            return View();
        }

        // POST: MOVIMIENTOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdViajero,Fecha,Destino,Origen,TipoSolicitud,IdUsuario")] MOVIMIENTO mOVIMIENTO)
        {
            if (ModelState.IsValid)
            {
                db.MOVIMIENTOS.Add(mOVIMIENTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Destino = new SelectList(db.PAISES, "Id", "NombrePais", mOVIMIENTO.Destino);
            ViewBag.Origen = new SelectList(db.PAISES, "Id", "NombrePais", mOVIMIENTO.Origen);
            ViewBag.IdUsuario = new SelectList(db.USUARIOS, "Id", "NombreUsuario", mOVIMIENTO.IdUsuario);
            ViewBag.IdViajero = new SelectList(db.VIAJEROS, "Id", "Nombre", mOVIMIENTO.IdViajero);
            return View(mOVIMIENTO);
        }

        // GET: MOVIMIENTOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MOVIMIENTO mOVIMIENTO = db.MOVIMIENTOS.Find(id);
            if (mOVIMIENTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.Destino = new SelectList(db.PAISES, "Id", "NombrePais", mOVIMIENTO.Destino);
            ViewBag.Origen = new SelectList(db.PAISES, "Id", "NombrePais", mOVIMIENTO.Origen);
            ViewBag.IdUsuario = new SelectList(db.USUARIOS, "Id", "NombreUsuario", mOVIMIENTO.IdUsuario);
            ViewBag.IdViajero = new SelectList(db.VIAJEROS, "Id", "Nombre", mOVIMIENTO.IdViajero);
            return View(mOVIMIENTO);
        }

        // POST: MOVIMIENTOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdViajero,Fecha,Destino,Origen,TipoSolicitud,IdUsuario")] MOVIMIENTO mOVIMIENTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mOVIMIENTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Destino = new SelectList(db.PAISES, "Id", "NombrePais", mOVIMIENTO.Destino);
            ViewBag.Origen = new SelectList(db.PAISES, "Id", "NombrePais", mOVIMIENTO.Origen);
            ViewBag.IdUsuario = new SelectList(db.USUARIOS, "Id", "NombreUsuario", mOVIMIENTO.IdUsuario);
            ViewBag.IdViajero = new SelectList(db.VIAJEROS, "Id", "Nombre", mOVIMIENTO.IdViajero);
            return View(mOVIMIENTO);
        }

        // GET: MOVIMIENTOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MOVIMIENTO mOVIMIENTO = db.MOVIMIENTOS.Find(id);
            if (mOVIMIENTO == null)
            {
                return HttpNotFound();
            }
            return View(mOVIMIENTO);
        }

        // POST: MOVIMIENTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MOVIMIENTO mOVIMIENTO = db.MOVIMIENTOS.Find(id);
            db.MOVIMIENTOS.Remove(mOVIMIENTO);
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
