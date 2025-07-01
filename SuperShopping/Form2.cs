using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperShopping
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent(); // This sets up the UI elements
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            if (Form1.loginname != null)
           {
                toolStripStatusLabel2.Text = Form1.loginname;
            }
            if (Form1.logintype != null && Form1.logintype == "Seller")
            {
                masterToolStripMenuItem.Enabled = false;
                masterToolStripMenuItem.ForeColor = Color.Red;
                productToolStripMenuItem.Enabled = false;
                productToolStripMenuItem.ForeColor = Color.Red;
                addUserToolStripMenuItem.Enabled = false;
                addUserToolStripMenuItem.ForeColor = Color.Red;
            }
        }

        
        

       

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Do you really want to close this Application ?", "CLOSE", MessageBoxButtons.YesNo, MessageBoxIcon.Stop))
            {
                Application.Exit();
            }
        }

        private void sellerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddSeller fseller = new FormAddSeller();
            fseller.ShowDialog();
        }

        

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        
        

        

        private void masterToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form3Cat fcat = new Form3Cat();
            fcat.Show();
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addProductToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormProduct ap = new FormProduct();
            ap.ShowDialog();
        }

        

        private void adminToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            FormAdmin aaf = new FormAdmin();
            aaf.Show();
        }

        private void sellerToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormSelling sf = new FormSelling();
            sf.ShowDialog();
        }

        

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox abt = new AboutBox();
            abt.Show();
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            if (DialogResult.Yes == MessageBox.Show("Do you really want to close this Application ?", "CLOSE", MessageBoxButtons.YesNo, MessageBoxIcon.Stop))
            {
                Application.Exit();
            }
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutBox abt = new AboutBox();
            abt.Show();
        }

        private void sellerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormSelling sf = new FormSelling();
            sf.ShowDialog();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}

