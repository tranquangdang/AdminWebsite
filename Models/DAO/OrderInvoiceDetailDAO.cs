using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class OrderInvoiceDetailDAO
    {
        private WebDbContext db;

        public OrderInvoiceDetailDAO()
        {
            db = new WebDbContext();
        }

        public List<tblOrderInvoiceDetail> ListAll(int OrderID)
        {
            return db.tblOrderInvoiceDetails.Where(s => s.OrderID.Equals(OrderID)).ToList();
        }

        public int SoldProduct()
        {
            return db.tblOrderInvoiceDetails.GroupBy(s => s.ProductID).Count();
        }
    }
}
