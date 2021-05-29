using AdminWebShop.Areas.Admin.Models;
using AdminWebShop.Common;
using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AdminWebShop.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var session = (LoginModel)Session[Constants.USER_SESSION];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "Login", action = "Index", Areas = "Admin" }));
            }
            base.OnActionExecuted(filterContext);
        }

        protected void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            if(type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == "warning")
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if (type == "error")
            {
                TempData["AlertType"] = "alert-danger";
            }
        }

        public void Notification()
        {
            var orderInvoice = new OrderInvoiceDAO();
            ViewBag.UnprocessedOrders = orderInvoice.UnprocessedOrders();
            ViewBag.UnconfirmedOrders = orderInvoice.UnconfirmedOrders();
            ViewBag.UnpreparedOrders = orderInvoice.UnpreparedOrders();
            ViewBag.UnshippedOrders = orderInvoice.UnshippedOrders();
        }
    }
}