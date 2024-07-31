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

namespace InventoryManagementSystemApp
{
    public partial class LoginForm : Form
    {
        //SqlConnection to connect to the SQL Server database
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\medha\Documents\UoK\Academics\Year 3\COSC\Semester I\COSC 31112 - Visual Programming\Group Project\IMS\InventoryManagementSystemApp\InventoryManagementSystemApp\dbIMS.mdf"";Integrated Security=True");
        //SqlCommand for executing SQL queries
        SqlCommand cmd = new SqlCommand();
        //SqlDataReader for reading data from the database
        SqlDataReader dr;

        public LoginForm()
        {
            InitializeComponent();
        }

        //Switch the password visibility based on the checkbox state
        private void checkBoxPassword_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxPassword.Checked == false) 
            {
                txtPassword.UseSystemPasswordChar = true;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = false;
            }
        }

        //Event handler for Clear button
        private void button3_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtPassword.Clear();
            txtName.Focus();
        }

        //Event handler for Exit button
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Are you sure you want to exit from the application", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                this.Show();
            }
        }

        //Event handler for Login button
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                // Create a SQL query to check if a user with the provided username and password exists
                cmd = new SqlCommand("SELECT * FROM tbUser WHERE username = @username AND password = @password", con);
                cmd.Parameters.AddWithValue("@username", txtName.Text);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                con.Open();

                // Execute the SQL query and read the results
                dr = cmd.ExecuteReader();
                dr.Read();

                // Check if there are rows in the result, indicating a successful login
                if (dr.HasRows)
                {
                    MessageBox.Show("Welcome " + dr["fullname"].ToString(), "ACCESS GRANRTED",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    MainForm main = new MainForm();
                    this.Hide();
                    main.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Invalid username or password","ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error occured while logging!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
