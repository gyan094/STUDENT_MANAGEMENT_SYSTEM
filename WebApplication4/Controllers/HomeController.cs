using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        StudentEntities db = new StudentEntities();
        public ActionResult Index()
        {
            var data = db.Students.ToList();
            return View(data);
        }
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(Student s)
        {
            if(ModelState.IsValid == true)
            {
                db.Students.Add(s);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["InsertMassage"] = "<script>alert('Inserted !!')</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["InsertMassage"] = "<script>alert('Not Inserted !!')</script>";

                }
            }  
            return View();
        }
        public ActionResult Edit(int Id)
        {
            var row=db.Students.Where(model => model.Id == Id).FirstOrDefault();
            return View(row);
        }
        [HttpPost]
        public ActionResult Edit(Student s)
        {
            if(ModelState.IsValid == true)
            {
                db.Entry(s).State=EntityState.Modified;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["UpdateMassage"] = "<script>alert('Updated !!')</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["UpdateMassage"] = "<script>alert('Not Updated !!')</script>";

                }
            }
            return View();
        }
        public ActionResult Delete(int Id)
        {
            var DeletedRow = db.Students.Where(model => model.Id == Id).FirstOrDefault();

            return View(DeletedRow);
        }
        [HttpPost]
        public ActionResult Delete(Student s)
        {
            db.Entry(s).State = EntityState.Deleted;
            int a = db.SaveChanges();
            if (a > 0)
            {
                TempData["DeleteMassage"] = "<script>alert('Deleted !!')</script>";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["DeleteMassage"] = "<script>alert('Not Deleted !!')</script>";

            }
            return View();
        }
        public ActionResult Details(int Id)
        {
            var DetailsRow = db.Students.Where(model => model.Id == Id).FirstOrDefault();

            return View(DetailsRow);
        }

    }
}