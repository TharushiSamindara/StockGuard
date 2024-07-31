using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSystemApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        // Variable to keep track of the currently active child form
        private Form activeForm = null;

        // Function to open a child form inside the MainForm
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            // Add the child form to the panelMain control
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;
            // Bring the child form to the front and show it
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            // Open the UserForm as a child form
            openChildForm(new UserForm());
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            openChildForm(new CustomerForm());
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            openChildForm(new SupplierForm());
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            openChildForm(new CategoryForm());
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            openChildForm(new ProductForm());
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            openChildForm(new OrderForm());
        }

        //Event handler for the Logout button
        private void label9_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            this.Hide();
            login.ShowDialog();
        }

        // Event handler for the Report button click
        private void btnReport_Click(object sender, EventArgs e)
        {
            // Display a context menu for generating reports
            contextMenuStrip1.Show(btnReport,0,btnReport.Height+30);
        }

        // Event handler for toolStripMenuItem1_Click event (Product Report)
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Open the ProductReportForm to generate a product report
            ProductReportForm productReportForm = new ProductReportForm();
            productReportForm.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            CustomerReportForm customerReportForm = new CustomerReportForm();
            customerReportForm.ShowDialog();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            OrderReportForm orderReportForm = new OrderReportForm();
            orderReportForm.ShowDialog();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            SupplierReportForm supplierReportForm = new SupplierReportForm();
            supplierReportForm.ShowDialog();
        }
    }
}
