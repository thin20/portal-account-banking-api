using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserAccount.Models;

namespace UserAccount.Models.DAO
{
    public class UserAccountDAO
    {
        Entities.Model1 db = null;
        public UserAccountDAO()
        {
            db = new Entities.Model1();
        }

        
    }
}