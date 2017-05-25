using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp_ver8_DB
{
    class UserStatus
    {
        public string id {  get; set;}
        public string facultyNumber { get; set;}
        public string status { get; set;}
        
    }
    class CheckStatus
    {
         public IList<User_Details> GetAllUsers()
        {
            IList<User_Details> list = null;
            using (UserDataContext context = new UserDataContext(UserDataContext.DBConnectionString))
            {
                IQueryable<User_Details> query = from c in context.Users select c;
                list = query.ToList();
            }
            return list;
        }
        public List<UserStatus> getUsers()
        {
            IList<User_Details> usersfromilist = this.GetAllUsers();
            List<UserStatus> myList = new List<UserStatus>();

            foreach (User_Details m in usersfromilist)
            {
                UserStatus addDetail = new UserStatus();
                addDetail.id = m.ID.ToString();
                addDetail.facultyNumber = m.faknum;
                addDetail.status = m.status;
                myList.Add(addDetail);
            }
            return myList;
        }
        public bool checkListFaknum(String facnum)
        {
            bool approve = false;
            
            foreach (UserStatus b in getUsers())
            {
                String status = "Approved";
                if (facnum.Equals(b.facultyNumber) && status.Equals(b.status))
                {                  
                       approve = true;
                       break;
                }
                else
                {
                       approve = false;
                       
                }

                        
                    }
                               
            
            return approve;
        }

        public bool checkExistListFaknum(String existfacnum)
        {
            bool exist = false;

            foreach (UserStatus b in getUsers())
            {
                if (existfacnum.Equals(b.facultyNumber))
                {
                    exist = true;
                    break;
                }

                else
                {
                    exist = false;
                    
                }
            }
            return exist;
        }

    }
}
