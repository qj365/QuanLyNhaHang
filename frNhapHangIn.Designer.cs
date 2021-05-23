
namespace QuanLyKhachHang
{
    partial class frNhapHangIn
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.QUANLYNHAHANGDataSet1 = new QuanLyKhachHang.QUANLYNHAHANGDataSet1();
            this.getCTPNmaxBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.getCTPNmaxTableAdapter = new QuanLyKhachHang.QUANLYNHAHANGDataSet1TableAdapters.getCTPNmaxTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.QUANLYNHAHANGDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getCTPNmaxBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.getCTPNmaxBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyKhachHang.Report.Report3.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(976, 835);
            this.reportViewer1.TabIndex = 0;
            // 
            // QUANLYNHAHANGDataSet1
            // 
            this.QUANLYNHAHANGDataSet1.DataSetName = "QUANLYNHAHANGDataSet1";
            this.QUANLYNHAHANGDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // getCTPNmaxBindingSource
            // 
            this.getCTPNmaxBindingSource.DataMember = "getCTPNmax";
            this.getCTPNmaxBindingSource.DataSource = this.QUANLYNHAHANGDataSet1;
            // 
            // getCTPNmaxTableAdapter
            // 
            this.getCTPNmaxTableAdapter.ClearBeforeFill = true;
            // 
            // frNhapHangIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 835);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frNhapHangIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frNhapHangIn";
            this.Load += new System.EventHandler(this.frNhapHangIn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.QUANLYNHAHANGDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getCTPNmaxBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource getCTPNmaxBindingSource;
        private QUANLYNHAHANGDataSet1 QUANLYNHAHANGDataSet1;
        private QUANLYNHAHANGDataSet1TableAdapters.getCTPNmaxTableAdapter getCTPNmaxTableAdapter;
    }
}