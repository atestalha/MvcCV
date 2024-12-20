using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Repesitories;
using WebApplication3.Models.Entity;

namespace WebApplication3.Controllers
{
    public class CertificateController : Controller
    {
        GenericRepository<TblCertificate> repo=new GenericRepository<TblCertificate>();
        public ActionResult Index()
        {
            var certificate = repo.list();
            return View(certificate);
        }
        [HttpGet]
        public ActionResult UpdateCertificate(int id)
        {
            var certificate=repo.Find(x=>x.ID==id);
            ViewBag.d = id;
            return View(certificate);
        }
        [HttpPost]
        public ActionResult UpdateCertificate(TblCertificate p)
        {
            var certificate=repo.Find(x=> x.ID==p.ID);
            certificate.Explanation = p.Explanation;
            certificate.Date = p.Date;
            repo.TUpdate(certificate);
            return View();
        }
        [HttpGet]
        public ActionResult NewCertificate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewCertificate(TblCertificate p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCertificate(int id)
        {
            var certificate=repo.Find(x=>x.ID == id);
            repo.TRemove(certificate);
            return RedirectToAction("Index");
        }
    }
}