using projecta.BL;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projecta.DL
{
    public class EvaluationDL
    {
        private static string connectionString = "server=127.0.0.1;user id=root;password=abdullah125;database=projecta";

        public DataTable GetEvaluation()
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM evaluation";
                MySqlDataAdapter da = new MySqlDataAdapter(query, con);
                DataTable dataTable = new DataTable();
                da.Fill(dataTable); 
                return dataTable;
            }
        }
    }
}
