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
    public class librariesController : Controller
    {
        private KutuphaneEntities db = new KutuphaneEntities();

        // GET: libraries
        public ActionResult Index()
        {
            var library = db.library.Include(l => l.kategoriler).Include(l => l.kaynak).Include(l => l.yayınevi).Include(l => l.yazarlar);
            return View(library.ToList());
        }

        // GET: libraries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            library library = db.library.Find(id);
            if (library == null)
            {
                return HttpNotFound();
            }
            return View(library);
        }

        // GET: libraries/Create
        public ActionResult Create()
        {
            ViewBag.kategori_id = new SelectList(db.kategoriler, "kategori_id", "kategori_ad");
            ViewBag.kaynak_id = new SelectList(db.kaynak, "kaynak_id", "kaynak_ad");
            ViewBag.yayinevi_id = new SelectList(db.yayınevi, "yayınevi_id", "yayınevi_ad");
            ViewBag.yazar_id = new SelectList(db.yazarlar, "yazar_id", "yazar_ad");
            return View();
        }

        // POST: libraries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "library_id,yazar_id,yayinevi_id,kategori_id,kaynak_id")] library library)
        {
            if (ModelState.IsValid)
            {
                db.library.Add(library);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.kategori_id = new SelectList(db.kategoriler, "kategori_id", "kategori_ad", library.kategori_id);
            ViewBag.kaynak_id = new SelectList(db.kaynak, "kaynak_id", "kaynak_ad", library.kaynak_id);
            ViewBag.yayinevi_id = new SelectList(db.yayınevi, "yayınevi_id", "yayınevi_ad", library.yayinevi_id);
            ViewBag.yazar_id = new SelectList(db.yazarlar, "yazar_id", "yazar_ad", library.yazar_id);
            return View(library);
        }

        // GET: libraries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            library library = db.library.Find(id);
            if (library == null)
            {
                return HttpNotFound();
            }
            ViewBag.kategori_id = new SelectList(db.kategoriler, "kategori_id", "kategori_ad", library.kategori_id);
            ViewBag.kaynak_id = new SelectList(db.kaynak, "kaynak_id", "kaynak_ad", library.kaynak_id);
            ViewBag.yayinevi_id = new SelectList(db.yayınevi, "yayınevi_id", "yayınevi_ad", library.yayinevi_id);
            ViewBag.yazar_id = new SelectList(db.yazarlar, "yazar_id", "yazar_ad", library.yazar_id);
            return View(library);
        }

        // POST: libraries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "library_id,yazar_id,yayinevi_id,kategori_id,kaynak_id")] library library)
        {
            if (ModelState.IsValid)
            {
                db.Entry(library).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.kategori_id = new SelectList(db.kategoriler, "kategori_id", "kategori_ad", library.kategori_id);
            ViewBag.kaynak_id = new SelectList(db.kaynak, "kaynak_id", "kaynak_ad", library.kaynak_id);
            ViewBag.yayinevi_id = new SelectList(db.yayınevi, "yayınevi_id", "yayınevi_ad", library.yayinevi_id);
            ViewBag.yazar_id = new SelectList(db.yazarlar, "yazar_id", "yazar_ad", library.yazar_id);
            return View(library);
        }

        // GET: libraries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            library library = db.library.Find(id);
            if (library == null)
            {
                return HttpNotFound();
            }
            return View(library);
        }

        // POST: libraries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            library library = db.library.Find(id);
            db.library.Remove(library);
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
