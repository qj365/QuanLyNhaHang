
namespace QuanLyKhachHang
{
    partial class frHoaDonIn
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
            this.getCTPYCBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QUANLYNHAHANGDataSet = new QuanLyKhachHang.QUANLYNHAHANGDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.getCTPYCTableAdapter = new QuanLyKhachHang.QUANLYNHAHANGDataSetTableAdapters.getCTPYCTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.getCTPYCBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QUANLYNHAHANGDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // getCTPYCBindingSource
            // 
            this.getCTPYCBindingSource.DataMember = "getCTPYC";
            this.getCTPYCBindingSource.DataSource = this.QUANLYNHAHANGDataSet;
            // 
            // QUANLYNHAHANGDataSet
            // 
            this.QUANLYNHAHANGDataSet.DataSetName = "QUANLYNHAHANGDataSet";
            this.QUANLYNHAHANGDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.getCTPYCBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyKhachHang.Report.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(812, 738);
            this.reportViewer1.TabIndex = 0;
            // 
            // getCTPYCTableAdapter
            // 
            this.getCTPYCTableAdapter.ClearBeforeFill = true;
            // 
            // frHoaDonIn
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(812, 738);
            this.Controls.Add(this.reportViewer1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frHoaDonIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frHoaDonIn";
            this.Load += new System.EventHandler(this.frHoaDonIn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.getCTPYCBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QUANLYNHAHANGDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource getCTPYCBindingSource;
        private QUANLYNHAHANGDataSet QUANLYNHAHANGDataSet;
        private QUANLYNHAHANGDataSetTableAdapters.getCTPYCTableAdapter getCTPYCTableAdapter;
    }
}