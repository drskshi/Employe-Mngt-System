using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace EMS.Database
{
    public class EmployeeClass
    {
        SqlConnection conn=new SqlConnection (ConnectionClass.connectionString);
        public bool manageEmployee(int EmployeeID,
            String EmployeeName,
            String Address,
            String Contact,
            String gender,
            String email,
            DateTime DateOfBirth,
            String Department,
            String Designation, int Mode)
        {
            try
            {
                String sql = "";
                if (Mode == 1)
                {
                    sql = @"insert into EmployeeTable
                          (EmployeeName, Address, Contact, gender,
                           Email, DateOfBirth, Department, Designation)
                           values(@EmployeeName,@Address, @Contact, @gender,
                           @Email,
                           @DateOfBirth,@Department,@Designation)";

                }
                else if (Mode == 2)
                {
                    sql = @"Update EmployeeTable set EmployeeName=@EmployeeName, Address=@Address,
                            Contact=@Contact,gender=@gender, Email=@Email,DateOfBirth=@DateOfBirth,DepartMent=@Department
                            Designation@Designation where EmployeeID=@EmployeeID";
                }
                else if(Mode == 3)
                {
                    sql = "Delete From EmployeeTable where EmployeeID=@EmployeeID";

                }
                SqlCommand cmd = new SqlCommand (sql, conn);   
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                cmd.Parameters.AddWithValue("@EmployeeName", EmployeeName);
                cmd.Parameters.AddWithValue("@Address", Address);
                cmd.Parameters.AddWithValue("@Contact", Contact);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                cmd.Parameters.AddWithValue("@Department", Department);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                conn.Close();
                if (result > 0)
                    return true;
                else
                    return false;





            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { conn.Close(); }
        }
        public DataTable getEmplopyees()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("Select * From UserTable", conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader(); 
                dt.Load(dr);
                conn.Close();
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { conn.Close(); }
        }
        public DataTable getEmployeeByName(String EmployeeName)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("Select * From EmployeeTable where EmployeeName like '%'+ @EmployeeName + '%'", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@EmployeeName",EmployeeName);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                conn.Close();
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { conn.Close(); }
        }
    }
}
