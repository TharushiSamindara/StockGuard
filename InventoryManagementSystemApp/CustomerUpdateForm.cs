using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace InventoryManagementSystemApp
{
    public partial class CustomerUpdateForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\medha\Documents\UoK\Academics\Year 3\COSC\Semester I\COSC 31112 - Visual Programming\Group Project\IMS\InventoryManagementSystemApp\InventoryManagementSystemApp\dbIMS.mdf"";Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        public CustomerUpdateForm()
        {
            InitializeComponent();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to add this customer?", "Saving Customer Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd = new SqlCommand("INSERT INTO tbCustomer(cname,cmobileno)VALUES(@cname, @cmobileno)", con);
                    cmd.Parameters.AddWithValue("@cname", txtCname.Text);
                    cmd.Parameters.AddWithValue("@cmobileno", txtCMobileno.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Customer has been sucessfully saved!");
                    Clear();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Error occured when saving the Customer!", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        public void Clear()
        {
            txtCname.Clear();
            txtCMobileno.Clear();

            txtCname.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to update this Customer?", "Updating Customer Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd = new SqlCommand("UPDATE tbCustomer SET cname = @cname, cmobileno = @cmobileno WHERE cid LIKE '" + lblCId.Text + "'", con);
                    cmd.Parameters.AddWithValue("@cname", txtCname.Text);
                    cmd.Parameters.AddWithValue("@cmobileno", txtCMobileno.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Customer has been sucessfully updated!");
                    this.Dispose();

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error occured when updating the Customer!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
