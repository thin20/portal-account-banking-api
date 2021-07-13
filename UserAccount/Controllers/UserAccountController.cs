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
                return new BaseResponse<Models.Entities.user>(StatusResponse.Fail, "Login failure", null, 0, 0);  
            }
            List<Models.Entities.user> u1 = new List<Models.Entities.user>();
            u1.Add(u);
            return new BaseResponse<Models.Entities.user>(StatusResponse.Success, "Login successfully", u1, 0, 1);
        }

        [HttpPost]
        public BaseResponse<Models.Entities.user> Register(string userName, string password, string phone, string idRole, string country, string name)
        {
            Interfaces.UserAccount userAccount = new Interfaces.UserAccount();
            userAccount.userName = userName;
            userAccount.password = password;
            userAccount.phone = phone;
            userAccount.idRole = "normal";
            userAccount.country = country;
            userAccount.name = name;
            Models.Entities.user u = new Models.Entities.user();
            u = new UserAccountDAO().Register(userAccount);
            if (u == null)
            {
                return new BaseResponse<Models.Entities.user>(StatusResponse.Fail, "Register failure", null, 0, 0);
            }
            return new BaseResponse<Models.Entities.user>(StatusResponse.Success, "Login Success", null, 0, 1);
        }

        [HttpGet]
        public BaseResponse<Models.Entities.user> getUser(int userId)
        {
            Models.Entities.user u = new UserAccountDAO().GetUser(userId);
            List<Models.Entities.user> u1 = new List<Models.Entities.user>();
            u1.Add(u);
            return new BaseResponse<Models.Entities.user>(StatusResponse.Success, "Get User Success", u1, 0, 1);
        }

        [HttpGet]
        public BaseResponse<Models.Entities.user> GetAllUserAccount()
        {
            List<Models.Entities.user> list = new UserAccountDAO().GetAll();
            int count = new UserAccountDAO().getNumberOfUserAccount();
            return new BaseResponse<Models.Entities.user>(StatusResponse.Success, "Get List User Success", list, 0, count);
        }

        [HttpGet]
        public BaseResponse<Models.Entities.user> GetList(int page, int limit)
        {
            List <Models.Entities.user> list = new UserAccountDAO().GetList(page, limit);
            int count = new UserAccountDAO().getNumberOfUserAccount();
            int n = (int)Math.Ceiling(1.0 * count / limit);           
            return new BaseResponse<Models.Entities.user>(StatusResponse.Success, "Get List User Success", list, n, count);
        }

        [HttpGet]
        public BaseResponse<Models.Entities.user> GetListSearch(int page, int limit, string search)
        {
            List<Models.Entities.user> list = new UserAccountDAO().GetListSearch(page, limit, search);
            int count = new UserAccountDAO().getNumberOfUserAccountSearch(search);
            int n = (int)Math.Ceiling(1.0 * count / limit);
            return new BaseResponse<Models.Entities.user>(StatusResponse.Success, "Get List User Search Success", list, n, count);
        }

        [HttpPut]
        public BaseResponse<Models.Entities.user> UpdateUserAccount(int id, string userName = "", string password = "", string phone = "", string idRole = "", string country = "", string name = "")
        {
            Models.Entities.user u = new UserAccountDAO().GetUser(id);
            if(u == null)
            {
                return null;
            }
            // Phan quyen ...
            int idCurrentUser = -1;
            if (Request.Headers.GetValues("iduser") != null && Request.Headers.Contains("iduser"))
            {
                idCurrentUser = Int32.Parse(Request.Headers.GetValues("iduser").FirstOrDefault().ToString());
            }
            List<string> result = new List<string>();
            if (idCurrentUser == -1)
            {
                return new BaseResponse<Models.Entities.user>(StatusResponse.Fail, "You are not logged in yet", null, 0, 0);
            }
            Models.Entities.user u1 = new UserAccountDAO().GetUser(idCurrentUser);
            if (String.Equals(u.idRole.Trim(), "normal"))
            {
                return new BaseResponse<Models.Entities.user>(StatusResponse.Fail, "Forbidden ", null, 0, 0);
            }
            u1.userName = userName;
            u1.password = password;
            u1.phone = phone;
            u1.idRole = idRole;
            u1.country = country;
            u1.name = name;
            Models.Entities.user u2 = new UserAccountDAO().UpdateUserAccount(u1);
            if(u2 == null)
            {
                return new BaseResponse<Models.Entities.user>(StatusResponse.Fail, "Username already exist!", null, 0, 0);
            }
            return new BaseResponse<Models.Entities.user>(StatusResponse.Success, "Update UserAccount Success", null, 0, 1);
        }

        [HttpDelete]
        public BaseResponse<Models.Entities.user> DeleteUserAccount(int id)
        {
            int idCurrentUser = -1;
            // Phan quyen
            if(Request.Headers.GetValues("iduser") != null && Request.Headers.Contains("iduser"))
            {
                idCurrentUser = Int32.Parse(Request.Headers.GetValues("iduser").FirstOrDefault().ToString());
            }
            if(idCurrentUser == id)
            {
                return new BaseResponse<Models.Entities.user>(StatusResponse.Fail, "You can't remove yourself!", null, 0, 0);
            }
            if(idCurrentUser == -1)
            {
                return new BaseResponse<Models.Entities.user>(StatusResponse.Fail, "You are not logged in yet", null, 0, 0);
            }
            Models.Entities.user u = new UserAccountDAO().GetUser(idCurrentUser);
            if(String.Equals(u.idRole.Trim(), "normal"))
            {
                return new BaseResponse<Models.Entities.user>(StatusResponse.Fail, "Forbidden ", null, 0, 0);
            }
            new UserAccountDAO().DeleteUserAccount(id);
            return new BaseResponse<Models.Entities.user>(StatusResponse.Success, "Delete Successful!", null, 0, 1);
        }
        [HttpPost]
        public BaseResponse<Models.Entities.user> CreateUserAccount(string userName, string password, string phone, string idRole, string country, string name)
        {
            int idCurrentUser = -1;
            // Phan quyen
            if (Request.Headers.GetValues("iduser") != null && Request.Headers.Contains("iduser"))
            {
                idCurrentUser = Int32.Parse(Request.Headers.GetValues("iduser").FirstOrDefault().ToString());
            }
            List<string> result = new List<string>();
            if (idCurrentUser == -1)
            {
                return new BaseResponse<Models.Entities.user>(StatusResponse.Fail, "You are not logged in yet", null, 0, 0);
            }
            Models.Entities.user u = new UserAccountDAO().GetUser(idCurrentUser);
            if (String.Equals(u.idRole.Trim(), "normal"))
            {
                return new BaseResponse<Models.Entities.user>(StatusResponse.Fail, "Forbidden ", null, 0, 0);
            }
            Interfaces.UserAccount userAccount = new Interfaces.UserAccount();
            userAccount.userName = userName;
            userAccount.password = password;
            userAccount.phone = phone;
            userAccount.idRole = idRole;
            userAccount.country = country;
            userAccount.name = name;
            Models.Entities.user u1 = new Models.Entities.user();
            u1 = new UserAccountDAO().Register(userAccount);
            if (u1 == null)
            {
                return new BaseResponse<Models.Entities.user>(StatusResponse.Fail, "Create failure", null, 0, 0);
            }
            return new BaseResponse<Models.Entities.user>(StatusResponse.Success, "Create Success!", null, 0, 1);
        }
    }
}
