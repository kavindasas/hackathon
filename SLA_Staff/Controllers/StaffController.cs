using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using System.Configuration;
using System.Data.SqlClient;
using SLA_Staff.Models;

namespace SLA_Staff.Controllers
{
    public class StaffController : Controller
    {
       SqlConnection conn = new SqlConnection("Data Source=DESKTOP-BQ663OC;Initial Catalog=StaffDB;Integrated Security=SSPI");
       
        SqlDataReader rdr = null;
        SqlDataReader rdrPromotions = null;
        SqlDataReader rdrTrainings = null;

        public ActionResult Index()
        {
            List<staffPerson> staffPersons = new List<staffPerson>();
            rdr = null;
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from staffTable", conn);
            rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    staffPerson staff = new staffPerson();

                    staff.Id = rdr.GetString(rdr.GetOrdinal("staffNo"));
                    staff.Name = rdr.GetString(rdr.GetOrdinal("name"));
                    staff.Pname1 = rdr.GetString(rdr.GetOrdinal("pName"));
                    staff.CostC = rdr.GetString(rdr.GetOrdinal("costCentre"));
                    staff.Designation = rdr.GetString(rdr.GetOrdinal("designation"));
                    staff.Grade = rdr.GetString(rdr.GetOrdinal("grade"));
                    staff.CompanyJoined = rdr.GetString(rdr.GetOrdinal("companyJoined"));
                    staff.DeptJoined = rdr.GetString(rdr.GetOrdinal("ITdeptJoined"));
                    staff.NoPay1 = rdr.GetString(rdr.GetOrdinal("NoPay"));
                    staff.Availability = rdr.GetString(rdr.GetOrdinal("availability"));


                    staffPersons.Add(staff);
                }
            }
            
            ViewData["staffDetails"] = staffPersons;

            conn.Close();
            conn.Dispose();
            return View();
        }






        // GET: Staff/Details/5
        public ActionResult Details(string id)
        {
           
            try
            {

                rdr = null;
                rdrPromotions = null;
                rdrTrainings = null;

                staffPerson staff = new staffPerson();
                List<staffPromo> staffPromotions = new List<staffPromo>();
                List<staffTraining> staffTrainings = new List<staffTraining>();

                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from staffTable where staffNo='" + id + "'", conn);
                rdr = cmd.ExecuteReader();
                //employee Details
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        staff.Id = rdr.GetString(rdr.GetOrdinal("staffNo"));
                        staff.Name = rdr.GetString(rdr.GetOrdinal("name"));
                        staff.Pname1 = rdr.GetString(rdr.GetOrdinal("pName"));
                        staff.CostC = rdr.GetString(rdr.GetOrdinal("costCentre"));
                        staff.Designation = rdr.GetString(rdr.GetOrdinal("designation"));
                        staff.Grade = rdr.GetString(rdr.GetOrdinal("grade"));
                        staff.CompanyJoined = rdr.GetString(rdr.GetOrdinal("companyJoined"));
                        staff.DeptJoined = rdr.GetString(rdr.GetOrdinal("ITdeptJoined"));
                        staff.NoPay1 = rdr.GetString(rdr.GetOrdinal("NoPay"));
                        staff.Availability = rdr.GetString(rdr.GetOrdinal("availability"));
                    }
                }
                conn.Close();



                //Employee Promotions
                conn.Open();
                SqlCommand cmdPromotions = new SqlCommand("select * from promotions where StaffNo='" + id + "'", conn);
                rdrPromotions = cmdPromotions.ExecuteReader();
                if (rdrPromotions.HasRows)
                {
                    while (rdrPromotions.Read())
                    {
                        staffPromo Promo = new staffPromo();
                        Promo.Id = rdrPromotions.GetString(rdrPromotions.GetOrdinal("StaffNo"));
                        Promo.Date = rdrPromotions.GetString(rdrPromotions.GetOrdinal("promotionDate"));
                        Promo.PromoFrom = rdrPromotions.GetString(rdrPromotions.GetOrdinal("promotionFrom"));
                        Promo.PromoTo = rdrPromotions.GetString(rdrPromotions.GetOrdinal("promotionTo"));

                        staffPromotions.Add(Promo);
                    }
                }
                conn.Close();


                //Employee Trainings
                conn.Open();
                SqlCommand cmdTrainings = new SqlCommand("select * from trainings where staffNo='" + id + "'", conn);
                rdrTrainings = cmdTrainings.ExecuteReader();
                if (rdrTrainings.HasRows)
                {
                    while (rdrTrainings.Read())
                    {
                        staffTraining train = new staffTraining();
                        train.Id = rdrTrainings.GetString(rdrTrainings.GetOrdinal("staffNo"));
                        train.TrainingDate = rdrTrainings.GetString(rdrTrainings.GetOrdinal("trainingStart"));
                        train.TrainigEnd = rdrTrainings.GetString(rdrTrainings.GetOrdinal("trainingEnd"));
                        train.Desc = rdrTrainings.GetString(rdrTrainings.GetOrdinal("description"));

                        staffTrainings.Add(train);
                    }
                }
                conn.Close();
                conn.Dispose();

                ViewData["staffPromotions"] = staffPromotions;
                ViewData["staffTrainings"] = staffTrainings;
                ViewData["staffDetails"] = staff;


                return View();
            }
            catch (Exception ex)
            {
                return View();
            }
           
            
        }


        //Staff Update
        [HttpPost]
        public ActionResult Update()
        {
            string i = "1";
            try
            {
                conn.Open();
                staffPerson newP = new staffPerson();
                    newP.Id = Request.Form["txtid"];
                    newP.Name = Request.Form["name"];
                    newP.Pname1 = Request.Form["pname"];
                    newP.CostC = Request.Form["cc"];
                    newP.Designation = Request.Form["des"];
                    newP.Grade = Request.Form["grade"];
                    newP.CompanyJoined = Request.Form["Jdate"];
                    newP.DeptJoined = Request.Form["ITdate"];
                    newP.NoPay1 = Request.Form["nopay"];
                    newP.Availability = Request.Form["ava"];

                string sql="Update staffTable set name='"+ newP.Name +"', pName='"+newP.Pname1+"', costCentre='"+newP.CostC+"', designation='"+newP.Designation+"',grade='"+newP.Grade+"',companyJoined='"+newP.CompanyJoined+"',ITdeptJoined='"+newP.DeptJoined +"',NoPay='"+newP.NoPay1+"', availability='"+newP.Availability+"'   where staffNo='"+newP.Id+"'        ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                conn.Dispose();


                return RedirectToAction("AddStaff");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }



        public ActionResult AddStaff()
        {
            return View();
        }

        // POST: Staff/Create
        [HttpPost]
        public ActionResult Create()
        {
            try
            {
                conn.Open();
                staffPerson newP = new staffPerson();
                    newP.Id = Request.Form["txtid"];
                    newP.Name = Request.Form["name"];
                    newP.Pname1 = Request.Form["pname"];
                    newP.CostC = Request.Form["cc"];
                    newP.Designation = Request.Form["des"];
                    newP.Grade = Request.Form["grade"];
                    newP.CompanyJoined = Request.Form["Jdate"];
                    newP.DeptJoined = Request.Form["ITdate"];
                    newP.NoPay1 = Request.Form["nopay"];
                    newP.Availability = Request.Form["ava"];

                SqlCommand cmd = new SqlCommand("insert into staffTable values('"+ newP.Id + "','" + newP.Name + "','" + newP.Pname1 + "','" + newP.CostC + "','" + newP.Designation + "','" + newP.Grade + "','" + newP.CompanyJoined + "','" + newP.DeptJoined + "','" + newP.NoPay1 + "','" + newP.Availability+ "')", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                conn.Dispose();


                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return RedirectToAction("AddStaff");
            }
        }


        public ActionResult AddPromotions(string staffID)
        {

            return View();
        }















    }
}
