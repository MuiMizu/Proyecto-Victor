using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APrestamoSimple
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sistemaPrestamosDataSet.AmortizacionPrestamos' table. You can move, or remove it, as needed.
            this.amortizacionPrestamosTableAdapter.Fill(this.sistemaPrestamosDataSet.AmortizacionPrestamos);

            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int prestamoID))
            {

                SistemaPrestamosDataSetTableAdapters.AmortizacionPrestamosTableAdapter adapter =
                    new SistemaPrestamosDataSetTableAdapters.AmortizacionPrestamosTableAdapter();


                SistemaPrestamosDataSet.AmortizacionPrestamosDataTable table =
                    new SistemaPrestamosDataSet.AmortizacionPrestamosDataTable();

                table = adapter.GetDataBy(prestamoID);


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
                    MessageBox.Show("No se encontraron resultados para el PrestamoID ingresado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un número de prestamo válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
