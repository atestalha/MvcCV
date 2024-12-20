using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Repesitories;
using WebApplication3.Models.Entity;

namespace WebApplication3.Controllers
{
    public class SkillsController : Controller
    {
        GenericRepository<TblSkills> repo=new GenericRepository<TblSkills>();
        public ActionResult Index()
        {
            var skill = repo.list();
            return View(skill);
        }
        [HttpGet]
        public ActionResult NewSkills()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewSkills(TblSkills p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
    }
}