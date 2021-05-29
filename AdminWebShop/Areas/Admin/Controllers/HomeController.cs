using AdminWebShop.Areas.Admin.Models;
using AdminWebShop.Common;
using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminWebShop.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            var session = (LoginModel) Session[Constants.USER_SESSION];
            if (session == null) 
                return RedirectToAction("Index", "Login");

            Notification();
            var customer = new CustomerDAO();
            var orderInvoice = new OrderInvoiceDAO();
            var orderInvoiceDetail = new OrderInvoiceDetailDAO();
            ViewBag.SaleMoney = orderInvoice.SaleMoney();
            ViewBag.NumberOfCustomers = customer.NumberOfCustomers();
            ViewBag.TotalOrders = orderInvoice.TotalOrders();
            ViewBag.SoldProduct = orderInvoiceDetail.SoldProduct();
            ViewBag.Revenue = orderInvoice.Revenue();
            return View();
        }

        public ActionResult Logout()
        {
            Session[Constants.USER_SESSION] = null;
            return RedirectToAction("Index", "Login");
        }
    }
}