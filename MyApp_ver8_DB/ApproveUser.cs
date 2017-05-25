using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp_ver8_DB
{
    class ApproveUser
    {
        public void UpdateStatus (int id, String status)
        {
            using (UserDataContext context = new UserDataContext(UserDataContext.DBConnectionString))
            {
                IQueryable<User_Details> entityQuery = from c in context.Users where c.ID == id select c;
                User_Details entityToUpdate = entityQuery.FirstOrDefault();
                entityToUpdate.status = status;
                context.SubmitChanges();
            }
        }
    }
}
