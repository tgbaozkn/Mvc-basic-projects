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
    public class yayıneviController : Controller
    {
        private KutuphaneEntities db = new KutuphaneEntities();

        // GET: yayınevi
        public ActionResult Index()
        {
            return View(db.yayınevi.ToList());
        }

        // GET: yayınevi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            yayınevi yayınevi = db.yayınevi.Find(id);
            if (yayınevi == null)
            {
                return HttpNotFound();
            }
            return View(yayınevi);
        }

        // GET: yayınevi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: yayınevi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "yayınevi_id,yayınevi_ad")] yayınevi yayınevi,string yayinevi)
        {
            yayınevi.yayınevi_ad = yayinevi;
            if (ModelState.IsValid)
            {
                db.yayınevi.Add(yayınevi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(yayınevi);
        }

        // GET: yayınevi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            yayınevi yayınevi = db.yayınevi.Find(id);
            if (yayınevi == null)
            {
                return HttpNotFound();
            }
            return View(yayınevi);
        }

        // POST: yayınevi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "yayınevi_id,yayınevi_ad")] yayınevi yayınevi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yayınevi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(yayınevi);
        }

        // GET: yayınevi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            yayınevi yayınevi = db.yayınevi.Find(id);
            if (yayınevi == null)
            {
                return HttpNotFound();
            }
            return View(yayınevi);
        }

        // POST: yayınevi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            yayınevi yayınevi = db.yayınevi.Find(id);
            db.yayınevi.Remove(yayınevi);
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
