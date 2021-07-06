using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserAccount.Models.Entities;
using UserAccount.Interfaces;

namespace UserAccount.Models.DAO
{
    public class UserAccountDAO
    {
        Model1 db;
        public UserAccountDAO()
        {
            db = new Model1();
        }

        public user Login(UserLogin userLogin)
        {
            user u = new user();
            u = db.users.Where(x => x.userName == userLogin.userName && x.password == userLogin.password).FirstOrDefault();
            return u;
        }

        public user Register(Interfaces.UserAccount userAccount)
        {
            try
            {
                user u = new user();
                u = db.users.Where(x => x.userName == userAccount.userName).FirstOrDefault();
                if (u != null)
                {
                    return null;
                }
                user newUser = new user();
                newUser.id = userAccount.id;
                newUser.userName = userAccount.userName;
                newUser.password = userAccount.password;
                newUser.phone = userAccount.phone;
                newUser.idRole = userAccount.idRole;
                newUser.country = userAccount.country;
                newUser.name = userAccount.name;
                db.users.Add(newUser);
                db.SaveChanges();
                return newUser;
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public user GetUser(int userId)
        {
            return db.users.Where(x => x.id == userId).FirstOrDefault();
        }

        public List<user> GetList(int page, int limit)
        {
            return db.users.OrderBy(x => x.id).Skip((page - 1)*limit).Take(limit).ToList();
        }

        public List<user> GetListSearch(int page, int limit, string search)
        {
            List<Entities.user> list = new List<Entities.user>();
            list = db.users.Where(x => x.name.Contains(search)).OrderBy(x => x.id).Skip((page - 1) * limit).Take(limit).ToList();
            return list;
        }

        public user UpdateUserAccount(user u)
        {
            user u1 = null;
            try
            {
                u1 = db.users.Where(x => x.id == u.id).SingleOrDefault();
                if(u1 == null)
                {
                    return null;
                }
                if(u.userName != null && u.name != "")
                {
                    u1.userName = u.userName;
                }
                if(u.password != null && u.password != "")
                {
                    u1.password = u.password;

                }
                if(u.phone != null && u.phone != "")
                {
                    u1.phone = u.phone;
                }
                if(u.idRole != null && u.idRole != "")
                {
                    u1.idRole = u.idRole;
                }
                if(u.country != null && u.country != "")
                {
                    u1.country = u.country;
                }
                if(u.name != null && u.name != "")
                {
                    u1.name = u.name;
                }
                db.SaveChanges();
                return u1;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public user DeleteUserAccount(int id)
        {
            try
            {
                user u = db.users.Find(id);
                db.users.Remove(u);
                db.SaveChanges();
                return u;
            }
            catch(Exception e)
            {
                return null;
            }
        }
    }
}