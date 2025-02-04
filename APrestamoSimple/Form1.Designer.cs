namespace APrestamoSimple
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
            this.amortizacionPrestamosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sistemaPrestamosDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sistemaPrestamosDataSet = new APrestamoSimple.SistemaPrestamosDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.amortizacionPrestamosTableAdapter = new APrestamoSimple.SistemaPrestamosDataSetTableAdapters.AmortizacionPrestamosTableAdapter();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.amortizacionPrestamosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sistemaPrestamosDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sistemaPrestamosDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // amortizacionPrestamosBindingSource
            // 
            this.amortizacionPrestamosBindingSource.DataMember = "AmortizacionPrestamos";
            this.amortizacionPrestamosBindingSource.DataSource = this.sistemaPrestamosDataSetBindingSource;
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
            reportDataSource1.Value = this.amortizacionPrestamosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "APrestamoSimple.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1273, 742);
            this.reportViewer1.TabIndex = 0;
            // 
            // amortizacionPrestamosTableAdapter
            // 
            this.amortizacionPrestamosTableAdapter.ClearBeforeFill = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(999, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(87, 22);
            this.textBox1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(915, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "PrestamoID";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1102, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 24);
            this.button1.TabIndex = 4;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1273, 742);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.amortizacionPrestamosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sistemaPrestamosDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sistemaPrestamosDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private SistemaPrestamosDataSet sistemaPrestamosDataSet;
        private System.Windows.Forms.BindingSource sistemaPrestamosDataSetBindingSource;
        private System.Windows.Forms.BindingSource amortizacionPrestamosBindingSource;
        private SistemaPrestamosDataSetTableAdapters.AmortizacionPrestamosTableAdapter amortizacionPrestamosTableAdapter;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}