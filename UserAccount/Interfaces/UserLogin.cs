using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UserAccount.Interfaces
{
    public class UserLogin
    {
        [Required]
        public string userName { get; set; }
        [Required]
        public string password { get; set; }
    }
}