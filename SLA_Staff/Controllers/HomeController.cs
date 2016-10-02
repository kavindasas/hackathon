using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SLA_Staff.Controllers
{
    public class HomeController : Controller
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-BQ663OC;Initial Catalog=StaffDB;Integrated Security=SSPI");

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult login()
        {
            try
            {
                conn.Open();
                string uname = Request.Form["name"];
                string password = Request.Form["password"];

                SqlCommand cmd = new SqlCommand("select * from user where username='" + uname + "' and password= '" + password + "'", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    Session["user"] = uname;
                    return RedirectToAction("Home");
                }
                else
                {
                    return RedirectToAction("Index");
                }
                conn.Close();
                conn.Dispose();


                
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public ActionResult signup()
        {
            try
            {
                conn.Open();
                string username = Request.Form["uname"];
                string fname = Request.Form["fname"];
                string lname = Request.Form["lname"];
                string email = Request.Form["email"];
                string password = Request.Form["password"];

                SqlCommand cmd = new SqlCommand("insert into user(username,fname,lname,email,password) values('"+username+ "','" + fname + "','" + lname + "','" + email + "','" + password + "')", conn);
                cmd.ExecuteNonQuery();
               
                Session["user"] = username;
                return RedirectToAction("Home");
                conn.Close();
                conn.Dispose();



            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Home()
        {
            

            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}