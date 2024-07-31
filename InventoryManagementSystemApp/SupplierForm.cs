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
    public partial class SupplierForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\medha\Documents\UoK\Academics\Year 3\COSC\Semester I\COSC 31112 - Visual Programming\Group Project\IMS\InventoryManagementSystemApp\InventoryManagementSystemApp\dbIMS.mdf"";Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        public SupplierForm()
        {
            InitializeComponent();
            LoadSupplier();
        }

        public void LoadSupplier()
        {
            int i = 0;
            dgvSupplier.Rows.Clear();
            cmd = new SqlCommand("SELECT * FROM tbSupplier", con);
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvSupplier.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SupplierUpdateForm supplierUpdate = new SupplierUpdateForm();
            supplierUpdate.btnSave.Enabled = true;
            supplierUpdate.btnUpdate.Enabled = false;
            supplierUpdate.ShowDialog();
            LoadSupplier();
        }

        private void dgvSupplier_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvSupplier.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                SupplierUpdateForm supUpdate = new SupplierUpdateForm();
                supUpdate.lblSId.Text = dgvSupplier.Rows[e.RowIndex].Cells[1].Value.ToString();
                supUpdate.txtSname.Text = dgvSupplier.Rows[e.RowIndex].Cells[2].Value.ToString();
                supUpdate.txtScontact.Text = dgvSupplier.Rows[e.RowIndex].Cells[3].Value.ToString();
                supUpdate.txtSemail.Text = dgvSupplier.Rows[e.RowIndex].Cells[4].Value.ToString();
                supUpdate.txtSaddress.Text = dgvSupplier.Rows[e.RowIndex].Cells[5].Value.ToString();

                supUpdate.btnSave.Enabled = false;
                supUpdate.btnUpdate.Enabled = true;
                supUpdate.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this Supplier?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cmd = new SqlCommand("DELETE FROM tbSupplier WHERE sid LIKE '" + dgvSupplier.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record hase been sucessfully deleted!");
                }
            }

            LoadSupplier();
        }
    }
}
