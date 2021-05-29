using System.Web.Mvc;

namespace AdminWebShop.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Product_Create_default",
                "Admin/{controller}/{action}/{str}",
                new { controller = "Product", action = "Create", str = UrlParameter.Optional }
            );

            context.MapRoute(
                "OrderInvoice_Delete_default",
                "Admin/{controller}/{action}/{OrderID}",
                new { controller = "OrderInvoice", action = "Delete", OrderID = UrlParameter.Optional }
            );

            context.MapRoute(
                "Product_Delete_default",
                "Admin/{controller}/{action}/{ProductID}",
                new { controller = "Product", action = "Delete", ProductID = UrlParameter.Optional }
            );

            context.MapRoute(
                "Product_Index_default",
                "Admin/{controller}",
                new { controller = "Product", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}