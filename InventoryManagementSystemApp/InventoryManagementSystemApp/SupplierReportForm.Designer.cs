namespace InventoryManagementSystemApp
{
    partial class SupplierReportForm
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.tbSupplierBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbIMSDataSet2 = new InventoryManagementSystemApp.dbIMSDataSet2();
            this.tbSupplierTableAdapter = new InventoryManagementSystemApp.dbIMSDataSet2TableAdapters.tbSupplierTableAdapter();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.tbSupplierBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbIMSDataSet2)).BeginInit();
            this.SuspendLayout();
            // 
            // tbSupplierBindingSource
            // 
            this.tbSupplierBindingSource.DataMember = "tbSupplier";
            this.tbSupplierBindingSource.DataSource = this.dbIMSDataSet2;
            // 
            // dbIMSDataSet2
            // 
            this.dbIMSDataSet2.DataSetName = "dbIMSDataSet2";
            this.dbIMSDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbSupplierTableAdapter
            // 
            this.tbSupplierTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "SuuplierDataSet1";
            reportDataSource1.Value = this.tbSupplierBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "InventoryManagementSystemApp.SupplierReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(951, 636);
            this.reportViewer1.TabIndex = 0;
            // 
            // SupplierReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 636);
            this.Controls.Add(this.reportViewer1);
            this.Name = "SupplierReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supplier Report";
            this.Load += new System.EventHandler(this.SupplierReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbSupplierBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbIMSDataSet2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private dbIMSDataSet2 dbIMSDataSet2;
        private dbIMSDataSet2TableAdapters.tbSupplierTableAdapter tbSupplierTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tbSupplierBindingSource;
    }
}