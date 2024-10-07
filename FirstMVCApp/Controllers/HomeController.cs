using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace FirstMVCApp.Controllers
{
    public class HomeController : Controller
    {
        FirstMVCAppDBContext _context = new FirstMVCAppDBContext();
        public ActionResult Index()
        {
            var listofData = _context.tblStudents.ToList();
            return View(listofData);
        }
        [HttpGet]
        public  ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tblStudent model)
        {
            _context.tblStudents.Add(model);
            _context.SaveChanges();
            ViewBag.message = "Data Insert Successfully";
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id) 
        {
            var data = _context.tblStudents.Where(x => x.StudentID == id).FirstOrDefault();
            return View(data);  
        }
        [HttpPost]
        public ActionResult Edit(tblStudent Model)
        {
            var data = _context.tblStudents.Where(x => x.StudentID == Model.StudentID).FirstOrDefault();
            if (data != null)
            {
                data.StudentCity = Model.StudentCity;
                data.StudentName = Model.StudentName;
                data.StudentFees = Model.StudentFees;
                _context.SaveChanges();
            }
            return RedirectToAction("index");
        }
        public ActionResult Details(int id)
        {
                    var data = _context.tblStudents.Where(x => x.StudentID  == id).FirstOrDefault(x => x.StudentID == id);
            return View(data);
        }

        public ActionResult Delete(int id) 
        {
            var data = _context.tblStudents.Where(x => x.StudentID == id).FirstOrDefault();
            _context.tblStudents.Remove(data);
            _context.SaveChanges();
            ViewBag.Message = "Record Delete Successfully";
            return RedirectToAction("index");
        }
     }
}