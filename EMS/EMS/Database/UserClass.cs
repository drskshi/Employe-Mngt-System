using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace EMS.Database
{
    public class UserClass
    {
        SqlConnection conn = new SqlConnection(ConnectionClass.connectionString);
        public bool manageUsers(int UserID, String UserName, String password, int Mode)
        {
            try
            {
                String sql = "";
                if(Mode == 1)
                {
                    sql = @"insert into UserTable (UserName,password)
                            values(@UserName,@password)";
                }
                if(Mode == 2)
                {
                    sql = @"update UserTable set UserName=@UserName, password=@password
                            where UserID=@UserID";
                }
                if(Mode == 3)
                {
                    sql = @"Delete from UserTable where UserID=@UserID";
                }
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@password", password);
                conn.Open();
                int Result = cmd.ExecuteNonQuery();
                conn.Close();
                if(Result> 0)
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
        public DataTable getUsers()
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
        public bool login(String UserName, String password)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("Select * from UserTable Where UserName=@UserName and password=@password",conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@UserName",UserName);
                cmd.Parameters.AddWithValue("@password", password);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                conn.Close();
                if (dt.Rows.Count > 0)
                    return true;
                else
                    return false ;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { conn.Close(); }
        }

    }
}
