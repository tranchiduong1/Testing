﻿namespace QuanLiPetMarket
{
    partial class frmXuatHoaDon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXuatHoaDon));
            this.HoaDonChiTietBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QLPetMarketDataSet1 = new QuanLiPetMarket.QLPetMarketDataSet1();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.HoaDonChiTietTableAdapter = new QuanLiPetMarket.QLPetMarketDataSet1TableAdapters.HoaDonChiTietTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.HoaDonChiTietBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QLPetMarketDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // HoaDonChiTietBindingSource
            // 
            this.HoaDonChiTietBindingSource.DataMember = "HoaDonChiTiet";
            this.HoaDonChiTietBindingSource.DataSource = this.QLPetMarketDataSet1;
            // 
            // QLPetMarketDataSet1
            // 
            this.QLPetMarketDataSet1.DataSetName = "QLPetMarketDataSet1";
            this.QLPetMarketDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.HoaDonChiTietBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLiPetMarket.Report.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(710, 523);
            this.reportViewer1.TabIndex = 0;
            // 
            // HoaDonChiTietTableAdapter
            // 
            this.HoaDonChiTietTableAdapter.ClearBeforeFill = true;
            // 
            // frmXuatHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 523);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmXuatHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XuatHoaDon";
            this.Load += new System.EventHandler(this.frmXuatHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HoaDonChiTietBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QLPetMarketDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource HoaDonChiTietBindingSource;
        private QLPetMarketDataSet1 QLPetMarketDataSet1;
        private QLPetMarketDataSet1TableAdapters.HoaDonChiTietTableAdapter HoaDonChiTietTableAdapter;
    }
}