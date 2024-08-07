using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
using PagedList;
using PagedList.Mvc;
namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori

        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index(int sayfa=1)
        {
            //var degeler=db.TBLKATEGORİLER.ToList();
            var degeler = db.TBLKATEGORİLER.ToList().ToPagedList(sayfa, 4);
            return View(degeler);
        }
        [HttpGet]
        public ActionResult YeniKategori()
        { 
        
            return View();
        }
        [HttpPost]
        public ActionResult YeniKategori(TBLKATEGORİLER p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.TBLKATEGORİLER.Add(p1);
            db.SaveChanges();
            return View();

        }
        public ActionResult Sil(int id) 
        {
             
            var kategori=db.TBLKATEGORİLER.Find(id);
            db.TBLKATEGORİLER.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");   
        }
        public ActionResult KategoriGetir(int id) 
        {
            var ktgr = db.TBLKATEGORİLER.Find(id);
            return View("KategoriGetir",ktgr);  
        }
        public ActionResult Guncelle(TBLKATEGORİLER p1)
        {
            var ktg = db.TBLKATEGORİLER.Find(p1.KATEGORIID);
            ktg.KATEGORIAD = p1.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");   

        }
    }
}