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
    public partial class ProductReportForm : Form
    {
        public ProductReportForm()
        {
            InitializeComponent();
        }

        private void ProductReportForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbIMSDataSet1.tbProduct' table. You can move, or remove it, as needed.
            this.tbProductTableAdapter.Fill(this.dbIMSDataSet1.tbProduct);

            // Refresh the report viewer to display the loaded data
            this.reportViewer1.RefreshReport();
        }
    }
}
