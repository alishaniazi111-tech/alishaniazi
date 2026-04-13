using MySql.Data.MySqlClient;
using projecta.BL;
using System;
using System.Data;

namespace projecta.DL
{
    public class AdvisorDL
    {
        private static string connectionString = "server=127.0.0.1;user id=root;password=abdullah125;database=projecta";

        public void AddAdvisor(advisorBL a)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();
                    string query = "INSERT INTO Advisor (Id, Designation, Salary) VALUES (@id, @desig, @sal)";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", a.Id);
                        cmd.Parameters.AddWithValue("@desig", a.Designation);
                        cmd.Parameters.AddWithValue("@sal", a.Salary);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062) 
                    throw new Exception("Error: Is ID ka Advisor pehle se mojud hai. Nayi ID likhein.");
                else
                    throw new Exception("Database Error: " + ex.Message);
            }
        }

        public DataTable GetDesignations()
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT Id, Value FROM Lookup WHERE Category = 'DESIGNATION'";
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetAdvisors()
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT * FROM Advisor";
                using (MySqlDataAdapter da = new MySqlDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
    }
}