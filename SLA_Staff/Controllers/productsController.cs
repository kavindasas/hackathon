using SLA_Staff.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SLA_Staff.Controllers
{
    public class productsController : Controller
    {
        //SqlConnection conn = new SqlConnection("Data Source=DESKTOP-LA58UBF;Initial Catalog=hackathon;Integrated Security=SSPI");

        //GET: products
        public ActionResult Index()
        {
            return View();
        }

        // GET: products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: products/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: products/Edit/5
        public ActionResult Edit(int id)
        {

            return View();
        }

        // POST: products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                string i="1";
                //conn.open();
                ProductEdit product = new ProductEdit();
                product.ID1 =Convert.ToInt32(Request.Form["txtid"]);
                product.Name1 = Request.Form["txtname"];
                product.Price = Convert.ToInt32(Request.Form["txtprice"]);
                product.Qty = Convert.ToInt32(Request.Form["txtqty"]);

                string sql = "update products set productId='"+product.ID1+"',name='"+product.Name1+"',qty='"+product.Qty+"',price='"+product.Price+"'";
                return RedirectToAction("EditProduct");

                //SqlCommand cmd = new SqlCommand(sql, conn);
                //cmd.ExecuteNonQuery();
                //conn.Close();
                //conn.Dispose();
            }
            catch
            {

                return View();
            }
        }

        // GET: products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
