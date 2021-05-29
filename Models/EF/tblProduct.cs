namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblProduct")]
    public partial class tblProduct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblProduct()
        {
            tblOrderInvoiceDetails = new HashSet<tblOrderInvoiceDetail>();
        }

        [Key]
        public int ProductID { get; set; }

        [Required]
        [StringLength(5)]
        public string CategoryNo { get; set; }

        [Required]
        [StringLength(255)]
        public string Brand { get; set; }

        [Required]
        [StringLength(1000)]
        public string ProductName { get; set; }

        public string ProductImg { get; set; }

        [Required]
        public string Intro { get; set; }

        public int UnitPrice { get; set; }

        public double PerDiscount { get; set; }

        public int QtyOnHand { get; set; }

        public DateTime? TimeCreate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblOrderInvoiceDetail> tblOrderInvoiceDetails { get; set; }

        public virtual tblProductCategory tblProductCategory { get; set; }
    }
}
