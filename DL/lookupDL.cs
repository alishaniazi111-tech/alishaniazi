using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projecta.DL
{
   

    public class LookupDL
    {
        private static string connectionString = "server=127.0.0.1;user id=root;password=abdullah125;database=projecta";
        
        public DataTable GetAllLookups()
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT * FROM Lookup";

                using (MySqlDataAdapter da = new MySqlDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

       
        public DataTable GetLookupByCategory(string category)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                string query = "SELECT Id, Value FROM Lookup WHERE Category=@cat";

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@cat", category);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }
        
        public int GetLookupId(string category, string value)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();

                string query = "SELECT Id FROM Lookup WHERE Category=@cat AND Value=@val";
                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("@cat", category);
                cmd.Parameters.AddWithValue("@val", value);

                return (int)cmd.ExecuteScalar();
            }
        }
    }
}
