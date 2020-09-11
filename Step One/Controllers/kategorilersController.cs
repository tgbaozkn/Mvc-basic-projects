using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kutuphane.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace Kutuphane.Controllers
{
    public class kategorilersController : Controller
    {
        private KutuphaneEntities db = new KutuphaneEntities();

        // GET: kategorilers
        public ActionResult Index(int sayfa=1) //int? null deger almasını sağlar null degeer alsa bile hata vermez
        {
            var ktgList = db.kategoriler.ToList().ToPagedList(sayfa, 2);
            return View(ktgList);
        }

        // GET: kategorilers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kategoriler kategoriler = db.kategoriler.Find(id);
            if (kategoriler == null)
            {
                return HttpNotFound();
            }
            return View(kategoriler);
        }

        // GET: kategorilers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: kategorilers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "kategori_id,kategori_ad")] kategoriler kategoriler,string kategori_ad)
        {
            kategoriler.kategori_ad = kategori_ad;
            if (ModelState.IsValid)
            {
                db.kategoriler.Add(kategoriler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kategoriler);
        }

        // GET: kategorilers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kategoriler kategoriler = db.kategoriler.Find(id);
            if (kategoriler == null)
            {
                return HttpNotFound();
            }
            return View(kategoriler);
        }

        // POST: kategorilers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "kategori_id,kategori_ad")] kategoriler kategoriler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kategoriler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kategoriler);
        }

        // GET: kategorilers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kategoriler kategoriler = db.kategoriler.Find(id);
            if (kategoriler == null)
            {
                return HttpNotFound();
            }
            return View(kategoriler);
        }

        // POST: kategorilers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            kategoriler kategoriler = db.kategoriler.Find(id);
            db.kategoriler.Remove(kategoriler);
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
