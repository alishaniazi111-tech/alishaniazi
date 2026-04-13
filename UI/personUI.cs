using System;
using System.Data;
using System.Windows.Forms;
using projecta.BL;
using projecta.DL;

namespace projecta.UI
{
    public partial class personUI : Form
    {
        private int selectedId = 0; // Global variable for selection

        public personUI()
        {
            InitializeComponent();
            // Important: Make sure your DataGridView name is dgvPersons in Designer
            this.dgvPersons.CellClick += new DataGridViewCellEventHandler(this.dgvPersons_CellClick);
        }

        private void personUI_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadGender();
        }

        public void LoadData()
        {
            dgvPersons.DataSource = new PersonDL().GetPersons();
        }

        public void ClearFields()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtContact.Clear();
            txtEmail.Clear();
            dtpDateOfBirth.Value = DateTime.Now;
            if (cmbGender.Items.Count > 0) cmbGender.SelectedIndex = 0;
            selectedId = 0;
        }

        void LoadGender()
        {
            lookupBL bl = new lookupBL(0, "", "Gender");
            cmbGender.DataSource = bl.GetGender();
            cmbGender.DisplayMember = "Value";
            cmbGender.ValueMember = "Id";
        }

        // ADD BUTTON
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                PersonBL p = new PersonBL();
                p.FirstName = txtFirstName.Text;
                p.LastName = txtLastName.Text;
                p.Contact = txtContact.Text;
                p.Email = txtEmail.Text;
                p.DateOfBirth = dtpDateOfBirth.Value;
                p.Gender = (GenderType)Convert.ToInt32(cmbGender.SelectedValue);

                p.AddPerson();
                MessageBox.Show("Saved Successfully");
                LoadData();
                ClearFields();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        // DELETE BUTTON
        private void button2_Click(object sender, EventArgs e)
        {
            if (selectedId == 0) { MessageBox.Show("Please select a row first!"); return; }

            PersonBL p = new PersonBL();
            p.Id = selectedId;
            p.DeletePerson();

            MessageBox.Show("Deleted");
            LoadData();
            ClearFields();
        }

        // UPDATE BUTTON
        private void button3_Click(object sender, EventArgs e)
        {
            if (selectedId == 0) { MessageBox.Show("Please select a row first!"); return; }

            PersonBL p = new PersonBL();
            p.Id = selectedId;
            p.FirstName = txtFirstName.Text;
            p.LastName = txtLastName.Text;
            p.Contact = txtContact.Text;
            p.Email = txtEmail.Text;
            p.DateOfBirth = dtpDateOfBirth.Value;
            p.Gender = (GenderType)Convert.ToInt32(cmbGender.SelectedValue);

            p.UpdatePerson();
            MessageBox.Show("Updated");
            LoadData();
            ClearFields();
        }

        // New: Event to pick ID when you click a row
        private void dgvPersons_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Check ke click row par hi hua ho (header par nahi)
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvPersons.Rows[e.RowIndex];

                    // Hum names ki jagah column numbers use kar rahe hain
                    // 0=Id, 1=FirstName, 2=LastName, 3=Contact, 4=Email, 5=DateOfBirth, 6=Gender
                    selectedId = Convert.ToInt32(row.Cells[0].Value);

                    txtFirstName.Text = row.Cells[1].Value?.ToString();
                    txtLastName.Text = row.Cells[2].Value?.ToString();
                    txtContact.Text = row.Cells[3].Value?.ToString();
                    txtEmail.Text = row.Cells[4].Value?.ToString();

                    // Date handling
                    if (row.Cells[5].Value != DBNull.Value)
                    {
                        dtpDateOfBirth.Value = Convert.ToDateTime(row.Cells[5].Value);
                    }

                    // Gender handling (Column 6)
                    cmbGender.SelectedValue = row.Cells[6].Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Selection Error: " + ex.Message);
            }
        }
    }
}