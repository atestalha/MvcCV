using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models.Entity;

namespace WebApplication3.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        DbCvEntities1 db=new DbCvEntities1();
        public ActionResult Index()
        {
            var p=db.TblAbout.ToList();
            return View(p);
        }
        public PartialViewResult Experience()
        {
            var p = db.TblExperience.ToList();
            return PartialView(p);
        }
        public PartialViewResult SocialMedia()
        {
            var p = db.TblSocialMedia.Where(x=>x.State==true).ToList();
            return PartialView(p);
        }
        public PartialViewResult Education()
        {
            var p = db.TblEducation.ToList();
            return PartialView(p);
        }
        public PartialViewResult Skills()
        {
            var p = db.TblSkills.ToList();
            return PartialView(p);
        }
        public PartialViewResult Hobby()
        {
            var p = db.TblHobby.ToList();
            return PartialView(p);
        }
        public PartialViewResult Certificate()
        {
            var p = db.TblCertificate.ToList();
            return PartialView(p);
        }
        [HttpGet]
        public PartialViewResult Communication()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Communication(TblCommunication p)
        {
            p.Date=DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblCommunication.Add(p);
            db.SaveChanges();
            return PartialView();
        }
    }
}