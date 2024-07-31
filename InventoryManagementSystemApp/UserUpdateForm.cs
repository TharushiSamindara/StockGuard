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
    public partial class UserUpdateForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\medha\Documents\UoK\Academics\Year 3\COSC\Semester I\COSC 31112 - Visual Programming\Group Project\IMS\InventoryManagementSystemApp\InventoryManagementSystemApp\dbIMS.mdf"";Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        public UserUpdateForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if the entered password matches the re-entered password
                if (txtPassword.Text != txtRepassword.Text)
                {
                    MessageBox.Show("Password does not match. Please re-enter the password!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if(MessageBox.Show("Are you sure you want to add this user?","Saving User Record", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd = new SqlCommand("INSERT INTO tbUser(Username, Password, Fullname, MobileNo)VALUES(@Username, @Password, @Fullname, @MobileNo)", con);
                    cmd.Parameters.AddWithValue("@Username",txtUsername.Text);
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@Fullname", txtFullname.Text);
                    cmd.Parameters.AddWithValue("@MobileNo", txtMobileno.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("User has been sucessfully saved!");
                    Clear();

                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error occured when saving the user!","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        public void Clear()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtRepassword.Clear();
            txtFullname.Clear();
            txtMobileno.Clear();
            txtUsername.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if the entered password matches the re-entered password
                if (txtPassword.Text != txtRepassword.Text)
                {
                    MessageBox.Show("Password does not match. Please re-enter the password!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Are you sure you want to update this user?", "Updating User Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd = new SqlCommand("UPDATE tbUser SET Password = @Password, Fullname = @Fullname, MobileNo = @MobileNo WHERE Username LIKE '"+ txtUsername.Text +"'", con);
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@Fullname", txtFullname.Text);
                    cmd.Parameters.AddWithValue("@MobileNo", txtMobileno.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("User has been sucessfully updated!");
                    this.Dispose();

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error occured when updating the user!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
