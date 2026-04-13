using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projecta.DL
{
    public class GroupDL
    {
        private static string connectionString = "server=127.0.0.1;user id=root;password=abdullah125;database=projecta";
        public int CreateGroup()
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                string query = "INSERT INTO [Group](CreatedOn) OUTPUT INSERTED.Id VALUES(GETDATE())";
                MySqlCommand cmd = new MySqlCommand(query, con);

                return (int)cmd.ExecuteScalar();
            }
        }
        public bool AddStudentToGroup(int groupId, int studentId, int status, DateTime assignmentDate)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
               
                string query = "INSERT INTO GroupStudent (GroupId, StudentId, Status, AssignmentDate) " +
                               "VALUES (@gid, @sid, @status, @date)";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@gid", groupId);
                cmd.Parameters.AddWithValue("@sid", studentId);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@date", assignmentDate);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public DataTable GetGroups()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM `Group`"; 
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}