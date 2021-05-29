using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class AdminDAO
    {
        private WebDbContext db;

        public AdminDAO()
        {
            db = new WebDbContext();
        }

        public int login(string user, string pass)
        {
            var result = db.tblAdmins.SingleOrDefault(x => x.AdminUser.Contains(user) && x.AdminPass.Contains(pass));
            if (result == null)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
