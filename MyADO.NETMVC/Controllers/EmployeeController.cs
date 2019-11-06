using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyADO.NETMVC.Models;

namespace MyADO.NETMVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        EmployeeInfo obj = new EmployeeInfo();

        public ActionResult Index()
        {
            return View(obj.GetEmployeeInfo());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeModel emp)
        {
            int i = obj.SaveEmpInfo(emp);
            if (i > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(i);
            }
        }
    }
}