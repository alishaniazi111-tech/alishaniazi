using projecta.BL;
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
    public partial class evaluationUI : Form
    {
        public evaluationUI()
        {
            InitializeComponent();
        }

        private void evaluationUI_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void BtnAdd_Click_Click(object sender, EventArgs e)
        {
            try
            {
                // UI se data lena
                string name = txtName.Text;
                float marks = float.Parse(txtTotalMarks.Text);
                float weightage = float.Parse(txtTotalWeightage.Text);

                // Business Logic Object banana
                evaluationBL eval = new evaluationBL(0, name, marks, weightage);

                // Database mein save karne ka function call karein (Aapko DL mein Add function likhna hoga)
                if (SaveToDatabase(eval))
                {
                    MessageBox.Show("Evaluation Added Successfully!");
                    RefreshGrid();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ClearFields()
        {
            txtName.Clear();
            txtTotalMarks.Clear();
            txtTotalWeightage.Clear();
        }

        private void BtnEdit_Click_Click(object sender, EventArgs e)
        {

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
