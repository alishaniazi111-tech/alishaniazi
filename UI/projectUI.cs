using projecta.BL;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace projecta.UI
{
    public partial class projectUI : Form
    {
        public projectUI()
        {
            InitializeComponent();
            SetupCleanUI();
        }

        private void SetupCleanUI()
        {
            // 1. ReportViewer ko hide kar dein agar wo headers show kar raha hai
            if (reportViewer1 != null)
            {
                reportViewer1.Visible = false;
            }

            // 2. FlowLayout ko hide karein taake extra labels nazar na ayain
            if (flowLayoutPanel1 != null)
            {
                flowLayoutPanel1.Visible = false;
            }

            // 3. Buttons aur Textboxes ko front par le aao
            button1.BringToFront(); // Add Project
            button2.BringToFront(); // Get Project

            // Grid (Table) ko sahi position par rakhein
            if (dataGridView1 != null)
            {
                dataGridView1.Visible = true;
                dataGridView1.BringToFront();
            }
        }
        private void LoadDataIntoGrid()
        {
            try
            {
                projectBL bl = new projectBL();
                DataTable data = bl.GetAllProjects();

                if (data != null)
                {
                    dataGridView1.DataSource = null; // Purana data clear karein
                    dataGridView1.DataSource = data;  // Naya data bind karein
                    dataGridView1.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        // "Get Project" button click par call karein
        private void button2_Click(object sender, EventArgs e)
        {
            LoadDataIntoGrid();
        }

        // "Add Project" ke foran baad bhi call karein taake naya entry nazar aaye
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                // 1. Textboxes se data lein (Apne textbox names check kar lein)
                string title = txtTitle.Text;
                string desc = txtDescription.Text;

                if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(desc))
                {
                    MessageBox.Show("Please fill all fields!");
                    return;
                }

                // 2. BL ka function call karein
                projectBL bl = new projectBL();
                bl.AddProject(title, desc);

                MessageBox.Show("Project Added Successfully!");

                // 3. Fields saaf karein
                txtTitle.Clear();
                txtDescription.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }


            LoadDataIntoGrid();
        }

      

        // Get Project button ke liye
       
        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            projectadvisorUI UI = new projectadvisorUI();
            UI.Show(); // Yahan 'projectadvisorUI' ki jagah 'UI' likhein
        }
    }
}