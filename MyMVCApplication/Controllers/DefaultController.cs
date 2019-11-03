using MyMVCApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMVCApplication.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        //Default Action Method and default View page with action name is called under View/Controller
        public ActionResult Index()
        {
            return View();
        }
        //action Method and different view page passing View Name
        public ActionResult Index1()
        {
            return View("TestView");
        }
        //
        public ActionResult AboutUs()
        {
            return View("AboutUS");
        }

        //Hello method returns a string
        public string Hello(int? EmpID)
        {
            return "Hello Employee ID: " + EmpID + "  Emp Name:" + Request.QueryString["EmpName"]+ "  Salary = " + Request.QueryString["salary"];
            //return "Hello World";
        }

        //call the view page of a different controller
        public ViewResult employee()
        {
            return View("~/Views/Employee/GetEmployee.cshtml");
        }

        //partial view
        public ActionResult Getdata()
        {
            List<EmployeeModel> dbobj = new List<EmployeeModel>();

            EmployeeModel db = new EmployeeModel();
            db.EmpID = 1001;
            db.EmpName = "Naveen";
            db.Salary = 25000;

            EmployeeModel db1 = new EmployeeModel();
            db1.EmpID = 1002;
            db1.EmpName = "Nikhil";
            db1.Salary = 20000;

            EmployeeModel db2 = new EmployeeModel();
            db2.EmpID = 1003;
            db2.EmpName = "Venkat";
            db2.Salary = 45000;

            dbobj.Add(db);
            dbobj.Add(db1);
            dbobj.Add(db2);

            ViewBag.EmpInfo = dbobj;

            return View();
        }

        public ViewResult Jerry()
        {
            return View();
        }

        public RedirectResult RedirectURL()
        {
            //return Redirect("https://www.yahoo.com"); 
            return Redirect("~/Default/AboutUS");
        }

        public RedirectToRouteResult route()
        {
            return RedirectToAction("Jerry","Default");
        }

        public RedirectToRouteResult route1()
        {
            return RedirectToRoute("Default1");
        }

    }
}