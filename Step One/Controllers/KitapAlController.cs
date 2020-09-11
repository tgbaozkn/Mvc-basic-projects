using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kutuphane.Models.Entity;

namespace Kutuphane.Controllers
{
    public class KitapAlController : Controller
    {
        // GET: KitapAl
        KutuphaneEntities db = new KutuphaneEntities();
        public ActionResult Index()
        {
            var kaynaklar = db.kaynak.ToList();
            return View(kaynaklar);
        }
    }
}