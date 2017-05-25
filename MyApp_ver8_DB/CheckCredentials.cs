using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace MyApp_ver8_DB
{
    class UsersLogin
    {
        public string id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
    }


    class CheckCredentials
    {
        public IList<Login> GetAllUsers()
        {
            IList<Login> list = null;
            using (LoginInfoContext context = new LoginInfoContext(LoginInfoContext.DBConnectionString))
            {
                IQueryable<Login> query = from c in context.Teachers select c;
                list = query.ToList();
            }
            return list;
        }
        public List<UsersLogin> getUsers()
        {
            IList<Login> usersfromilist = this.GetAllUsers();
            List<UsersLogin> myList = new List<UsersLogin>();

            foreach (Login m in usersfromilist)
            {
                UsersLogin addDetail = new UsersLogin();
                addDetail.id = m.ID.ToString();
                addDetail.name = m.login_username;
                addDetail.password = m.loginpassword;
                myList.Add(addDetail);
            }
            return myList;
        }

        public bool checkListPassword (String password)
        {
            bool c = false;
            foreach (UsersLogin b in getUsers())
            {
                if (password.Equals(b.name))
                {
                    c = true;
                }
                else
                {
                    c = false;
                }
            }
            return c;
        }

        public bool checkListUsername(String username)
        {
            bool c = false;
            foreach (UsersLogin b in getUsers())
            {
                if (username.Equals(b.name))
                {
                    c = true;
                }
                else
                {
                    c = false;
                }
            }
            return c;
        }
    }
}
