using MySql.Data.MySqlClient;
using projecta.BL;
using System;
using System.Data;

namespace projecta.DL
{
    public class PersonDL
    {
        private static string connectionString = "server=127.0.0.1;user id=root;password=abdullah125;database=projecta";

        public int AddPerson(PersonBL p)
        {
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                string query = @"INSERT INTO Person (FirstName, LastName, Contact, Email, DateOfBirth, Gender)
                                 VALUES (@FirstName, @LastName, @Contact, @Email, @DateOfBirth, @Gender);
                                 SELECT LAST_INSERT_ID();";

                using (var cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@FirstName", p.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", string.IsNullOrEmpty(p.LastName) ? (object)DBNull.Value : p.LastName);
                    cmd.Parameters.AddWithValue("@Contact", string.IsNullOrEmpty(p.Contact) ? (object)DBNull.Value : p.Contact);
                    cmd.Parameters.AddWithValue("@Email", p.Email);
                    cmd.Parameters.AddWithValue("@DateOfBirth", p.DateOfBirth);
                    cmd.Parameters.AddWithValue("@Gender", (int)p.Gender);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public DataTable GetPersons()
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM Person";
                MySqlDataAdapter da = new MySqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void UpdatePerson(PersonBL p)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
               
                string query = @"UPDATE Person 
                                 SET FirstName = @fname, 
                                     LastName = @lname, 
                                     Contact = @contact, 
                                     Email = @email, 
                                     Gender = @gender, 
                                     DateOfBirth = @dob
                                 WHERE Id = @id";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", p.Id);
                    cmd.Parameters.AddWithValue("@fname", p.FirstName);
                    cmd.Parameters.AddWithValue("@lname", p.LastName);
                    cmd.Parameters.AddWithValue("@contact", p.Contact);
                    cmd.Parameters.AddWithValue("@email", p.Email);
                    cmd.Parameters.AddWithValue("@dob", p.DateOfBirth);
                    cmd.Parameters.AddWithValue("@gender", (int)p.Gender);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeletePerson(int id)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                string query = "DELETE FROM Person WHERE Id=@id";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}