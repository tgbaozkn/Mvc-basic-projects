using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Kutuphane.Models.Entity;

namespace Kutuphane.Controllers
{
    public class KaynaksController : Controller
    {
        // GET: Kaynaks
        KutuphaneEntities db = new KutuphaneEntities();
        public ActionResult Index(string k)
        {
            var kaynaklar = from m in db.kaynak select m;
            if (string.IsNullOrEmpty(k))
            {
                //işlem yazılan alan 
                return View(kaynaklar.ToList());
            }
            kaynaklar = kaynaklar.Where(f => f.kaynak_ad.Contains(k));
            return View(kaynaklar.ToList());
        }
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
        [HttpGet]
        public ActionResult YeniKaynak()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult YeniKaynak([Bind(Include = "kaynak_id,kaynak_ad")] kaynak k)
        {
            
           
            if (!ModelState.IsValid)
            {
               return View("YeniKaynak");
            
            }
            
                db.kaynak.Add(k);
                db.SaveChanges();
                return RedirectToAction("Index");
               
               
        }
        public ActionResult Sil(int id)
        {
            var kaynak = db.kaynak.Find(id);
            db.kaynak.Remove(kaynak);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Duzenle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kaynak kaynak = db.kaynak.Find(id);
            if (kaynak == null)
            {
                return HttpNotFound();
            }
            return View(kaynak);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Duzenle([Bind(Include = "kaynak_id,kaynak_ad")] kaynak kaynak, string ad,int id)
        {
            kaynak.kaynak_ad = ad;
            kaynak.kaynak_id = id;

            if (ModelState.IsValid)
            {
                db.Entry(kaynak).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kaynak);
        }
        
    }
}