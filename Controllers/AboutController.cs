using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models.Entity;
using WebApplication3.Repesitories;

namespace WebApplication3.Controllers
{
    public class AboutController : Controller
    {
        GenericRepository<TblAbout> repo=new GenericRepository<TblAbout>();
        [HttpGet]
        public ActionResult Index()
        {
            var about=repo.list();
            return View(about);
        }
        [HttpPost]
        public ActionResult Index(TblAbout p)
        {
            var about = repo.Find(x => x.ID == 1);
            about.Name = p.Name;
            about.Surname = p.Surname;
            about.Address = p.Address;
            about.CallNumber = p.CallNumber;
            about.Mail=p.Mail;
            about.Explanation = p.Explanation;
            about.Picture = p.Picture;
            repo.TUpdate(about);
            return RedirectToAction("Index");
        }
    }
}