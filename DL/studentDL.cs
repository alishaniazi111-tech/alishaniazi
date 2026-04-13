using MySql.Data.MySqlClient;
using projecta.BL;
using projecta.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projecta.DL
{
    public class StudentDL
    {
        private static string connectionString = "server=127.0.0.1;user id=root;password=abdullah125;database=projecta";

        public void AddStudent(string fName, string lName, string contact, string email, string regNo, int gender)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                MySqlTransaction trans = con.BeginTransaction(); 

                try
                {
                   
                    string personQuery = "INSERT INTO Person (FirstName, LastName, Contact, Email, Gender) VALUES (@f, @l, @c, @e, @g); SELECT LAST_INSERT_ID();";
                    MySqlCommand cmd1 = new MySqlCommand(personQuery, con, trans);
                    cmd1.Parameters.AddWithValue("@f", fName);
                    cmd1.Parameters.AddWithValue("@l", lName);
                    cmd1.Parameters.AddWithValue("@c", contact);
                    cmd1.Parameters.AddWithValue("@e", email);
                    cmd1.Parameters.AddWithValue("@g", gender);

                    int newId = Convert.ToInt32(cmd1.ExecuteScalar()); 
                    
                    string studentQuery = "INSERT INTO Student (Id, RegistrationNumber) VALUES (@id, @reg)";
                    MySqlCommand cmd2 = new MySqlCommand(studentQuery, con, trans);
                    cmd2.Parameters.AddWithValue("@id", newId);
                    cmd2.Parameters.AddWithValue("@reg", regNo);
                    cmd2.ExecuteNonQuery();

                    trans.Commit(); 
                }
                catch
                {
                    trans.Rollback(); 
                    throw;
                }
            }
        }



        public void UpdateStudent(int id, string fName, string lName, string contact, string email, string regNo, int gender)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                MySqlTransaction trans = con.BeginTransaction();

                try
                {
                    // 1. Person table update karein
                    string q1 = @"UPDATE Person SET FirstName=@f, LastName=@l, Contact=@c, 
                         Email=@e, Gender=@g WHERE Id=@id";
                    MySqlCommand cmd1 = new MySqlCommand(q1, con, trans);
                    cmd1.Parameters.AddWithValue("@f", fName);
                    cmd1.Parameters.AddWithValue("@l", lName);
                    cmd1.Parameters.AddWithValue("@c", contact);
                    cmd1.Parameters.AddWithValue("@e", email);
                    cmd1.Parameters.AddWithValue("@g", gender);
                    cmd1.Parameters.AddWithValue("@id", id);
                    cmd1.Parameters.AddWithValue("@id", id);
                    cmd1.ExecuteNonQuery();

                    // 2. Student table update karein
                    string q2 = "UPDATE Student SET RegistrationNumber=@reg WHERE Id=@id";
                    MySqlCommand cmd2 = new MySqlCommand(q2, con, trans);
                    cmd2.Parameters.AddWithValue("@reg", regNo);
                    cmd2.Parameters.AddWithValue("@id", id);
                    cmd2.ExecuteNonQuery();

                    trans.Commit();
                }
                catch
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        public void DeleteStudent(int id)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                MySqlTransaction trans = con.BeginTransaction();

                try
                {
                    // Pehle Student table se hatayein
                    string q1 = "DELETE FROM Student WHERE Id = @id";
                    new MySqlCommand(q1, con, trans).Parameters.AddWithValue("@id", id);

                    // Phir Person table se hatayein
                    string q2 = "DELETE FROM Person WHERE Id = @id";
                    new MySqlCommand(q2, con, trans).Parameters.AddWithValue("@id", id);

                    trans.Commit();
                }
                catch
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        public DataTable SearchStudent(string value)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                // JOIN query jo Registration Number ya Name dono par search kare
                string query = @"SELECT S.Id, S.RegistrationNumber, P.FirstName, P.LastName, 
                                P.Contact, P.Email, L.Value as Gender
                         FROM Student S
                         JOIN Person P ON S.Id = P.Id
                         JOIN Lookup L ON P.Gender = L.Id
                         WHERE S.RegistrationNumber LIKE @val 
                         OR P.FirstName LIKE @val 
                         OR P.LastName LIKE @val";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@val", "%" + value + "%");
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }
            public DataTable GetFullStudentData()
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();
                    // JOIN query jo Person aur Student dono ka data lay gi
                    string query = @"SELECT S.Id, S.RegistrationNumber, P.FirstName, P.LastName, 
                                    P.Contact, P.Email, L.Value as Gender
                             FROM Student S
                             JOIN Person P ON S.Id = P.Id
                             JOIN Lookup L ON P.Gender = L.Id";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, con);
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message);
            }
            return dt;
        }
    }




    }



