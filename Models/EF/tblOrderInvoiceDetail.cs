namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblOrderInvoiceDetail")]
    public partial class tblOrderInvoiceDetail
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductID { get; set; }

        public int QtyOrdered { get; set; }

        public int Amount { get; set; }

        public virtual tblOrderInvoice tblOrderInvoice { get; set; }

        public virtual tblProduct tblProduct { get; set; }
    }
}
