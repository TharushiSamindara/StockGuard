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
    public partial class UserForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\medha\Documents\UoK\Academics\Year 3\COSC\Semester I\COSC 31112 - Visual Programming\Group Project\IMS\InventoryManagementSystemApp\InventoryManagementSystemApp\dbIMS.mdf"";Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        public UserForm()
        {
            InitializeComponent();
            LoadUser();
        }
        
        public void LoadUser()
        {
            int i = 0;
            dgvUser.Rows.Clear();
            cmd = new SqlCommand("SELECT * FROM tbUser", con);
            con.Open();
            dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                i++;
                dgvUser.Rows.Add(i,dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UserUpdateForm userUpdate = new UserUpdateForm();
            userUpdate.btnSave.Enabled = true;
            userUpdate.btnUpdate.Enabled = false;
            userUpdate.ShowDialog();
            LoadUser();
        }

        private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvUser.Columns[e.ColumnIndex].Name;
            if(colName == "Edit")
            {
                UserUpdateForm userUpdate = new UserUpdateForm();
                userUpdate.txtUsername.Text = dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString();
                userUpdate.txtPassword.Text = dgvUser.Rows[e.RowIndex].Cells[2].Value.ToString();
                userUpdate.txtFullname.Text = dgvUser.Rows[e.RowIndex].Cells[3].Value.ToString();
                userUpdate.txtMobileno.Text = dgvUser.Rows[e.RowIndex].Cells[4].Value.ToString();

                userUpdate.btnSave.Enabled = false;
                userUpdate.btnUpdate.Enabled = true;
                userUpdate.txtUsername.Enabled = false;
                userUpdate.ShowDialog();
            }
            else if(colName == "Delete")
            {
                if(MessageBox.Show("Are you sure you want to delete this user?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cmd = new SqlCommand("DELETE FROM tbUser WHERE Username LIKE '" + dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record hase been sucessfully deleted!");
                }
            }

            LoadUser();
        }
    }
}
