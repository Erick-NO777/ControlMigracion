﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ControlMigracion.Controllers
{
    public class PAISController : Controller
    {
        private ControlMigracionEntities1 db = new ControlMigracionEntities1();

        // GET: PAIS
        public ActionResult Index()
        {
            return View(db.PAISES.ToList());
        }

        // GET: PAIS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAIS pAIS = db.PAISES.Find(id);
            if (pAIS == null)
            {
                return HttpNotFound();
            }
            return View(pAIS);
        }

        // GET: PAIS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PAIS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NombrePais")] PAIS pAIS)
        {
            if (ModelState.IsValid)
            {
                db.PAISES.Add(pAIS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pAIS);
        }

        // GET: PAIS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAIS pAIS = db.PAISES.Find(id);
            if (pAIS == null)
            {
                return HttpNotFound();
            }
            return View(pAIS);
        }

        // POST: PAIS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NombrePais")] PAIS pAIS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pAIS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pAIS);
        }

        // GET: PAIS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAIS pAIS = db.PAISES.Find(id);
            if (pAIS == null)
            {
                return HttpNotFound();
            }
            return View(pAIS);
        }

        // POST: PAIS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PAIS pAIS = db.PAISES.Find(id);
            db.PAISES.Remove(pAIS);
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
