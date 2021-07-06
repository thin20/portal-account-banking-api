using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UserAccount.Models.DAO;

namespace UserAccount.Controllers
{
    public class RoleController : ApiController
    {
        [HttpGet]
        public List<Models.Entities.role> GetListRole()
        {
            return new RoleDAO().GetRole();
        }
    }
}
