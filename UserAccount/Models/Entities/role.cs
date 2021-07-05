namespace UserAccount.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("role")]
    public partial class role
    {
        [StringLength(10)]
        public string id { get; set; }

        [StringLength(50)]
        public string description { get; set; }
    }
}
