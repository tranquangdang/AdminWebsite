namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblAdmin")]
    public partial class tblAdmin
    {
        [Key]
        public int AdminID { get; set; }

        [Required]
        [StringLength(255)]
        public string AdminName { get; set; }

        [Required]
        [StringLength(255)]
        public string AdminUser { get; set; }

        [Required]
        [StringLength(32)]
        public string AdminPass { get; set; }

        public byte AdminLevel { get; set; }
    }
}
