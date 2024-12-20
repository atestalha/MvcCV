using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models.Entity;
using WebApplication3.Repesitories;

namespace WebApplication3.Controllers
{
    public class CommunicateController : Controller
    {
        GenericRepository<TblCommunication> repo=new GenericRepository<TblCommunication>();
        public ActionResult Index()
        {
            var communicate=repo.list();
            return View(communicate);
        }
    }
}