﻿using MyCRUD.Models;
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
            ViewBag.BranchDetails = new SelectList(AppContext.Staffs, "StaffNo", "FName");
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
        public ActionResult DeleteEmployee(String id)
        {
            Staff staff = AppContext.Staffs.SingleOrDefault(x => x.StaffNo == id);
            AppContext.Staffs.Remove(staff);
            AppContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
 }
