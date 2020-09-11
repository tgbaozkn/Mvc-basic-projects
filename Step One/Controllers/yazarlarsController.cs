using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kutuphane.Models.Entity;

namespace Kutuphane.Controllers
{
    public class yazarlarsController : Controller
    {
        private KutuphaneEntities db = new KutuphaneEntities();

        // GET: yazarlars
        public ActionResult Index()
        {
            return View(db.yazarlar.ToList());
        }

        // GET: yazarlars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            yazarlar yazarlar = db.yazarlar.Find(id);
            if (yazarlar == null)
            {
                return HttpNotFound();
            }
            return View(yazarlar);
        }

        // GET: yazarlars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: yazarlars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "yazar_id,yazar_ad")] yazarlar yazarlar,string yazar)
        {
            
            yazarlar.yazar_ad = yazar;
            if (ModelState.IsValid)
            {
                db.yazarlar.Add(yazarlar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(yazarlar);
        }

        // GET: yazarlars/Edit/5
       public ActionResult Show(int id)
        {
            var yazar = db.yazarlar.Find(id);
            return View("Show", yazar);
        }
       public ActionResult Guncelle(yazarlar yazar)
        {
            var yzr = db.yazarlar.Find(yazar.yazar_id);
            yzr.yazar_ad = yazar.yazar_ad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: yazarlars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            yazarlar yazarlar = db.yazarlar.Find(id);
            if (yazarlar == null)
            {
                return HttpNotFound();
            }
            return View(yazarlar);
        }

        // POST: yazarlars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            yazarlar yazarlar = db.yazarlar.Find(id);
            db.yazarlar.Remove(yazarlar);
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
