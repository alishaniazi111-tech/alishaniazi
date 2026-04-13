using MySql.Data.MySqlClient;
using projecta.BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace projecta.DL
{
    public class ProjectDL
    {
        private static string connectionString = "server=127.0.0.1;user id=root;password=abdullah125;database=projecta";
        public void AddProject(projectBL p)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                string query = "INSERT INTO Project (Id, Title, Description) VALUES (@id, @title, @desc)";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", p.Id);
                    cmd.Parameters.AddWithValue("@title", p.title);
                    cmd.Parameters.AddWithValue("@desc", p.description);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable GetProjects()
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT Id, Title, Description FROM Project";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }
}
