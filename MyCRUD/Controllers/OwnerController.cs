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
        public ActionResult Details(String id)
        {
            Owner owner = AppContext.Owners.SingleOrDefault(x => x.OwnerNo == id);
            return View(owner);
        }

        public ActionResult Edit(String id)
        {
            Owner owner = AppContext.Owners.SingleOrDefault(x => x.OwnerNo == id);
            ViewBag.OwnerDetails = new SelectList(AppContext.Owners, "OwnerNo");
            return View(owner);
        }
        [HttpPost]
        public ActionResult Edit(String id, Owner updatedOwners)
        {
            Owner owner = AppContext.Owners.SingleOrDefault(x => x.OwnerNo == id);
            owner.OwnerNo = updatedOwners.OwnerNo;
            owner.Fname = updatedOwners.Fname;
            owner.Lname = updatedOwners.Lname;
            owner.Address = updatedOwners.Address;
            owner.TelNo = updatedOwners.TelNo;
            AppContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(String id)
        {
            Owner owner = AppContext.Owners.SingleOrDefault(x => x.OwnerNo == id);
            return View(owner);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteOwner(String id)
        {
            Owner owner = AppContext.Owners.SingleOrDefault(x => x.OwnerNo == id);
            AppContext.Owners.Remove(owner);
            AppContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}