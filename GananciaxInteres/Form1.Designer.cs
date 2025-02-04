namespace GananciaxInteres
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
            this.sistemaPrestamosDataSet = new GananciaxInteres.SistemaPrestamosDataSet();
            this.montoPrestadoYGeneradoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.montoPrestadoYGeneradoTableAdapter = new GananciaxInteres.SistemaPrestamosDataSetTableAdapters.MontoPrestadoYGeneradoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.sistemaPrestamosDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.montoPrestadoYGeneradoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.montoPrestadoYGeneradoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "GananciaxInteres.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 1);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1122, 662);
            this.reportViewer1.TabIndex = 0;
            // 
            // sistemaPrestamosDataSet
            // 
            this.sistemaPrestamosDataSet.DataSetName = "SistemaPrestamosDataSet";
            this.sistemaPrestamosDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // montoPrestadoYGeneradoBindingSource
            // 
            this.montoPrestadoYGeneradoBindingSource.DataMember = "MontoPrestadoYGenerado";
            this.montoPrestadoYGeneradoBindingSource.DataSource = this.sistemaPrestamosDataSet;
            // 
            // montoPrestadoYGeneradoTableAdapter
            // 
            this.montoPrestadoYGeneradoTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 675);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sistemaPrestamosDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.montoPrestadoYGeneradoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private SistemaPrestamosDataSet sistemaPrestamosDataSet;
        private System.Windows.Forms.BindingSource montoPrestadoYGeneradoBindingSource;
        private SistemaPrestamosDataSetTableAdapters.MontoPrestadoYGeneradoTableAdapter montoPrestadoYGeneradoTableAdapter;
    }
}