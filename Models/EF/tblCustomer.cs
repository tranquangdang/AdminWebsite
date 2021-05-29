namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblCustomer")]
    public partial class tblCustomer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblCustomer()
        {
            tblOrderInvoices = new HashSet<tblOrderInvoice>();
        }

        [Key]
        public int CustID { get; set; }

        [Required]
        [StringLength(255)]
        public string CustName { get; set; }

        [Required]
        [StringLength(255)]
        public string CustAddress { get; set; }

        [Required]
        [StringLength(10)]
        public string TelNo { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [StringLength(32)]
        public string Pass { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblOrderInvoice> tblOrderInvoices { get; set; }
    }
}
