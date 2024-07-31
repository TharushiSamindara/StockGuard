namespace InventoryManagementSystemApp
{
    partial class CustomerReportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.tbCustomerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbIMSDataSet2 = new InventoryManagementSystemApp.dbIMSDataSet2();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tbCustomerTableAdapter = new InventoryManagementSystemApp.dbIMSDataSet2TableAdapters.tbCustomerTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.tbCustomerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbIMSDataSet2)).BeginInit();
            this.SuspendLayout();
            // 
            // tbCustomerBindingSource
            // 
            this.tbCustomerBindingSource.DataMember = "tbCustomer";
            this.tbCustomerBindingSource.DataSource = this.dbIMSDataSet2;
            // 
            // dbIMSDataSet2
            // 
            this.dbIMSDataSet2.DataSetName = "dbIMSDataSet2";
            this.dbIMSDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "CustomerDataSet1";
            reportDataSource2.Value = this.tbCustomerBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "InventoryManagementSystemApp.CustomerReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(969, 683);
            this.reportViewer1.TabIndex = 0;
            // 
            // tbCustomerTableAdapter
            // 
            this.tbCustomerTableAdapter.ClearBeforeFill = true;
            // 
            // CustomerReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 683);
            this.Controls.Add(this.reportViewer1);
            this.Name = "CustomerReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Report";
            this.Load += new System.EventHandler(this.CustomerReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbCustomerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbIMSDataSet2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private dbIMSDataSet2 dbIMSDataSet2;
        private System.Windows.Forms.BindingSource tbCustomerBindingSource;
        private dbIMSDataSet2TableAdapters.tbCustomerTableAdapter tbCustomerTableAdapter;
    }
}