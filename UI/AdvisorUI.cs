using projecta.BL;
using projecta.DL;
using System;
using System.Data;
using System.Windows.Forms;

namespace projecta.UI
{
    public partial class AdvisorUI : Form
    {
        public AdvisorUI()
        {
            InitializeComponent();
           
            reportViewer1.Visible = false;
            reportViewer1.ShowToolBar = false;
            reportViewer1.ShowParameterPrompts = false;
        }

        private void AdvisorUI_Load(object sender, EventArgs e)
        {
            LoadDesignations();
            RefreshGrid();
        }

        private void LoadDesignations()
        {
            try
            {
                AdvisorDL dl = new AdvisorDL();
                DataTable dt = dl.GetDesignations();
                cmbDesignation.DataSource = dt;
                cmbDesignation.DisplayMember = "Value";
                cmbDesignation.ValueMember = "Id";
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void RefreshGrid()
        {
            try
            {
                AdvisorDL dl = new AdvisorDL();
                dataGridView1.DataSource = dl.GetAdvisors();
            }
            catch (Exception ex) { MessageBox.Show("Grid Error: " + ex.Message); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
             
                if (string.IsNullOrWhiteSpace(txtId.Text) || string.IsNullOrWhiteSpace(txtSalary.Text))
                {
                    MessageBox.Show("Please fill all fields!");
                    return;
                }

               
                if (!int.TryParse(txtId.Text.Trim(), out int id))
                {
                    MessageBox.Show("ID mein sirf number likhein!");
                    return;
                }

                string cleanSalary = txtSalary.Text.Replace(",", "").Trim();
                if (!decimal.TryParse(cleanSalary, out decimal salary))
                {
                    MessageBox.Show("Salary format error!");
                    return;
                }

                int designationId = Convert.ToInt32(cmbDesignation.SelectedValue);

                
                advisorBL advisorObj = new advisorBL(id, designationId, salary);
                AdvisorDL dl = new AdvisorDL();
                dl.AddAdvisor(advisorObj);

                MessageBox.Show("Advisor Successfully Added!");
                RefreshGrid();
                ClearForm();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void ClearForm()
        {
            txtId.Clear();
            txtSalary.Clear();
            txtId.Focus();
        }
    }
}