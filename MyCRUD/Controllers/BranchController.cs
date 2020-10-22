using MyCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCRUD.Controllers
{
    public class BranchController : Controller
    {
        private ContextClass AppContext = new ContextClass();
        // GET: Branch
        public ActionResult Index()
        {
            List<Branch> AllBranch = AppContext.Branches.ToList();
            return View(AllBranch);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Branch branch)
        {
            AppContext.Branches.Add(branch);
            AppContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(string id)
        {
            Branch branch = AppContext.Branches.SingleOrDefault(x => x.BranchNo == id);
            return View(branch);
        }
    }
}