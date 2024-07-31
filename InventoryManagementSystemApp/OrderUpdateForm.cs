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
    public partial class OrderUpdateForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\medha\Documents\UoK\Academics\Year 3\COSC\Semester I\COSC 31112 - Visual Programming\Group Project\IMS\InventoryManagementSystemApp\InventoryManagementSystemApp\dbIMS.mdf"";Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        int qty = 0;    // Variable to store product quantity

        public OrderUpdateForm()
        {
            InitializeComponent();
            // Load customer and product data into the form when it is created
            LoadCustomer();
            LoadProduct();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        // Function to load customer data into the DataGridView
        public void LoadCustomer()
        {
            int i = 0;
            dgvCustomer.Rows.Clear();
            cmd = new SqlCommand("SELECT cid, cname FROM tbCustomer WHERE CONCAT(cid,cname) LIKE '%"+txtSearchCust.Text+"%'", con);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvCustomer.Rows.Add(i, dr[0].ToString(), dr[1].ToString());
            }
            dr.Close();
            con.Close();
        }

        // Function to load product data into the DataGridView
        public void LoadProduct()
        {
            int i = 0;
            dgvProduct.Rows.Clear();
            cmd = new SqlCommand("SELECT * FROM tbProduct WHERE CONCAT(pid, pname, pprice, pdescription, pcategory) LIKE '%" + txtSearchprod.Text + "%'", con);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvProduct.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
            }
            dr.Close();
            con.Close();
        }

        // Event handler when the customer search text changes
        private void txtSearchCust_TextChanged(object sender, EventArgs e)
        {
            // Reload customer data based on the search text
            LoadCustomer();
        }

        // Event handler when the product search text changes
        private void txtSearchprod_TextChanged(object sender, EventArgs e)
        {
            // Reload product data based on the search text
            LoadProduct();
        }

        // Event handler when the quantity value changes
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            GetQty();   // Call the GetQty function to retrieve the available quantity for the selected product

            // Check if the selected quantity is greater than the available quantity
            if (Convert.ToInt16(UDQty.Value) > qty)
            {
                MessageBox.Show("Quantity in the stock is not enough!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // Reduce the quantity to the maximum available quantity
                UDQty.Value = UDQty.Value - 1;
                return;
            }
            if (Convert.ToInt16(UDQty.Value) > 0)
            {
                // Calculate the total price based on the selected quantity and unit price
                decimal total = Convert.ToDecimal(txtPrice.Text) * Convert.ToInt16(UDQty.Value);
                txtTotal.Text = total.ToString();
            }
            
        }

        // Event handler when a cell in the customer DataGridView is clicked
        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Populate the customer information fields when a customer is selected
            txtCId.Text = dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtCName.Text = dgvCustomer.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        // Event handler when a cell in the product DataGridView is clicked
        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Populate the product information fields when a product is selected
            txtPid.Text = dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtPname.Text = dgvProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtPrice.Text = dgvProduct.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        //Event handler for the Insert button
        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCId.Text == "")
                {
                    MessageBox.Show("Please select the customer!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtPid.Text == "")
                {
                    MessageBox.Show("Please select product!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Are you sure you want to insert this order?", "Inserting Order Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd = new SqlCommand("INSERT INTO tbOrder(odate, pid, cid, qty, price, total)VALUES(@odate, @pid, @cid, @qty, @price, @total)", con);
                    cmd.Parameters.AddWithValue("@odate", dtOrder.Value);
                    cmd.Parameters.AddWithValue("@pid", Convert.ToInt16(txtPid.Text));
                    cmd.Parameters.AddWithValue("@cid", Convert.ToInt16(txtCId.Text));
                    cmd.Parameters.AddWithValue("@qty", Convert.ToInt16(UDQty.Value));
                    cmd.Parameters.AddWithValue("@price", Convert.ToDecimal(txtPrice.Text));
                    cmd.Parameters.AddWithValue("@total", Convert.ToDecimal(txtTotal.Text));
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Order has been sucessfully inserted!");

                    cmd = new SqlCommand("UPDATE tbProduct SET pqty = (pqty-@pqty) WHERE pid LIKE '" + txtPid.Text + "'", con);
                    cmd.Parameters.AddWithValue("@pqty", Convert.ToInt16(UDQty.Value));
                    
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Clear();
                    LoadProduct();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error occured when inserting the order!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Clear()
        {
            txtCId.Clear();
            txtCName.Clear();

            txtPid.Clear();
            txtPname.Clear();

            txtPrice.Clear();
            UDQty.Value = 0;
            txtTotal.Clear();
            dtOrder.Value = DateTime.Now;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        //Function to retrieve the available quantity of selected product from the database
        public void GetQty()
        {
            cmd = new SqlCommand("SELECT pqty FROM tbProduct WHERE pid = '"+txtPid.Text+"'", con);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                qty = Convert.ToInt32(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }
    }
}
