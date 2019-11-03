using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyMVCApplication.Models;

namespace MyMVCApplication.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ViewResult GetEmployee()
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

            return View(dbobj);
        }
    }
}