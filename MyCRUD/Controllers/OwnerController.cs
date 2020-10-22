using MyCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCRUD.Controllers
{
    public class OwnerController : Controller
    {
        private ContextClass AppContext = new ContextClass();
        public ActionResult Index()
        {
            List<Owner> AllOwner = AppContext.Owners.ToList();
            return View(AllOwner);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Owner owner)
        {
            AppContext.Owners.Add(owner);
            AppContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}