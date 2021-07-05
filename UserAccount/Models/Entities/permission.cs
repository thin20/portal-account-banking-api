namespace UserAccount.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("permission")]
    public partial class permission
    {
        public int id { get; set; }

        [Required]
        [StringLength(10)]
        public string idRole { get; set; }

        [Column("permission")]
        [Required]
        [StringLength(10)]
        public string permission1 { get; set; }
    }
}
