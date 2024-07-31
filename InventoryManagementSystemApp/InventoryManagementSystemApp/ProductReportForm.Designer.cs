namespace InventoryManagementSystemApp
{
    partial class ProductReportForm
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
            this.tbProductBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbIMSDataSet1 = new InventoryManagementSystemApp.dbIMSDataSet1();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tbProductTableAdapter = new InventoryManagementSystemApp.dbIMSDataSet1TableAdapters.tbProductTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.tbProductBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbIMSDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbProductBindingSource
            // 
            this.tbProductBindingSource.DataMember = "tbProduct";
            this.tbProductBindingSource.DataSource = this.dbIMSDataSet1;
            // 
            // dbIMSDataSet1
            // 
            this.dbIMSDataSet1.DataSetName = "dbIMSDataSet1";
            this.dbIMSDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.tbProductBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "InventoryManagementSystemApp.ProductReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(969, 683);
            this.reportViewer1.TabIndex = 0;
            // 
            // tbProductTableAdapter
            // 
            this.tbProductTableAdapter.ClearBeforeFill = true;
            // 
            // ProductReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 683);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ProductReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Report";
            this.Load += new System.EventHandler(this.ProductReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbProductBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbIMSDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private dbIMSDataSet1 dbIMSDataSet1;
        private System.Windows.Forms.BindingSource tbProductBindingSource;
        private dbIMSDataSet1TableAdapters.tbProductTableAdapter tbProductTableAdapter;
    }
}