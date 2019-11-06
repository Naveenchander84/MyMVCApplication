using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyADO.NETMVC.Models
{
    public class EmployeeModel
    {
        [Key]   
        public int EmpID { get; set; }

        public String EmpName { get; set; }

        public int EmpSalary { get; set; }
    }
}
