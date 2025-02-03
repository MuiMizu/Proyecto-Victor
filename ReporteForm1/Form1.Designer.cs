namespace ReporteForm1
{
    partial class Form1
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
            this.sistemaPrestamosDataSet = new ReporteForm1.SistemaPrestamosDataSet();
            this.sistemaPrestamosDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vistaClientesMorososBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vistaClientesMorososTableAdapter = new ReporteForm1.SistemaPrestamosDataSetTableAdapters.VistaClientesMorososTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.sistemaPrestamosDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sistemaPrestamosDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vistaClientesMorososBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.vistaClientesMorososBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ReporteForm1.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.ServerReport.ReportPath = "C:\\Users\\herma\\Source\\Repos\\Proyecto-Victor\\ReporteF\\Report1.rdlc";
            this.reportViewer1.Size = new System.Drawing.Size(1439, 621);
            this.reportViewer1.TabIndex = 0;
            // 
            // sistemaPrestamosDataSet
            // 
            this.sistemaPrestamosDataSet.DataSetName = "SistemaPrestamosDataSet";
            this.sistemaPrestamosDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sistemaPrestamosDataSetBindingSource
            // 
            this.sistemaPrestamosDataSetBindingSource.DataSource = this.sistemaPrestamosDataSet;
            this.sistemaPrestamosDataSetBindingSource.Position = 0;
            // 
            // vistaClientesMorososBindingSource
            // 
            this.vistaClientesMorososBindingSource.DataMember = "VistaClientesMorosos";
            this.vistaClientesMorososBindingSource.DataSource = this.sistemaPrestamosDataSetBindingSource;
            // 
            // vistaClientesMorososTableAdapter
            // 
            this.vistaClientesMorososTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1439, 621);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sistemaPrestamosDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sistemaPrestamosDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vistaClientesMorososBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private SistemaPrestamosDataSet sistemaPrestamosDataSet;
        private System.Windows.Forms.BindingSource sistemaPrestamosDataSetBindingSource;
        private System.Windows.Forms.BindingSource vistaClientesMorososBindingSource;
        private SistemaPrestamosDataSetTableAdapters.VistaClientesMorososTableAdapter vistaClientesMorososTableAdapter;
    }
}

