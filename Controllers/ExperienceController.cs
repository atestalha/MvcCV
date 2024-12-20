using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models.Entity;
using WebApplication3.Repesitories;

namespace WebApplication3.Controllers
{
    public class ExperienceController : Controller
    {
        ExperienceRepository repo = new ExperienceRepository();
        public ActionResult Index()
        {
            var x = repo.list();
            return View(x);
        }
        [HttpGet]
        public ActionResult AddExperience()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddExperience(TblExperience p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult RemoveExperience(int id)
        {
            TblExperience t = repo.Find(x => x.ID == id);
            repo.TRemove(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult BringExperience(int id)
        {
            TblExperience t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult BringExperience(TblExperience p)
        {
            TblExperience t = repo.Find(x => x.ID == p.ID);
            t.Head = p.Head;
            t.SubHead = p.SubHead;
            t.Date = p.Date;
            t.Explanation = p.Explanation;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}