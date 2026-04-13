using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace projecta.DL
{
    public class groupevaluationDL
    {

        private static string connectionString = "server=127.0.0.1;user id=root;password=abdullah125;database=projecta";
        public void AddEvaluation(int groupId, int evalId, int marks)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                string query = "INSERT INTO GroupEvaluation VALUES (@gid,@eid,@marks,@date)";
                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("@gid", groupId);
                cmd.Parameters.AddWithValue("@eid", evalId);
                cmd.Parameters.AddWithValue("@marks", marks);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
 