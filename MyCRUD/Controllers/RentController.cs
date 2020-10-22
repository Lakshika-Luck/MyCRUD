using MyCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCRUD.Controllers
{
    public class RentController : Controller
    {
        private ContextClass AppContext = new ContextClass();
        public ActionResult Index()
        {
            List<Rent> AllRent = AppContext.Rents.ToList();
            return View(AllRent);
        }

        public ActionResult Create()
        {
            ViewBag.OwnerDetails = AppContext.Owners;
            ViewBag.StaffDetails = AppContext.Staffs;
            ViewBag.BranchDetails = AppContext.Branches;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Owner owner)
        {
            ViewBag.OwnerDetails = AppContext.Owners;
            AppContext.Owners.Add(owner);
            AppContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Create(Staff staff)
        {
            ViewBag.StaffDetails = AppContext.Staffs;
            AppContext.Staffs.Add(staff);
            AppContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Create(Branch branch)
        {
            ViewBag.BranchDetails = AppContext.Branches;
            AppContext.Branches.Add(branch);
            AppContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}