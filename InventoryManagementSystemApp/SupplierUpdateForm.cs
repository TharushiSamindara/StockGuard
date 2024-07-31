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
    public partial class SupplierUpdateForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\medha\Documents\UoK\Academics\Year 3\COSC\Semester I\COSC 31112 - Visual Programming\Group Project\IMS\InventoryManagementSystemApp\InventoryManagementSystemApp\dbIMS.mdf"";Integrated Security=True");
        SqlCommand cmd = new SqlCommand();

        public SupplierUpdateForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to add this supplier?", "Saving Supplier Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd = new SqlCommand("INSERT INTO tbSupplier(sname, scontact, semail, saddress)VALUES(@sname, @scontact, @semail, @saddress)", con);
                    cmd.Parameters.AddWithValue("@sname", txtSname.Text);
                    cmd.Parameters.AddWithValue("@scontact", txtScontact.Text);
                    cmd.Parameters.AddWithValue("@semail", txtSemail.Text);
                    cmd.Parameters.AddWithValue("@saddress", txtSaddress.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Supplier has been sucessfully saved!");
                    Clear();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error occured when saving the Supplier!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Clear()
        {
            txtSname.Clear();
            txtScontact.Clear();
            txtSemail.Clear();
            txtSaddress.Clear();
            txtSname.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to update this Supplier?", "Updating Customer Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd = new SqlCommand("UPDATE tbSupplier SET sname = @sname, scontact = @scontact, semail = @semail, saddress = @saddress WHERE sid LIKE '" + lblSId.Text + "'", con);
                    cmd.Parameters.AddWithValue("@sname", txtSname.Text);
                    cmd.Parameters.AddWithValue("@scontact", txtScontact.Text);
                    cmd.Parameters.AddWithValue("@semail", txtSemail.Text);
                    cmd.Parameters.AddWithValue("@saddress", txtSaddress.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Supplier has been sucessfully updated!");
                    this.Dispose();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message+"Error occured during updating the Supplier!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
