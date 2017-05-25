using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace MyApp_ver8_DB
{
        public class UserDataContext : DataContext
        {
            public static string DBConnectionString = @"isostore:/Logininfo.sdf";
            public UserDataContext(string connectionString)
                : base(connectionString)
            { }
            public Table<User_Details> Users
            {
                get
                {
                    return this.GetTable<User_Details>();
                }
            }
        }
        [Table]

        public class User_Details
        {
            [Column(IsDbGenerated = true, IsPrimaryKey = true)]
            public int ID
            {
                get;
                set;
            }

            [Column]
            public string user_name
            {
                get;
                set;
            }
            [Column]
            public string password
            {
                get;
                set;
            }

            [Column]
            public string faknum
            {
                get;
                set;
            }

            [Column]
            public string gender
            {
                get;
                set;
            }

            [Column]
            public string grade
            {
                get;
                set;
            }
            [Column]
            public string course
            {
                get;
                set;
            }

            [Column]
            public string semester7
            {
                get;
                set;
            }
            [Column]
            public string semester8
            {
                get;
                set;
            }

            [Column]
            public string faculty
            {
                get;
                set;
            }

            [Column]
            public string specialty
            {
                get;
                set;
            }
            [Column]
            public string status
            {
                get;
                set;
            }
        }

    }
