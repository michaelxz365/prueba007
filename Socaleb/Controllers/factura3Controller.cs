using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Socaleb.Models;

namespace Socaleb.Controllers
{
    public class factura3Controller : Controller
    {
        private DB_A4A54F_socalebEntities db = new DB_A4A54F_socalebEntities();
        public ActionResult mora()
        {

            var mora = (from k in db.factura3 where k.estatus == "no pago" select k).Include(k=>k.inquilino);
            return View(mora.ToList().AsEnumerable());
        }


        


        // GET: factura3
        public ActionResult Index(String searchString)
        {
            var factura3 = db.factura3.Include(f => f.inquilino);
            if (!String.IsNullOrEmpty(searchString))
            {
                factura3 = factura3.Where(o=>o.inquilino.nombre.Contains(searchString));
            }

           
            return View(factura3.ToList());
        }

        // GET: factura3/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            factura3 factura3 = db.factura3.Find(id);
            if (factura3 == null)
            {
                return HttpNotFound();
            }
            return View(factura3);
        }

        // GET: factura3/Create
        public ActionResult Create()
        {
            ViewBag.idInquilono = new SelectList(db.inquilino, "idInquilino", "nombre");
            return View();
        }

        // POST: factura3/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Idfactura,monto,fecha,estatus,idInquilono")] factura3 factura3)
        {
            if (ModelState.IsValid)
            {
                db.factura3.Add(factura3);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idInquilono = new SelectList(db.inquilino, "idInquilino", "nombre", factura3.idInquilono);
            return View(factura3);
        }

        // GET: factura3/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            factura3 factura3 = db.factura3.Find(id);
            if (factura3 == null)
            {
                return HttpNotFound();
            }
            ViewBag.idInquilono = new SelectList(db.inquilino, "idInquilino", "nombre", factura3.idInquilono);
            return View(factura3);
        }

        // POST: factura3/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Idfactura,monto,fecha,estatus,idInquilono")] factura3 factura3)
        {
            if (ModelState.IsValid)
            {
                db.Entry(factura3).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idInquilono = new SelectList(db.inquilino, "idInquilino", "nombre", factura3.idInquilono);
            return View(factura3);
        }

        // GET: factura3/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            factura3 factura3 = db.factura3.Find(id);
            if (factura3 == null)
            {
                return HttpNotFound();
            }
            return View(factura3);
        }

        // POST: factura3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            factura3 factura3 = db.factura3.Find(id);
            db.factura3.Remove(factura3);
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
