namespace UserAccount.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string userName { get; set; }

        [Required]
        [StringLength(50)]
        public string password { get; set; }

        [StringLength(10)]
        public string phone { get; set; }

        [Required]
        [StringLength(10)]
        public string idRole { get; set; }

        [StringLength(50)]
        public string country { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }
    }
}
