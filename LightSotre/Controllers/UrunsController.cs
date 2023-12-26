using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LightSotre.Models;

namespace LightSotre.Controllers
{
    public class UrunsController : Controller
    {
        private Context db = new Context();
        [AllowAnonymous]
        // GET: Uruns
        public ActionResult Index()
        {
            var urun = db.Urun.Include(u => u.Kategore);
            return View(urun.ToList());
        }

        // GET: Uruns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urun urun = db.Urun.Find(id);
            if (urun == null)
            {
                return HttpNotFound();
            }
            return View(urun);
        }

        // GET: Uruns/Create
        public ActionResult Create()
        {
            ViewBag.Kategore_ID = new SelectList(db.Kategore, "KatagoreId", "KategoreIsim");
            return View();
        }

        // POST: Uruns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UrunId,UrunIsim,Kategore_ID,urunFiyat,urunOzellikler,urunImage")] Urun urun)
        {
            if (ModelState.IsValid)
            {
                db.Urun.Add(urun);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Kategore_ID = new SelectList(db.Kategore, "KatagoreId", "KategoreIsim", urun.Kategore_ID);
            return View(urun);
        }

        // GET: Uruns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urun urun = db.Urun.Find(id);
            if (urun == null)
            {
                return HttpNotFound();
            }
            ViewBag.Kategore_ID = new SelectList(db.Kategore, "KatagoreId", "KategoreIsim", urun.Kategore_ID);
            return View(urun);
        }

        // POST: Uruns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UrunId,UrunIsim,Kategore_ID,urunFiyat,urunOzellikler,urunImage")] Urun urun)
        {
            if (ModelState.IsValid)
            {
                db.Entry(urun).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Kategore_ID = new SelectList(db.Kategore, "KatagoreId", "KategoreIsim", urun.Kategore_ID);
            return View(urun);
        }

        // GET: Uruns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urun urun = db.Urun.Find(id);
            if (urun == null)
            {
                return HttpNotFound();
            }
            return View(urun);
        }

        // POST: Uruns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Urun urun = db.Urun.Find(id);
            db.Urun.Remove(urun);
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
