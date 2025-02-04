using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary2;
using ClassLibrary1;
using Microsoft.Reporting.WinForms;

namespace ReporteDatosCliente
{
    public partial class Form1 : Form

    {

        ClienteBLL clienteBLL = new ClienteBLL();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.datosClienteTableAdapter1.Fill(this.sistemaPrestamosDataSet1.datosCliente);
            CargarReporte();
        }


        private void CargarReporte()
        {
            try
            {

                //DataTable dt = clienteBLL.ObtenerReporte();


                //reportViewer1.LocalReport.DataSources.Clear();

                //ReportDataSource rds = new ReportDataSource("DataSet1", dt); 
                //reportViewer1.LocalReport.DataSources.Add(rds);


                //reportViewer1.LocalReport.ReportEmbeddedResource = "Report1.rdlc"; 
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el reporte: " + ex.Message);
            }
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
