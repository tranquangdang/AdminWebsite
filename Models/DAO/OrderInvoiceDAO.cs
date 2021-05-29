using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class OrderInvoiceDAO
    {
        private WebDbContext db;

        public OrderInvoiceDAO()
        {
            db = new WebDbContext();
        }

        public List<tblOrderInvoice> ListAll()
        {
            return db.tblOrderInvoices.OrderByDescending(s => s.OrderDate).ToList();
        }

        public tblOrderInvoice Find(int OrderID)
        {
            return db.tblOrderInvoices.Find(OrderID);
        }

        public bool Delete(int OrderID)
        {
            try
            {
                var OrderInvoice = Find(OrderID);
                db.tblOrderInvoices.Remove(OrderInvoice);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool UpdateStatus(int OrderID, string Action)
        {
            try
            {
                int OrderStatus;
                var OrderInvoice = Find(OrderID);
                switch (Action)
                {
                    case "Confirm": 
                        OrderStatus = 1;
                        break;
                    case "Prepare":
                        OrderStatus = 2;
                        break;
                    case "Ship":
                        OrderStatus = 3;
                        break;
                    default:
                        OrderStatus = 0;
                        break;
                }
                OrderInvoice.OrderStatus = (byte) OrderStatus;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int SaleMoney()
        {
            return (int) db.tblOrderInvoices.Where(s => s.OrderStatus >= 3).Sum(s => s.OrderTotalMoney);
        }

        public int TotalOrders()
        {
            return db.tblOrderInvoices.Where(s => s.OrderStatus >= 3).Count();
        }

        public int UnprocessedOrders()
        {
            return db.tblOrderInvoices.Where(s => s.OrderStatus < 3).Count();
        }

        public int UnconfirmedOrders()
        {
            return db.tblOrderInvoices.Where(s => s.OrderStatus == 0).Count();
        }

        public int UnpreparedOrders()
        {
            return db.tblOrderInvoices.Where(s => s.OrderStatus == 1).Count();
        }

        public int UnshippedOrders()
        {
            return db.tblOrderInvoices.Where(s => s.OrderStatus == 2).Count();
        }

        public string Revenue()
        {
            decimal? t, l;
            string js = "<script>";
            js += " $(document).ready(function() {";
            js += " function gd(year, day, month)";
            js += " {";
            js += " return new Date(year, month - 1, day).getTime();";
            js += " }";
            js += " graphArea2 = Morris.Area({";
            js += " element: 'hero-area',";
            js += " padding: 10,";
            js += " behaveLikeLine: true,";
            js += " gridEnabled: false,";
            js += " gridLineColor: '#dddddd',";
            js += " axes: true,";
            js += " resize: true,";
            js += " smooth: true,";
            js += " pointSize: 0,";
            js += " lineWidth: 0,";
            js += " fillOpacity: 0.85,";
            js += " data:[";
            for (int i = 1; i <= DateTime.Today.Day; i++)
            {
                t = db.tblOrderInvoices.Where(s => s.OrderDate.Day <= i &&
                                            s.OrderDate.Month == DateTime.Today.Month &&
                                            s.OrderStatus >= 3).Sum(s => (decimal?) s.OrderTotalMoney).GetValueOrDefault(0);
                l = db.tblOrderInvoices.Where(s => s.OrderDate.Day <= i &&
                                             s.OrderDate.Month == DateTime.Today.Month - 1 &&
                                             s.OrderStatus >= 3).Sum(s => (decimal?) s.OrderTotalMoney).GetValueOrDefault(0);  
                js += "{period: '" + DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + i + "', thismonth: " + t + ", lastmonth: " + l + "}, ";
            }
            js += " ]";
            js += " ,";
            js += " lineColors:['#eb6f6f','#926383'],";
            js += " xkey: 'period',";
            js += " redraw: true,";
            js += " ykeys:['thismonth', 'lastmonth'],";
            js += " labels:['Tháng này', 'Tháng trước'],";
            js += " pointSize: 2,";
            js += " hideHover: 'auto',";
            js += " resize: true";
            js += " });";
            js += " });";
            js += " </script>";
            return js;
        }
    }
}
