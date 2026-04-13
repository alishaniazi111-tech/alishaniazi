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
    public partial class groupUI : Form
    {
        public groupUI()
        {
            InitializeComponent();
        }

        private void groupUI_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = studentDL.GetStudents();
            cmbStudents.DataSource = dt;
            cmbStudents.DisplayMember = "RegistrationNo"; // Jo dikhana hai
            cmbStudents.ValueMember = "Id";
        }
    }
}
