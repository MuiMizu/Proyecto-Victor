using ClassLibrary1;
using Microsoft.Reporting.WinForms;
using ReporteDatosClient.SistemaPrestamosDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReporteDatosClient
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
            // TODO: This line of code loads data into the 'sistemaPrestamosDataSet.DatosCliente' table. You can move, or remove it, as needed.
            this.datosClienteTableAdapter.Fill(this.sistemaPrestamosDataSet.DatosCliente);

            this.reportViewer1.RefreshReport();
            CargarReporte();

        }

        private void CargarReporte()
        {
            try
            {
                DataTable dt = clienteBLL.ObtenerReporte2();

                SistemaPrestamosDataSet ds = new SistemaPrestamosDataSet();
                ReportDataSource rds = new ReportDataSource("DataSet1", dt);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rds);
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el reporte: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (int.TryParse(textBox1.Text, out int clienteID))
            {

                SistemaPrestamosDataSetTableAdapters.DatosClienteTableAdapter adapter =
                    new SistemaPrestamosDataSetTableAdapters.DatosClienteTableAdapter();


                SistemaPrestamosDataSet.DatosClienteDataTable table =
                    new SistemaPrestamosDataSet.DatosClienteDataTable();

                table = adapter.GetDataBy1(clienteID);


                if (table.Rows.Count > 0)
                {
  
                    ReportDataSource MyNewDataSource = new ReportDataSource("DataSet1", (DataTable)table);


                    this.reportViewer1.LocalReport.DataSources.Clear();


                    this.reportViewer1.LocalReport.DataSources.Add(MyNewDataSource);

                    this.reportViewer1.LocalReport.Refresh();
                    this.reportViewer1.RefreshReport();
                }
                else
                {
                    MessageBox.Show("No se encontraron resultados para el ClienteID ingresado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un número de ClienteID válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
