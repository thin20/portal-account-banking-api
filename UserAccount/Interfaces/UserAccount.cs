using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UserAccount.Interfaces
{
    public class UserAccount
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public string idRole { get; set; }
        public string country { get; set; }
        public string name { get; set; }
    }
}