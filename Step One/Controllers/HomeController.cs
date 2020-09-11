using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kutuphane.Models.Entity;
namespace Kutuphane.Controllers
{
    public class HomeController : Controller
    {
        KutuphaneEntities db = new KutuphaneEntities();
       
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Ara()

        {
            
            List<SelectListItem> degerler = (from i in db.kategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.kategori_ad,
                                                 Value = i.kategori_id.ToString()
                                             }
                                            ).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
    }
}