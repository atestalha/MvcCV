using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Repesitories;
using WebApplication3.Models.Entity;
using System.Net;

namespace WebApplication3.Controllers
{
    public class SocialMediaController : Controller
    {
        GenericRepository<TblSocialMedia> repo=new GenericRepository<TblSocialMedia>();
        public ActionResult Index()
        {
            var socialmedia = repo.list();
            return View(socialmedia);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(TblSocialMedia p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Update(TblSocialMedia p)
        {
           var socialmedia=repo.Find(x=>x.ID==p.ID);
            socialmedia.Name = p.Name;
            socialmedia.State = true;
            socialmedia.Link = p.Link;
            socialmedia.icon = p.icon;
            repo.TUpdate(p);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var socialmedia = repo.Find(x => x.ID == id);
            socialmedia.State = false;
            repo.TRemove(socialmedia);
            return RedirectToAction("Index");
        }
    }
}