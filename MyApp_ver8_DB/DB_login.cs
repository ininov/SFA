using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace MyApp_ver8_DB
{

    public class LoginInfoContext : DataContext
    {
        public static string DBConnectionString = @"isostore:/LoginDatabases.sdf";
        public LoginInfoContext (string connectionString)
            : base(connectionString)
        { }
        public Table<Login> Teachers
        {
            get
            {
                return this.GetTable<Login>();
            }
        }
    }
    [Table]

    public class Login
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        public int ID
        {
            get;
            set;
        }

        [Column]
        public string login_username
        {
            get;
            set;
        }
        [Column]
        public string loginpassword
        {
            get;
            set;
        }
    }
}
