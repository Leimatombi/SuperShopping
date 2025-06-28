using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperShopping
{
    public partial class Form3Cat : Form
    {
        DBConnect dbCon = new DBConnect();
        public Form3Cat()
        {
            InitializeComponent();
        }

        private void Form3Cat_Load(object sender, EventArgs e)
        {
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
            lblCatID.Visible = false;
            BindCategory();
        }

        private void btnAddCat_Click_1(object sender, EventArgs e)
        {
            if (txtCatname.Text == String.Empty)
            {
                MessageBox.Show("Please Enter CategoryName", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCatname.Focus();
                return;
            }
            else if (rtbCatDesc.Text == String.Empty)
            {
                MessageBox.Show("Please Enter Category Description", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rtbCatDesc.Focus();
                return;
            }
            else
            {
                SqlCommand cmd = new SqlCommand("select CategoryName from tblCategory where CategoryName=@CategoryName", dbCon.GetCon());
                cmd.Parameters.AddWithValue("@CategoryName", txtCatname.Text);
                dbCon.OpenCon();
                var result = cmd.ExecuteScalar();
                if (result != null)
                {
                    MessageBox.Show("CategoryName already exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtClear();
                }
                else
                {
                    cmd = new SqlCommand("spCatInsert", dbCon.GetCon());
                    cmd.Parameters.AddWithValue("@CategoryName", txtCatname.Text);
                    cmd.Parameters.AddWithValue("@CategoryDesc", rtbCatDesc.Text);
                    cmd.CommandType = CommandType.StoredProcedure;
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Category Inserted Successfully...", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtClear();
                        BindCategory();
                    }
                }
                dbCon.CloseCon();
            }

        }
        private void txtClear()
        {
            txtCatname.Clear(); rtbCatDesc.Clear();
        }
        private void BindCategory()
        {
            using (SqlCommand cmd = new SqlCommand("SELECT CatID AS CategoryID, CategoryName AS CategoryName, CategoryDesc AS CategoryDescription FROM tblCategory", dbCon.GetCon()))
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lblCatID.Text))
            {
                MessageBox.Show("Please select CategoryID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCatname.Text))
            {
                MessageBox.Show("Please Enter CategoryName", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(rtbCatDesc.Text))
            {
                MessageBox.Show("Please Enter Category Description", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }




            dbCon.OpenCon(); // 🔑 Make sure connection is open BEFORE calling ExecuteScalar()

            using (SqlCommand checkCmd = new SqlCommand("select CategoryName from tblCategory where CategoryName=@CategoryName", dbCon.GetCon()))
            {
                checkCmd.Parameters.AddWithValue("@CategoryName", txtCatname.Text);
                checkCmd.Parameters.AddWithValue("@CategoryDesc", rtbCatDesc.Text);



                var result = checkCmd.ExecuteScalar();


                if (result != null)
                {
                    //     MessageBox.Show("CategoryName already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    txtClear();
                    //    dbCon.CloseCon();
                    //    return;
                    //}


                    SqlCommand cmd = new SqlCommand("spCatUpdate", dbCon.GetCon());

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CatID", Convert.ToInt32(lblCatID.Text));
                    cmd.Parameters.AddWithValue("@CategoryName", txtCatname.Text);
                    cmd.Parameters.AddWithValue("@CategoryDesc", rtbCatDesc.Text);

                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Category updated Successfully...", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtClear();
                        BindCategory();
                        btnUpdate.Visible = false;
                        btnDelete.Visible = false;
                        btnAddCat.Visible = true;
                        lblCatID.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Update failed...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtClear();
                    }
                }
                else
                {
                    MessageBox.Show("CategoryName already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtClear();
                        dbCon.CloseCon();
                       return;
                }
            }

            dbCon.CloseCon();
        }


        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (lblCatID.Text == String.Empty)
                {
                    MessageBox.Show("Please select CategoryID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (lblCatID.Text != String.Empty)
                {
                    if (DialogResult.Yes == MessageBox.Show("Do You Want to Delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        SqlCommand cmd = new SqlCommand("spCatDelete", dbCon.GetCon());
                        cmd.Parameters.AddWithValue("@CatID", Convert.ToInt32(lblCatID.Text));
                        cmd.CommandType = CommandType.StoredProcedure;
                        dbCon.OpenCon();
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            MessageBox.Show("Category Deleted Successfully...", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtClear();
                            BindCategory();
                            btnUpdate.Visible = false;
                            btnDelete.Visible = false;
                            btnAddCat.Visible = true;
                            lblCatID.Visible = false;
                        }
                        else
                        {
                            MessageBox.Show("Delete failed...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtClear();
                        }
                        dbCon.CloseCon();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblCatID_Click(object sender, EventArgs e)
        {

        }

        private void txtCatname_TextChanged(object sender, EventArgs e)
        {

        }

        private void rtbCatDesc_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_Click_1(object sender, EventArgs e)
        {
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
            lblCatID.Visible = true;
            btnAddCat.Visible = true;

            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Index >= 0)
            {
                DataGridViewRow row = dataGridView1.CurrentRow;
                lblCatID.Text = row.Cells[0].Value?.ToString();
                txtCatname.Text = row.Cells[1].Value?.ToString();
                rtbCatDesc.Text = row.Cells[2].Value?.ToString();
            }
        }

       
    }
}
