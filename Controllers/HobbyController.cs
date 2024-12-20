using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models.Entity;
using WebApplication3.Repesitories;

namespace WebApplication3.Controllers
{
    public class HobbyController : Controller
    {
        GenericRepository<TblHobby> repo=new GenericRepository<TblHobby>();
        
        [HttpGet]
        public ActionResult Index()
        {
            var hobby=repo.list();
            return View(hobby);
        }
        [HttpPost]
        public ActionResult Index(TblHobby p)
        {
            var hobby = repo.Find(x => x.ID == 1);
            hobby.Hobby1=p.Hobby1;
            hobby.Hobby2 =p.Hobby2;
            repo.TUpdate(hobby);
            return RedirectToAction("Index");
        }
    }
}