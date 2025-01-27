using ClassLibrary1;
using ClassLibrary2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formulario_Pago
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        Prestamo prestamo = new Prestamo();
        Cliente cliente = new Cliente();
        ClienteBLL clienteBLL = new ClienteBLL();
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            prestamo.PrestamoID = Convert.ToInt32(textBox1.Text);
            clienteBLL.CargarDatosPago();
            textBox2.Text = Sesion.NombreCompleto;
            textBox4.Text = Sesion.Correo;
            textBox6.Text = Convert.ToString(cliente.Sueldo);
            textBox3.Text = cliente.Direccion;
            textBox5.Text = cliente.Telefono;
            textBox7.Text = cliente.Garantia;
            textBox8.Text = Convert.ToString(prestamo.Monto);
            textBox10.Text = Convert.ToString(prestamo.PlazoMeses);
            textBox12.Text = Convert.ToString(prestamo.Interes);
            textBox13.Text = Convert.ToString(prestamo.MontoTotal);

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
