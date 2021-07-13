using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UserAccount.Models.DAO;
using UserAccount.Common;
using System.Web.Http.Cors;

namespace UserAccount.Controllers
{
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
    public class RoleController : ApiController
    {
        [HttpGet]
        public BaseResponse<Models.Entities.role> GetListRole()
        {
            return new BaseResponse<Models.Entities.role>(StatusResponse.Success, "Get List Role Success", new RoleDAO().GetRole(), 0, 2);
        }
    }
}
