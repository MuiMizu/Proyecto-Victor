namespace ReporteDatosCliente
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
            this.datosClienteTableAdapter1 = new ReporteDatosCliente.SistemaPrestamosDataSet1TableAdapters.DatosClienteTableAdapter();
            this.sistemaPrestamosDataSet1 = new ReporteDatosCliente.SistemaPrestamosDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DatosClienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.sistemaPrestamosDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DatosClienteBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // datosClienteTableAdapter1
            // 
            this.datosClienteTableAdapter1.ClearBeforeFill = true;
            // 
            // sistemaPrestamosDataSet1
            // 
            this.sistemaPrestamosDataSet1.DataSetName = "SistemaPrestamosDataSet";
            this.sistemaPrestamosDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ReporteDatosCliente.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(-3, 2);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1575, 544);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // DatosClienteBindingSource
            // 
            this.DatosClienteBindingSource.DataMember = "DatosCliente";
            this.DatosClienteBindingSource.DataSource = this.sistemaPrestamosDataSet1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1557, 558);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sistemaPrestamosDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DatosClienteBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SistemaPrestamosDataSet1TableAdapters.DatosClienteTableAdapter datosClienteTableAdapter1;
        private SistemaPrestamosDataSet sistemaPrestamosDataSet1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource DatosClienteBindingSource;
    }
}

