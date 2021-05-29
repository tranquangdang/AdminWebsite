using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class ProductDAO
    {
        private WebDbContext db;

        public ProductDAO()
        {
            db = new WebDbContext();
        }

        public List<tblProduct> ListAll()
        {
            return db.tblProducts.ToList();
        }

        public tblProduct Find(int ProductID)
        {
            return db.tblProducts.Find(ProductID);
        }

        public string Insert(tblProduct productEntity)
        {
            var product = Find(productEntity.ProductID);
            if (product == null)
            {
                db.tblProducts.Add(productEntity);
            }
            else
            {
                product.CategoryNo = productEntity.CategoryNo;
                product.Brand = productEntity.Brand;
                product.ProductName = productEntity.ProductName;
                product.ProductImg = productEntity.ProductImg;
                product.Intro = productEntity.Intro;
                product.UnitPrice = productEntity.UnitPrice;
                product.PerDiscount = productEntity.PerDiscount;
                product.QtyOnHand = productEntity.QtyOnHand;
            }    
            db.SaveChanges();
            return productEntity.ProductID.ToString();
        }

        public bool Delete(int ProductID)
        {
            try
            {
                var product = Find(ProductID);
                db.tblProducts.Remove(product);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public List<tblProductCategory> getCate()
        {
            return db.tblProductCategories.ToList();
        }

        public IEnumerable<tblProduct> ListWhereAll(string keyword, int page, int pagesize)
        {
            IEnumerable<tblProduct> model = db.tblProducts;
            if (!string.IsNullOrEmpty(keyword))
            {
                model = model.Where(s => s.ProductName.Contains(keyword));
            }
            return model.OrderBy(s => s.ProductName).ToPagedList(page, pagesize);
        }
    }
}
