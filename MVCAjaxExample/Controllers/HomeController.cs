using MVCAjaxExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAjaxExample.Controllers
{
    public class HomeController : Controller
    {
        private TestDBEntities _context = new TestDBEntities();
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult List()
        {
            return Json(_context.Students.ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(Student user)
        {
            _context.Students.Add(user);
            _context.SaveChanges();
            return Json(JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int ID)
        {
            return Json(_context.Students.FirstOrDefault(x => x.Id == ID), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(Student user)
        {
            var data = _context.Students.FirstOrDefault(x => x.Id == user.Id);
            if (data != null)
            {
                data.Name = user.Name;
                data.State = user.State;
                data.Country = user.Country;
                data.Age = user.Age;
                _context.SaveChanges();
            }
            return Json(JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int ID)
        {
            var data = _context.Students.FirstOrDefault(x => x.Id == ID);
            _context.Students.Remove(data);
            _context.SaveChanges();
            return Json(JsonRequestBehavior.AllowGet);
        }
    }
}