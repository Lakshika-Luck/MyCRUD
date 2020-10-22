using MyCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCRUD.Controllers
{
    public class StaffController : Controller
    {
        private ContextClass AppContext = new ContextClass();
        public ActionResult Index()
        {
            List<Staff> Allstaff = AppContext.Staffs.ToList();
           return View(Allstaff);
           
        }
        public ActionResult Create()
        {
            ViewBag.BranchDetails = AppContext.Branches;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Staff staff)
        {
            ViewBag.BranchDetails = AppContext.Branches;
            AppContext.Staffs.Add(staff);
            AppContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}