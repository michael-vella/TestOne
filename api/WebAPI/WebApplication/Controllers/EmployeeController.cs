using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class EmployeeController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"
            SELECT UserId, EmployeeName, EmployeeRole, Motto, Hobbies, Hometown, PersonalBlog, PhotoFileName
            FROM dbo.Employee
            ";

            // variable to store the data coming from the database table
            DataTable table = new DataTable();
            using(var con= new SqlConnection(ConfigurationManager.
                ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using(var cmd = new SqlCommand(query,con))
                using(var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        public string Post(Employee emp)
        {
            try
            {
                string query = @"
                    INSERT into dbo.Employee VALUES
                    (
                    '" + emp.EmployeeName + @"'
                    ,'" + emp.EmployeeRole + @"'
                    ,'" + emp.Motto + @"'
                    ,'" + emp.Hobbies + @"'
                    ,'" + emp.Hometown + @"'
                    ,'" + emp.PersonalBlog + @"'
                    ,'" + emp.PhotoFileName + @"'
                    )";

                // variable to store the data coming from the database table
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Added Successfully!";
            } 
            catch (Exception)
            {
                return "Failed to add!";
            }
        }

        public string Put(Employee emp)
        {
            try
            {
                string query = @"
                    UPDATE dbo.Employee set
                    EmployeeName='" + emp.EmployeeName + @"'
                    ,EmployeeRole='" + emp.EmployeeRole + @"'
                    ,Motto='" + emp.Motto + @"'
                    ,Hobbies='" + emp.Hobbies + @"'
                    ,Hometown='" + emp.Hometown + @"'
                    ,PersonalBlog='" + emp.PersonalBlog + @"'
                    ,PhotoFileName='" + emp.PhotoFileName + @"'
                    WHERE UserId= " + emp.UserId + @"
                    ";

                // variable to store the data coming from the database table
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Updated Successfully!";
            }
            catch (Exception)
            {
                return "Failed to update!";
            }
        }

        public string Delete(int id)
        {
            try
            {
                string query = @"
                    DELETE FROM dbo.Employee
                    WHERE UserId= " + id + @"
                    ";

                // variable to store the data coming from the database table
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Deleted Successfully!";
            }
            catch (Exception)
            {
                return "Failed to delete!";
            }
        }

        // custom route for this method
        [Route("api/Employee/SaveFile")]

        public string SaveFile()
        {
            try
            {
                // httpRequest to capture the current request
                var httpRequest = HttpContext.Current.Request;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = HttpContext.Current.Server.MapPath("~/Photos/" + filename);

                postedFile.SaveAs(physicalPath);

                return filename;
            } catch (Exception)
            {
                return "anonymous.png";
            }
        }
    }
}
