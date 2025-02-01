using Azure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ClassLibrary1;
using ClassLibrary2;

namespace Amortizacion
{
    public partial class Form1 : Form
    {
        Prestamo prestamo = new Prestamo();
        Cliente cliente = new Cliente();
        ClienteBLL clienteBLL = new ClienteBLL();
        Cuota cuota = new Cuota();
        Fondo fondo = new Fondo();
        Pago pago = new Pago();
        Recalculo recalculo = new Recalculo();
        public Form1()
        {
            InitializeComponent();
        }


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
                bool datosCargados2 = clienteBLL.CargarMontos(prestamo, pago);

                if (datosCargados && datosCargados2)
                {
                    if (pago.MontoRestante == 0)
                    {
                        label12.Text = "Pagado";
                        label12.ForeColor = Color.Green;
                    }
                    else
                    {
                        label12.Text = "Pendiente";
                        label12.ForeColor = Color.Red;
                    }

                    textBox8.Text = prestamo.Monto.ToString("N2");
                    textBox10.Text = prestamo.PlazoMeses.ToString();
                    textBox9.Text = prestamo.CalcularInteres(prestamo.PlazoMeses).ToString();
                    textBox12.Text = prestamo.Interes.ToString("N2");
                    textBox13.Text = prestamo.MontoTotal.ToString("N2");
                    textBox11.Text = (prestamo.MontoTotal / prestamo.PlazoMeses).ToString("N2");

                    textBox2.Text = Sesion.NombreCompleto;
                    textBox4.Text = Sesion.Correo;
                    textBox6.Text = cliente.Sueldo.ToString("N2");
                    textBox3.Text = cliente.Direccion;
                    textBox5.Text = cliente.Telefono;
                    textBox7.Text = cliente.Garantia;

                }
                else
                {
                    MessageBox.Show("No se encontraron datos para el ID de préstamo ingresado.");
                }

                try
                {
                    dataGridView1.DataSource = clienteBLL.MostrarPagos(prestamo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar clientes: " + ex.Message);
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

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "EstadoPago")
            {
                if (e.Value != null)
                {
                    string estado = e.Value.ToString();

                    if (estado == "Retrasado")
                    {
                        e.CellStyle.BackColor = Color.Red; 
                        e.CellStyle.ForeColor = Color.White; 
                    }
                    else if (estado == "Pagado")
                    {
                        e.CellStyle.BackColor = Color.Green; 
                        e.CellStyle.ForeColor = Color.White;
                    }
                }
            }
        }
    }
}
