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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Cliente cliente = new Cliente();
        private decimal fondoDisponible;

        ClienteBLL clienteBLL = new ClienteBLL();
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.Text = Sesion.NombreCompleto.ToString();
            textBox4.Text = Sesion.Correo.ToString();

            try
            {
                fondoDisponible = clienteBLL.ObtenerFondoDisponible();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el fondo disponible: " + ex.Message);
            }
        }

        Prestamo prestamo = new Prestamo();

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(textBox6.Text) ||
                    string.IsNullOrWhiteSpace(textBox8.Text) ||
                    string.IsNullOrWhiteSpace(textBox7.Text) ||
                    string.IsNullOrWhiteSpace(textBox10.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos necesarios.");
                    return;
                }

                decimal sueldo = decimal.Parse(textBox6.Text);
                decimal montoPrestamo = decimal.Parse(textBox8.Text);
                int numeroCuotas = int.Parse(textBox10.Text);
                string Estado = "Activo";

                if (montoPrestamo > sueldo * 4)
                {
                    MessageBox.Show("El monto solicitado no puede exceder 4 veces el sueldo.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBox7.Text))
                {
                    MessageBox.Show("Debe proporcionar una garantía para el préstamo.");
                    return;
                }

                if (montoPrestamo > fondoDisponible)
                {
                    MessageBox.Show("El fondo disponible no es suficiente para este préstamo.");
                    return;
                }

 
                prestamo.Monto = montoPrestamo;
                prestamo.PlazoMeses = numeroCuotas;

                prestamo.CalcularTotales();

                textBox9.Text = prestamo.CalcularInteres(numeroCuotas).ToString();
                textBox12.Text = prestamo.Interes.ToString("C");
                textBox13.Text = prestamo.MontoTotal.ToString("C");
                textBox11.Text = prestamo.MontoPorCuota.ToString("C");
                prestamo.Estado = Estado;


                MessageBox.Show("Préstamo calculado exitosamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
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


                bool resultado = clienteBLL.RegistrarDatos(cliente);
                bool resultado2 = clienteBLL.RegistrarPrestamo(prestamo);

                if (resultado && resultado2)
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
