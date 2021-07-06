using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UserAccount.Models.DAO;
using UserAccount.Common;

namespace UserAccount.Controllers
{
    public class RoleController : ApiController
    {
        [HttpGet]
        public BaseResponse<Models.Entities.role> GetListRole()
        {
            return new BaseResponse<Models.Entities.role>(StatusResponse.Success, "Get List Role Success", new RoleDAO().GetRole(), 0);
        }
    }
}
