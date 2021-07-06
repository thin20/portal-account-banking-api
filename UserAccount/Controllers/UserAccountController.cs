using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using UserAccount.Models.DAO;

namespace UserAccount.Controllers
{
    public class UserAccountController : ApiController
    {
        [HttpGet]
        public Models.Entities.user Login(string userName, string password)
        {
            Interfaces.UserLogin userLogin = new Interfaces.UserLogin();
            userLogin.userName = userName;
            userLogin.password = password;
            Models.Entities.user u = new Models.Entities.user();
            u = new UserAccountDAO().Login(userLogin);
            return u;
        }

        [HttpPost]
        public Models.Entities.user Register(string userName, string password, string phone, string idRole, string country, string name)
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
            return u;
        }

        [HttpGet]
        public Models.Entities.user getUser(int userId)
        {
            return new UserAccountDAO().GetUser(userId);
        }

        [HttpGet]
        public List<Models.Entities.user> GetList(int page, int limit)
        {
            List <Models.Entities.user> list = new UserAccountDAO().GetList(page, limit);
            return list;
        }

        [HttpGet]
        public List<Models.Entities.user> GetListSearch(int page, int limit, string search)
        {
            List<Models.Entities.user> list = new UserAccountDAO().GetListSearch(page, limit, search);
            return list;
        }

        [HttpPut]
        public Models.Entities.user UpdateUserAccount(int id, string userName = "", string password = "", string phone = "", string idRole = "", string country = "", string name = "")
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
            
            return u1;
        }

        [HttpDelete]
        public Models.Entities.user DeleteUserAccount(int id)
        {
            // Phan quyen
            Models.Entities.user u = new UserAccountDAO().DeleteUserAccount(id);
            return u;
        }
    }
}
