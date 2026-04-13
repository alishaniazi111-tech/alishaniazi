using projecta.BL;
using projecta.DL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projecta.UI
{
    public partial class studentUI : Form
    {
        private readonly EventHandler studentUI_Load;

        public studentUI()
        {
            InitializeComponent();
            // Safe place to wire events
            this.Load += studentUI_Load;
        }
        public void LoadGrid()
{
    try
    {
        // 1. Data Layer ka object banayein
        StudentDL dl = new StudentDL();
        
        // 2. Database se Join query wala data uthayein
        DataTable dt = dl.GetFullStudentData();
        
        // 3. DataGridView ko refresh karein
        dataGridView1.DataSource = null; // Reset binding
        dataGridView1.DataSource = dt;   // Bind fresh data
        
        // 4. (Optional) Id column ko hide kar dein kyunke user ko iski zaroorat nahi
        if (dataGridView1.Columns["Id"] != null)
        {
            dataGridView1.Columns["Id"].Visible = false;
        }
        
        // 5. Columns ki headings ko behtar banayein
        if (dataGridView1.Columns["RegistrationNumber"] != null)
            dataGridView1.Columns["RegistrationNumber"].HeaderText = "Reg. No";
            
    }
    catch (Exception ex)
    {
        MessageBox.Show("Grid load karne mein error: " + ex.Message);
    }
}
     

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // UI se saara data akatha karein
                string fName = txtFirstName.Text;
                string lName = txtLastName.Text;
                string contact = txtContact.Text;
                string email = txtEmail.Text;
               
                string regNo = txtRegNo.Text;
                int gender = Convert.ToInt32(cmbGender.SelectedValue);

                StudentDL dl = new StudentDL();
                dl.AddStudent(fName, lName, contact, email, regNo, gender);

                MessageBox.Show("Student and Person records created!");
                LoadGrid(); // Grid refresh karein
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void studentBLBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            StudentDL dl = new StudentDL();
            DataTable dt = dl.GetFullStudentData();

            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt; // Ye line data show kare gi
            }
            else
            {
                MessageBox.Show("No data found in database!");
            }
        
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
