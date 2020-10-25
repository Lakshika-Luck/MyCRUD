﻿using MyCRUD.Models;
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
            ViewBag.BranchDetails = AppContext.Branches;
            ViewBag.StaffDetails = AppContext.Staffs;
            ViewBag.OwnerDetails = AppContext.Owners;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Rent rent)
        {

            AppContext.Rents.Add(rent);
            AppContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(String id)
        {
            Rent rent = AppContext.Rents.SingleOrDefault(x => x.PropertyNo == id);
            return View(rent);
        }

        public ActionResult Edit(String id)
        {
            Rent rent = AppContext.Rents.SingleOrDefault(x => x.PropertyNo == id);
            ViewBag.BranchDetails = AppContext.Branches;
            ViewBag.StaffDetails = AppContext.Staffs;
            ViewBag.OwnerDetails = AppContext.Owners;
            return View(rent);
        }
        [HttpPost]
        public ActionResult Edit(String id, Rent updatedRents)
        {
            Rent rent = AppContext.Rents.SingleOrDefault(x => x.PropertyNo == id);
            rent.PropertyNo = updatedRents.PropertyNo;
            rent.Street = updatedRents.Street;
            rent.Ptype = updatedRents.Ptype;
            rent.Rooms = updatedRents.Rooms;
            rent.OwnerNoRef = updatedRents.OwnerNoRef;
            rent.StaffNoRef = updatedRents.StaffNoRef;
            rent.BranchNoRef = updatedRents.BranchNoRef;
            AppContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(String id)
        {
            Rent rent = AppContext.Rents.SingleOrDefault(x => x.PropertyNo == id);
            return View(rent);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteRent(String id)
        {
            Rent rent = AppContext.Rents.SingleOrDefault(x => x.PropertyNo == id);
            AppContext.Rents.Remove(rent);
            AppContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult RentCity()
        {
            var AllCity = AppContext.Rents.ToList();
            int x = 0;
            int y = 0;

            foreach (Rent rent in AllCity)
            {
                x = x + 1;
            }
            string[] pos = new string[x];

            foreach (Rent rent in AllCity)
            {
                pos[y] = rent.City;
                y = y + 1;
            }
            var Array = pos.Distinct().ToArray();
            ViewBag.RentCity = Array;

            return View();
        }
        public ActionResult Rent_City(string c)
        {
            List<Rent> rent = AppContext.Rents.Where(x=>x.City == c).ToList();
            return View(rent);
        }
    }


}
