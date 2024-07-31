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
    public partial class SupplierReportForm : Form
    {
        public SupplierReportForm()
        {
            InitializeComponent();
        }

        private void SupplierReportForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbIMSDataSet2.tbSupplier' table. You can move, or remove it, as needed.
            this.tbSupplierTableAdapter.Fill(this.dbIMSDataSet2.tbSupplier);

            this.reportViewer1.RefreshReport();
        }
    }
}
