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
        public ActionResult Details(String id)
        {
            Branch branch = AppContext.Branches.SingleOrDefault(x => x.BranchNo == id);
            return View(branch);
        }

        public ActionResult Edit(String id)
        {
            Branch branch = AppContext.Branches.SingleOrDefault(x => x.BranchNo == id);
            ViewBag.BranchDetails = new SelectList(AppContext.Branches, "BranchNo");
            return View(branch);
        }
        [HttpPost]
        public ActionResult Edit(String id, Branch updatedBranches)
        {
            Branch branch = AppContext.Branches.SingleOrDefault(x => x.BranchNo == id);
            branch.BranchNo = updatedBranches.BranchNo;
            branch.Street = updatedBranches.Street;
            branch.City = updatedBranches.City;
            branch.PostCode = updatedBranches.PostCode;
            AppContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(String id)
        {
            Branch branch = AppContext.Branches.SingleOrDefault(x => x.BranchNo == id);
            return View(branch);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteBranch(String id)
        {
            Branch branch = AppContext.Branches.SingleOrDefault(x => x.BranchNo == id);
            AppContext.Branches.Remove(branch);
            AppContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
