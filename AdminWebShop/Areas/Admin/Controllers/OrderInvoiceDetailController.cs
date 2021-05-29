using Models.DAO;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminWebShop.Areas.Admin.Controllers
{
    public class OrderInvoiceDetailController : Controller
    {
        // GET: Admin/OrderInvoiceDetail
        [HttpGet]
        public ActionResult Index(int OrderID)
        {
            var model = new OrderInvoiceDetailDAO().ListAll(OrderID);
            return View(model);
        }
    }
}