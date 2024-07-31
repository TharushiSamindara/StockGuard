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
    public partial class ProductForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\medha\Documents\UoK\Academics\Year 3\COSC\Semester I\COSC 31112 - Visual Programming\Group Project\IMS\InventoryManagementSystemApp\InventoryManagementSystemApp\dbIMS.mdf"";Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        public ProductForm()
        {
            InitializeComponent();
            // Load the products into the DataGridView when the form is created
            LoadProduct();
        }

        // Function to load products into the DataGridView
        public void LoadProduct()
        {
            int i = 0;
            dgvProduct.Rows.Clear();
            // Create a SQL query to search for products based on the search text
            cmd = new SqlCommand("SELECT * FROM tbProduct WHERE CONCAT(pid, pname, pprice, pdescription, pcategory) LIKE '%"+txtSearch.Text+"%'", con);
            con.Open();
            // Execute the SQL query and read the results
            dr = cmd.ExecuteReader();
            // Loop through the result rows and add them to the DataGridView
            while (dr.Read())
            {
                i++;
                dgvProduct.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
            }
            // Close the database connection and the data reader
            dr.Close();
            con.Close();
        }

        // Event handler for the Add button
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Create an instance of the ProductUpdateForm for adding a new product
            ProductUpdateForm proupdate = new ProductUpdateForm();
            // Enable the "Save" button and disable the "Update" button in the ProductUpdateForm
            proupdate.btnSave.Enabled = true;
            proupdate.btnUpdate.Enabled = false;
            proupdate.ShowDialog();
            // Reload the products after adding a new one
            LoadProduct();
        }

        // Event handler when a cell in the DataGridView is clicked (Edit or Delete)
        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvProduct.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                // Create an instance of the ProductUpdateForm for editing an existing product
                ProductUpdateForm proUpdate = new ProductUpdateForm();
                // Populate the ProductUpdateForm fields with data from the selected row
                proUpdate.lblPId.Text = dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
                proUpdate.txtPname.Text = dgvProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
                proUpdate.txtPquantity.Text = dgvProduct.Rows[e.RowIndex].Cells[3].Value.ToString();
                proUpdate.txtPprice.Text = dgvProduct.Rows[e.RowIndex].Cells[4].Value.ToString();
                proUpdate.txtPdescrip.Text = dgvProduct.Rows[e.RowIndex].Cells[5].Value.ToString();
                proUpdate.cmbPcat.Text = dgvProduct.Rows[e.RowIndex].Cells[6].Value.ToString();

                // Enable the "Update" button and disable the "Save" button in the ProductUpdateForm
                proUpdate.btnSave.Enabled = false;
                proUpdate.btnUpdate.Enabled = true;
                proUpdate.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this product?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    // Create a SQL query to delete the selected product
                    cmd = new SqlCommand("DELETE FROM tbProduct WHERE pid LIKE '" + dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record hase been sucessfully deleted!");
                }
            }
            // Reload the products after performing action (edit or delete)
            LoadProduct();
        }

        // Reload the products based on the updated search text
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }
    }
}
