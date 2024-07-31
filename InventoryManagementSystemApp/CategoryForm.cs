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
    public partial class CategoryForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\medha\Documents\UoK\Academics\Year 3\COSC\Semester I\COSC 31112 - Visual Programming\Group Project\IMS\InventoryManagementSystemApp\InventoryManagementSystemApp\dbIMS.mdf"";Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        public CategoryForm()
        {
            InitializeComponent();
            // Load categories into the DataGridView when the form is created
            LoadCategory();
        }

        // Function to load categories into the DataGridView
        public void LoadCategory()
        {
            int i = 0;
            dgvCategory.Rows.Clear();
            cmd = new SqlCommand("SELECT * FROM tbCategory", con);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvCategory.Rows.Add(i, dr[0].ToString(), dr[1].ToString());
            }
            dr.Close();
            con.Close();
        }

        // Event handler for the Add button
        private void btnAdd_Click(object sender, EventArgs e)
        {
            CategoryUpdateForm catupdate = new CategoryUpdateForm();
            catupdate.btnSave.Enabled = true;
            catupdate.btnUpdate.Enabled = false;
            catupdate.ShowDialog();
            LoadCategory();
        }

        // Event handler when a cell in the DataGridView is clicked (Edit or delete)
        private void dgvCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvCategory.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                CategoryUpdateForm catUpdate = new CategoryUpdateForm();
                catUpdate.lblCatid.Text = dgvCategory.Rows[e.RowIndex].Cells[1].Value.ToString();
                catUpdate.txtCatname.Text = dgvCategory.Rows[e.RowIndex].Cells[2].Value.ToString();

                catUpdate.btnSave.Enabled = false;
                catUpdate.btnUpdate.Enabled = true;
                catUpdate.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this Category?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cmd = new SqlCommand("DELETE FROM tbCategory WHERE catid LIKE '" + dgvCategory.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record hase been sucessfully deleted!");
                }
            }
            LoadCategory();
        }
    }
}
