using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using UserAccount.Models.DAO;
using UserAccount.Common;
using System.Web.Http.Cors;

namespace UserAccount.Controllers
{
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
    public class UserAccountController : ApiController
    {
        [HttpGet]
        public BaseResponse<Models.Entities.user> Login(string userName, string password)
        {
            Interfaces.UserLogin userLogin = new Interfaces.UserLogin();
            userLogin.userName = userName;
            userLogin.password = password;
            Models.Entities.user u = new Models.Entities.user();
            u = new UserAccountDAO().Login(userLogin);
            if(u == null)
            {
                return new BaseResponse<Models.Entities.user>(StatusResponse.Fail, "Login failure", null, 0);  
            }
            List<Models.Entities.user> u1 = new List<Models.Entities.user>();
            u1.Add(u);
            return new BaseResponse<Models.Entities.user>(StatusResponse.Success, "Login successfully", u1, 0);
        }

        [HttpPost]
        public BaseResponse<Models.Entities.user> Register(string userName, string password, string phone, string idRole, string country, string name)
        {
            Interfaces.UserAccount userAccount = new Interfaces.UserAccount();
            userAccount.userName = userName;
            userAccount.password = password;
            userAccount.phone = phone;
            userAccount.idRole = idRole;
            userAccount.country = country;
            userAccount.name = name;
            Models.Entities.user u = new Models.Entities.user();
            u = new UserAccountDAO().Register(userAccount);
            if (u == null)
            {
                return new BaseResponse<Models.Entities.user>(StatusResponse.Fail, "Register failure", null, 0);
            }
            return new BaseResponse<Models.Entities.user>(StatusResponse.Success, "Login Success", null, 0);
        }

        [HttpGet]
        public BaseResponse<Models.Entities.user> getUser(int userId)
        {
            Models.Entities.user u = new UserAccountDAO().GetUser(userId);
            List<Models.Entities.user> u1 = new List<Models.Entities.user>();
            u1.Add(u);
            return new BaseResponse<Models.Entities.user>(StatusResponse.Success, "Get User Success", u1, 0);
        }

        [HttpGet]
        public BaseResponse<Models.Entities.user> GetList(int page, int limit)
        {
            List <Models.Entities.user> list = new UserAccountDAO().GetList(page, limit);
            int count = new UserAccountDAO().getNumberOfUserAccount();
            int n = (int)Math.Ceiling(1.0 * count / limit);           
            return new BaseResponse<Models.Entities.user>(StatusResponse.Success, "Get List User Success", list, n);
        }

        [HttpGet]
        public BaseResponse<Models.Entities.user> GetListSearch(int page, int limit, string search)
        {
            List<Models.Entities.user> list = new UserAccountDAO().GetListSearch(page, limit, search);
            int count = new UserAccountDAO().getNumberOfUserAccountSearch(search);
            int n = (int)Math.Ceiling(1.0 * count / limit);
            return new BaseResponse<Models.Entities.user>(StatusResponse.Success, "Get List User Search Success", list, n);
        }

        [HttpPut]
        public BaseResponse<Models.Entities.user> UpdateUserAccount(int id, string userName = "", string password = "", string phone = "", string idRole = "", string country = "", string name = "")
        {
            Models.Entities.user u1 = new Models.Entities.user();
            Models.Entities.user u = new UserAccountDAO().GetUser(id);
            if(u == null)
            {
                return null;
            }
            // Phan quyen ...
            u.userName = userName;
            u.password = password;
            u.phone = phone;
            u.idRole = idRole;
            u.country = country;
            u.name = name;
            u1 = new UserAccountDAO().UpdateUserAccount(u);
            
            return new BaseResponse<Models.Entities.user>(StatusResponse.Success, "Update UserAccount Success", null, 0);
        }

        [HttpDelete]
        public BaseResponse<Models.Entities.user> DeleteUserAccount(int id)
        {
            // Phan quyen
            Models.Entities.user u = new UserAccountDAO().DeleteUserAccount(id);
            return new BaseResponse<Models.Entities.user>(StatusResponse.Success, "Delete UserAccount Success", null, 0);
        }
    }
}
