using AdminWebShop.Areas.Admin.Models;
using Models.DAO;
using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminWebShop.Areas.Admin.Controllers
{
    public class OrderInvoiceController : BaseController
    {
        // GET: Admin/OrderInvoice
        public ActionResult Index(int page = 1, int pagesize = 10)
        {
            Notification();
            var model = new OrderInvoiceDAO().ListAll();
            return View(model.ToPagedList(page, pagesize));
        }

        /*[HttpPost]
        public ActionResult Index(string keyword, int page = 1, int pagesize = 10)
        {
            var model = new OrderInvoiceDAO().ListWhereAll(keyword, page, pagesize);
            ViewBag.SearchString = keyword;
            return View(model.ToPagedList(page, pagesize));
        }*/

        [HttpDelete]
        public ActionResult Delete(int OrderID)
        {
            var model = new OrderInvoiceDAO();
            model.Delete(OrderID);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult UpdateStatus(int OrderID, string Action)
        {
            new OrderInvoiceDAO().UpdateStatus(OrderID,Action);
            return RedirectToAction("Index");
        }
    }
}