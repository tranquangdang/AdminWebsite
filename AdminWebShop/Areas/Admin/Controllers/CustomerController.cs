using Models.DAO;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminWebShop.Areas.Admin.Controllers
{
    public class CustomerController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index(int page = 1, int pagesize = 10)
        {
            Notification();
            var customer = new CustomerDAO();
            var model = customer.ListAll();
            return View(model.ToPagedList(page, pagesize));
        }
    }
}