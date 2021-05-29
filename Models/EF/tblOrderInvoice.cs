namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblOrderInvoice")]
    public partial class tblOrderInvoice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblOrderInvoice()
        {
            tblOrderInvoiceDetails = new HashSet<tblOrderInvoiceDetail>();
        }

        [Key]
        public int OrderID { get; set; }

        public DateTime OrderDate { get; set; }

        [Required]
        [StringLength(1000)]
        public string OrderAddress { get; set; }

        [Column(TypeName = "money")]
        public decimal OrderTotalMoney { get; set; }

        [Required]
        [StringLength(10)]
        public string TelNo { get; set; }

        public int CustNo { get; set; }

        public byte OrderStatus { get; set; }

        public virtual tblCustomer tblCustomer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblOrderInvoiceDetail> tblOrderInvoiceDetails { get; set; }
    }
}
