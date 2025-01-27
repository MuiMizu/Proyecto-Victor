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
        Cuota cuota = new Cuota();
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Por favor, ingresa un ID de préstamo válido.");
                    return;
                }


                prestamo.PrestamoID = Convert.ToInt32(textBox1.Text);

                bool datosCargados = clienteBLL.CargarDatosPago(prestamo, cliente);

                if (datosCargados)
                {
    
                    textBox2.Text = Sesion.NombreCompleto;
                    textBox4.Text = Sesion.Correo;
                    textBox6.Text = cliente.Sueldo.ToString("N2"); 
                    textBox3.Text = cliente.Direccion;
                    textBox5.Text = cliente.Telefono;
                    textBox7.Text = cliente.Garantia;
                    textBox8.Text = prestamo.Monto.ToString("N2"); 
                    textBox10.Text = prestamo.PlazoMeses.ToString();
                    textBox12.Text = prestamo.Interes.ToString("N2"); 
                    textBox13.Text = prestamo.MontoTotal.ToString("N2"); 
                    textBox11.Text = (prestamo.MontoTotal / prestamo.PlazoMeses).ToString("N2");

                }
                else
                {
                    MessageBox.Show("No se encontraron datos para el ID de préstamo ingresado.");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("El ID de préstamo debe ser un número válido.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los datos: " + ex.Message);
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
