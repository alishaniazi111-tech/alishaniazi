using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projecta.DL
{
    using System.Data.SqlClient;

    public class DatabaseHelper
    {
       
        private static string connectionString = "server=127.0.0.1;user id=root;password=abdullah125;database=projecta";
        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
    