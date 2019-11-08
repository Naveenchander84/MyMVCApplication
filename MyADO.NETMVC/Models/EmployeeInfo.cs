using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MyADO.NETMVC.Models
{
    public class EmployeeInfo
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
        

        public List<EmployeeModel> GetEmployeeInfo()
        {
            SqlCommand cmd = new SqlCommand("usp_getEmployeeInfo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            List<EmployeeModel> empobj = new List<EmployeeModel>();
            foreach (DataRow dr in dt.Rows)
            {
                EmployeeModel emp = new EmployeeModel();
                emp.EmpID = Convert.ToInt32(dr[0]);
                emp.EmpName = Convert.ToString(dr[1]);
                emp.EmpSalary = Convert.ToInt32(dr[2]);

                empobj.Add(emp);

            }
            return empobj;
        }

        public int SaveEmpInfo(EmployeeModel obj)
        {

              SqlCommand cmd = new SqlCommand("usp_saveemployeeinfo", con);
              cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@EmpID", obj.EmpID);
            cmd.Parameters.AddWithValue("@EmpName", obj.EmpName);
            cmd.Parameters.AddWithValue("@EmpSalary", obj.EmpSalary);
            object ob = cmd.ExecuteNonQuery();
            int i = Convert.ToInt32(ob);
            return i;
        }
    }
}