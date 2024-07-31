﻿using System;
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
    public partial class OrderReportForm : Form
    {
        public OrderReportForm()
        {
            InitializeComponent();
        }

        private void OrderReportForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbIMSDataSet2.tbOrder' table. You can move, or remove it, as needed.
            this.tbOrderTableAdapter.Fill(this.dbIMSDataSet2.tbOrder);

            this.reportViewer1.RefreshReport();
        }
    }
}
