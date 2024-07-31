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
    public partial class ProductUpdateForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\medha\Documents\UoK\Academics\Year 3\COSC\Semester I\COSC 31112 - Visual Programming\Group Project\IMS\InventoryManagementSystemApp\InventoryManagementSystemApp\dbIMS.mdf"";Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        public ProductUpdateForm()
        {
            InitializeComponent();
            // Load product categories into the ComboBox when the form is created
            LoadCategory();
        }

        // Function to load product categories into the ComboBox
        public void LoadCategory()
        {
            // Clear existing items in the ComboBox
            cmbPcat.Items.Clear();
            // Create a SQL query to retrieve product categories from the database
            cmd = new SqlCommand("SELECT catname FROM tbCategory", con);
            con.Open();
            dr = cmd.ExecuteReader();

            // Loop through the results and add categories to the ComboBox
            while (dr.Read())
            {
                cmbPcat.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }

        // Event handler for the Cancel button
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Event handler for the Save button
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to add this Product?", "Saving Product Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Create a SQL query to insert a new product record into the database
                    cmd = new SqlCommand("INSERT INTO tbProduct(pname, pqty, pprice, pdescription, pcategory)VALUES(@pname, @pqty, @pprice, @pdescription, @pcategory)", con);
                    // Set parameter values based on user input
                    cmd.Parameters.AddWithValue("@pname", txtPname.Text);
                    cmd.Parameters.AddWithValue("@pqty", Convert.ToInt16(txtPquantity.Text));
                    cmd.Parameters.AddWithValue("@pprice", Convert.ToDecimal(txtPprice.Text));
                    cmd.Parameters.AddWithValue("@pdescription", txtPdescrip.Text);
                    cmd.Parameters.AddWithValue("@pcategory", cmbPcat.Text);
                    con.Open();
                    // Execute the SQL query to insert the product record
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Product has been sucessfully saved!");
                    Clear();

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error occured when saving the product!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Function to clear the form fields
        public void Clear()
        {
            txtPname.Clear();
            txtPquantity.Clear();
            txtPprice.Clear();
            txtPdescrip.Clear();
            cmbPcat.Text = " ";
            txtPname.Focus();
        }

        // Event handler for the Clear button
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        // Event handler for the Update button
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to update this product?", "Updating Product Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Create a SQL query to update an existing product record in the database
                    cmd = new SqlCommand("UPDATE tbProduct SET pname = @pname, pqty = @pqty, pprice = @pprice, pdescription = @pdescription, pcategory = @pcategory WHERE pid LIKE '" + lblPId.Text + "'", con);
                    // Set parameter values based on user input
                    cmd.Parameters.AddWithValue("@pname", txtPname.Text);
                    cmd.Parameters.AddWithValue("@pqty", Convert.ToInt16(txtPquantity.Text));
                    cmd.Parameters.AddWithValue("@pprice", Convert.ToDecimal(txtPprice.Text));
                    cmd.Parameters.AddWithValue("@pdescription", txtPdescrip.Text);
                    cmd.Parameters.AddWithValue("@pcategory", cmbPcat.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Product has been sucessfully updated!");
                    this.Dispose();

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error occured when updating the product!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
