using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using projecta.BL;



    namespace projecta.DL
    {
        public class groupprojectDL
        {
            private static string connectionString = "server=localhost;database=projecta;user=root;password=yourpassword;";

            // Insert new group project
            public static bool AddGroupProject(groupprojectBL gp)
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO GroupProjects(ProjectId, GroupId, AssignmentDate) VALUES(@ProjectId, @GroupId, @AssignmentDate)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ProjectId", gp.ProjectId);
                    cmd.Parameters.AddWithValue("@GroupId", gp.GroupId);
                    cmd.Parameters.AddWithValue("@AssignmentDate", gp.AssignmentDate);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }

            // Retrieve all group projects
            public static List<groupprojectBL> GetAllGroupProjects()
            {
                List<groupprojectBL> projects = new List<groupprojectBL>();

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT ProjectId, GroupId, AssignmentDate FROM GroupProjects";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        groupprojectBL gp = new groupprojectBL(reader.GetInt32("ProjectId"), reader.GetInt32("GroupId"))
                        {
                            AssignmentDate = reader.GetDateTime("AssignmentDate")
                        };
                        projects.Add(gp);
                    }
                }
                return projects;
            }

            // Update group project
            public static bool UpdateGroupProject(groupprojectBL gp)
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE GroupProjects SET AssignmentDate=@AssignmentDate WHERE ProjectId=@ProjectId AND GroupId=@GroupId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@AssignmentDate", gp.AssignmentDate);
                    cmd.Parameters.AddWithValue("@ProjectId", gp.ProjectId);
                    cmd.Parameters.AddWithValue("@GroupId", gp.GroupId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }

           
            public static bool DeleteGroupProject(int projectId, int groupId)
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM GroupProjects WHERE ProjectId=@ProjectId AND GroupId=@GroupId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ProjectId", projectId);
                    cmd.Parameters.AddWithValue("@GroupId", groupId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
    }

