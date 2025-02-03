using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReporteForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.ReportPath = @"\Reporte\Report1.rdlc";

            this.reportViewer1.RefreshReport();



            
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
