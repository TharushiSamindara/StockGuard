namespace InventoryManagementSystemApp
{
    partial class OrderReportForm
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
            this.tbOrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbIMSDataSet2 = new InventoryManagementSystemApp.dbIMSDataSet2();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tbOrderTableAdapter = new InventoryManagementSystemApp.dbIMSDataSet2TableAdapters.tbOrderTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.tbOrderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbIMSDataSet2)).BeginInit();
            this.SuspendLayout();
            // 
            // tbOrderBindingSource
            // 
            this.tbOrderBindingSource.DataMember = "tbOrder";
            this.tbOrderBindingSource.DataSource = this.dbIMSDataSet2;
            // 
            // dbIMSDataSet2
            // 
            this.dbIMSDataSet2.DataSetName = "dbIMSDataSet2";
            this.dbIMSDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.tbOrderBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "InventoryManagementSystemApp.OrderReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(969, 683);
            this.reportViewer1.TabIndex = 0;
            // 
            // tbOrderTableAdapter
            // 
            this.tbOrderTableAdapter.ClearBeforeFill = true;
            // 
            // OrderReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 683);
            this.Controls.Add(this.reportViewer1);
            this.Name = "OrderReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Order Report";
            this.Load += new System.EventHandler(this.OrderReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbOrderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbIMSDataSet2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private dbIMSDataSet2 dbIMSDataSet2;
        private System.Windows.Forms.BindingSource tbOrderBindingSource;
        private dbIMSDataSet2TableAdapters.tbOrderTableAdapter tbOrderTableAdapter;
    }
}