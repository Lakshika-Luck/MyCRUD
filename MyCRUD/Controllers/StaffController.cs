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
        public ActionResult Details(String id)
        {
            Staff staff = AppContext.Staffs.SingleOrDefault(x => x.StaffNo == id);
            return View(staff);
        }

        public ActionResult Edit(String id)
        {
            Staff staff = AppContext.Staffs.SingleOrDefault(x => x.StaffNo == id);
            ViewBag.BranchDetails = new SelectList(AppContext.Branches, "BranchNo", "Street");
            return View(staff);
            
        }
        [HttpPost]
        public ActionResult Edit(String id, Staff updatedStaff)
        {
            Staff staff = AppContext.Staffs.SingleOrDefault(x => x.StaffNo == id);
            staff.StaffNo = updatedStaff.StaffNo;
            staff.Fname = updatedStaff.Fname;
            staff.Lname = updatedStaff.Lname;
            staff.Position = updatedStaff.Position;
            staff.DOB = updatedStaff.DOB;
            staff.Salary = updatedStaff.Salary;
            AppContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(String id)
        {
            Staff staff = AppContext.Staffs.SingleOrDefault(x => x.StaffNo == id);
            return View(staff);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteStaff(String id)
        {
            Staff staff = AppContext.Staffs.SingleOrDefault(x => x.StaffNo == id);
            AppContext.Staffs.Remove(staff);
            AppContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult StaffPosition()
        {
            var AllStaff = AppContext.Staffs.ToList();
            int x = 0;
            int y = 0;

            foreach (Staff staff in AllStaff)
            {
                x = x + 1;
            }
            string[] pos = new string[x];

            foreach (Staff staff in AllStaff)
            {
                pos[y] = staff.Position;
                y = y + 1;
            }
            var Array = pos.Distinct().ToArray();
            ViewBag.StaffPosition = Array;

            return View();
        }
        public ActionResult Staff_Position(string po)
        {
            List<Staff> staff = AppContext.Staffs.Where(x => x.Position == po).ToList();
            return View(staff);
        }
    }
 }
