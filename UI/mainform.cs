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
    public partial class mainform : Form
    {
        private Panel panelSidebar;
        private Panel panelTopbar;
        private Panel panelContent;
        public mainform()
        {
            InitializeComponent();
        }

        private void mainform_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           


        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            personUI personUI = new personUI();
            personUI.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            studentUI studentUI = new studentUI();
            studentUI.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdvisorUI advisorUI = new AdvisorUI();
            advisorUI.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupUI groupUI = new groupUI();
            groupUI.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            projectUI projectUI = new projectUI();
                projectUI.Show();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            evaluationUI evaluationUI = new evaluationUI();
            evaluationUI.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            lookupUI lookupUI = new lookupUI();
            lookupUI.Show();
        }
    }
}
