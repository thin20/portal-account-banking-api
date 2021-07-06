using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserAccount.Models.DAO
{
    public class RoleDAO
    {
        Entities.Model1 db = null;
        public RoleDAO()
        {
            db = new Entities.Model1();
        }
        public List<Models.Entities.role> GetRole()
        {
            return db.roles.ToList();
        }
    }
}