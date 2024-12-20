using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Repesitories;
using WebApplication3.Models.Entity;

namespace WebApplication3.Controllers
{
    public class EducationController : Controller
    {
        GenericRepository<TblEducation> repo=new GenericRepository<TblEducation>();
        public ActionResult Index()
        {
            var education = repo.list();
            return View(education);
        }
        [HttpGet]
        public ActionResult AddEducation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEducation(TblEducation p)
        {
            if(!ModelState.IsValid)
            {
                return View("AddEducation");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult RemoveEducation(int id)
        {
            var education=repo.Find(x=>x.ID==id);
            repo.TRemove(education);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateEducation(int id)
        {
            var education=repo.Find(x => x.ID == id);
            return View(education);
        }
        [HttpPost]
        public ActionResult UpdateEducation(TblEducation p)
        {
            if(!ModelState.IsValid)
            {
                return View("UpdateEducation");
            }
            var education = repo.Find(x => x.ID == p.ID);
            education.Head = p.Head;
            education.SubHead1 = p.SubHead1;
            education.SubHead2 = p.SubHead2;
            education.Date = p.Date;
            education.GPA = p.GPA;
            repo.TUpdate(education); 
            return RedirectToAction("Index");
        }
    }
}