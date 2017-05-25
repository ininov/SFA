using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp_ver8_DB
{

    class Users
    {
        public string id {get; set;}
        public string name { get; set; }
        public string facnum { get; set; }
        public string grade { get; set; }
        public string gender { get; set; }
        public string semester7 { get; set; }
        public string semester8 { get; set; }
        public string faculty { get; set; }
        public string status { get; set; }
        

    }
    class FetchDBinfo
    {
        public IList<User_Details> GetAllUsers()
        {
            IList<User_Details> list = null;
            using (UserDataContext context = new UserDataContext (UserDataContext.DBConnectionString))
            {
                IQueryable<User_Details> query = from c in context.Users select c;
                list = query.ToList();
            }
            return list;
        }

            public List<Users> getUsers()
        {
            IList<User_Details> usersfromilist = this.GetAllUsers ();
            List<Users> allmsgs = new List<Users>();
                foreach (User_Details m in usersfromilist)
                {
                Users n = new Users();
                n.id = m.ID.ToString();
                n.name = m.user_name;
                n.facnum = m.faknum;
                n.grade = m.grade;
                n.gender = m.gender;
                n.semester7 = m.semester7;
                n.semester8 = m.semester8;
                n.faculty = m.faculty;
                n.status = m.status;
                allmsgs.Add(n);
            }
            return allmsgs;
            
    }
        


    }
}
