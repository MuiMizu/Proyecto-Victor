using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReporteDatosClient;
namespace Menu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void AbrirForm (object formAlt)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fa = formAlt as Form;
            fa.TopLevel = false;
            fa.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fa);
            this.panelContenedor.Tag = fa;
            fa.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirForm(new Factura.Form1());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbrirForm(new Formulario_Pago.Form1());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbrirForm(new Amortizacion.Form1());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AbrirForm(new ReporteCMorosos.Form1());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            AbrirForm(new ReporteDatosClient.Form1());

        }

        private void button7_Click(object sender, EventArgs e)
        {
            AbrirForm(new APrestamoSimple.Form1());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AbrirForm(new GananciaxInteres.Form1());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AbrirForm(new MorasXClientes.Form1()); 
        }
    }
}
