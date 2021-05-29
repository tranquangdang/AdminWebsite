using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Models.EF
{
    public partial class WebDbContext : DbContext
    {
        public WebDbContext()
            : base("name=DbContextWeb")
        {
        }

        public virtual DbSet<tblAdmin> tblAdmins { get; set; }
        public virtual DbSet<tblCustomer> tblCustomers { get; set; }
        public virtual DbSet<tblOrderInvoice> tblOrderInvoices { get; set; }
        public virtual DbSet<tblOrderInvoiceDetail> tblOrderInvoiceDetails { get; set; }
        public virtual DbSet<tblProduct> tblProducts { get; set; }
        public virtual DbSet<tblProductCategory> tblProductCategories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblAdmin>()
                .Property(e => e.AdminUser)
                .IsUnicode(false);

            modelBuilder.Entity<tblAdmin>()
                .Property(e => e.AdminPass)
                .IsUnicode(false);

            modelBuilder.Entity<tblCustomer>()
                .Property(e => e.TelNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tblCustomer>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<tblCustomer>()
                .Property(e => e.Pass)
                .IsUnicode(false);

            modelBuilder.Entity<tblCustomer>()
                .HasMany(e => e.tblOrderInvoices)
                .WithRequired(e => e.tblCustomer)
                .HasForeignKey(e => e.CustNo);

            modelBuilder.Entity<tblOrderInvoice>()
                .Property(e => e.OrderTotalMoney)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tblOrderInvoice>()
                .Property(e => e.TelNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tblProduct>()
                .Property(e => e.CategoryNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tblProduct>()
                .Property(e => e.ProductImg)
                .IsUnicode(false);

            modelBuilder.Entity<tblProductCategory>()
                .Property(e => e.CategoryID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tblProductCategory>()
                .HasMany(e => e.tblProducts)
                .WithRequired(e => e.tblProductCategory)
                .HasForeignKey(e => e.CategoryNo);
        }
    }
}
