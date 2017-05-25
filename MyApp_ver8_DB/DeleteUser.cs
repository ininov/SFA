using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp_ver8_DB
{
    class DeleteUser
    {
        public void DeleteSingleUser(String id) //delete user by ID
        {
            using (UserDataContext context = new UserDataContext(UserDataContext.DBConnectionString))
            {
                IQueryable<User_Details> entityQuery = from c in context.Users where c.ID.Equals(id) select c;
                User_Details entityToDelete = entityQuery.FirstOrDefault();
                context.Users.DeleteOnSubmit(entityToDelete);
                context.SubmitChanges();
            }
        }

        public void DeleteAllUsers() // delete all users
        {
            using (UserDataContext context = new UserDataContext(UserDataContext.DBConnectionString))
            {
                IQueryable<User_Details> entityQuery = from c in context.Users select c;
                IList<User_Details> entityToDelete = entityQuery.ToList();
                context.Users.DeleteAllOnSubmit(entityToDelete);
                context.SubmitChanges();
            }

        }
    }
}
