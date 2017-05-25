using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp_ver8_DB
{
    class DB_input
    {
        public void AddUser(String name, String facNum, String grade,
            String gender, String faculty, String semester7, String semester8, String status) // define difference between String and string
        // String course, String semester, String specialty, String status)
        {
            using (UserDataContext context = new UserDataContext(UserDataContext.DBConnectionString))
            {
                User_Details info = new User_Details();
                info.user_name = name;
                //     info.password = password;
                info.faknum = facNum;
                info.grade = grade;
                info.gender = gender;
                info.semester7 = semester7;
                info.semester8 = semester8;
                info.faculty = faculty;
                info.status = status;
                context.Users.InsertOnSubmit(info);
                context.SubmitChanges();
            }
        }

    }

    class DB_loginInput
    {
        public void AddLoginUser(String username, String password)
        {
            using (LoginInfoContext context2 = new LoginInfoContext(LoginInfoContext.DBConnectionString))
            {
                Login info2 = new Login();
                info2.login_username = username;
                info2.loginpassword = password;
                context2.Teachers.InsertOnSubmit(info2);
                context2.SubmitChanges();
            }
        }


    }
}
