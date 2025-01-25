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
using static System.Collections.Specialized.BitVector32;

namespace Factura
{
    public partial class FormFactura : Form
    {
        public FormFactura()
        {
            InitializeComponent();
        }

        Cliente cliente = new Cliente();
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.Text = Sesion.NombreCompleto.ToString();
            textBox4.Text = Sesion.Correo.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                Cliente cliente = new Cliente();
                cliente.Sueldo = Convert.ToDecimal(textBox6.Text);
                cliente.Direccion = textBox3.Text;
                cliente.Telefono = textBox5.Text;
                cliente.Garantia = textBox7.Text;


                ClienteBLL clienteBLL = new ClienteBLL();

                bool resultado = clienteBLL.RegistrarDatos(cliente);

                if (resultado)
                {
                    MessageBox.Show("Datos registrados exitosamente.");
                }
                else
                {
                    MessageBox.Show("Error al registrar los datos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
