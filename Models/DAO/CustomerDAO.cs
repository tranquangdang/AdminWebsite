using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class CustomerDAO
    {
        private WebDbContext db;

        public CustomerDAO()
        {
            db = new WebDbContext();
        }

        public List<tblCustomer> ListAll()
        {
            return db.tblCustomers.ToList();
        }

        public int NumberOfCustomers()
        {
            return db.tblCustomers.Count();
        }
    }
}
