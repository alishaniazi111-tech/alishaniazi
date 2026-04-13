using System;
using System.Data;
using System.Windows.Forms;
using projecta.DL; // Is se DL layer connect hogi

namespace projecta.UI
{
    public partial class lookupUI : Form
    {
        public lookupUI()
        {
            InitializeComponent();
        }

        private void lookupUI_Load(object sender, EventArgs e)
        {
            // Report viewer refresh (agar use kar rahi hain)
            if (this.reportViewer1 != null)
            {
                this.reportViewer1.RefreshReport();
            }

            // Data load karne wala function call karein
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                // Aapke DL mein function ka naam 'GetAllLookups' hai
                LookupDL dl = new LookupDL();
                DataTable dt = dl.GetAllLookups();

                // DataGridView ko data assign karein
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Abhi isay khali rehne dein
        }
    }
}