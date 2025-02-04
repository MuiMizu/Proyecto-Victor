namespace ReporteCMorosos
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
            this.vistaClientesMorososBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sistemaPrestamosDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sistemaPrestamosDataSet = new ReporteCMorosos.SistemaPrestamosDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.vistaClientesMorososTableAdapter = new ReporteCMorosos.SistemaPrestamosDataSetTableAdapters.VistaClientesMorososTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.vistaClientesMorososBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sistemaPrestamosDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sistemaPrestamosDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // vistaClientesMorososBindingSource
            // 
            this.vistaClientesMorososBindingSource.DataMember = "VistaClientesMorosos";
            this.vistaClientesMorososBindingSource.DataSource = this.sistemaPrestamosDataSetBindingSource;
            // 
            // sistemaPrestamosDataSetBindingSource
            // 
            this.sistemaPrestamosDataSetBindingSource.DataSource = this.sistemaPrestamosDataSet;
            this.sistemaPrestamosDataSetBindingSource.Position = 0;
            // 
            // sistemaPrestamosDataSet
            // 
            this.sistemaPrestamosDataSet.DataSetName = "SistemaPrestamosDataSet";
            this.sistemaPrestamosDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.vistaClientesMorososBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ReporteCMorosos.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1446, 572);
            this.reportViewer1.TabIndex = 0;
            // 
            // vistaClientesMorososTableAdapter
            // 
            this.vistaClientesMorososTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1446, 572);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vistaClientesMorososBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sistemaPrestamosDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sistemaPrestamosDataSet)).EndInit();
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