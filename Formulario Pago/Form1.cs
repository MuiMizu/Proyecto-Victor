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
        Fondo fondo = new Fondo();
        Pago pago = new Pago();
        Recalculo recalculo = new Recalculo();

        private void Form1_Load(object sender, EventArgs e)
        {
            clienteBLL.ObtenerFondoDisponible(fondo);
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
                bool DatosCargados2 = clienteBLL.CargarCuotas(prestamo, cuota);
                bool DatosCargados3 = clienteBLL.CargarMoras(prestamo);
                bool datosCargados4 = clienteBLL.CargarMontos(prestamo, pago);
                bool datosCargados5 = clienteBLL.CargarAbonoTotal(prestamo, pago);



                if (datosCargados && DatosCargados2 && DatosCargados3 && datosCargados4 && datosCargados5)
                {

                    if (pago.MontoAbonado > 0 || pago.MontoPagado == 0)
                    {

                        textBox8.Text = pago.MontoRestante.ToString("N2");
                        int PagosRestantes = prestamo.PlazoMeses - cuota.NumeroCuota;
                        decimal Interes = pago.MontoRestante * (prestamo.CalcularInteres(PagosRestantes) / 100);
                        textBox10.Text = PagosRestantes.ToString();
                        textBox12.Text = Interes.ToString("N2");
                        decimal MontoTotal = pago.MontoRestante + Interes;
                        textBox13.Text = MontoTotal.ToString("N2");
                        textBox11.Text = (MontoTotal / PagosRestantes).ToString("N2");
                        textBox16.Text = (MontoTotal / PagosRestantes).ToString("N2");

                        recalculo.Cuotas = Convert.ToInt32(PagosRestantes);
                        recalculo.Monto = Convert.ToDecimal(textBox8.Text);
                        recalculo.Interes = Convert.ToDecimal(textBox12.Text);
                        recalculo.Total = Convert.ToDecimal(textBox13.Text);
                        clienteBLL.RegistrarAbono(prestamo, recalculo);


                    }
                    else
                    {
                        if (pago.AbonoTotal > 0 || prestamo.Moras > 0)
                        {
                            clienteBLL.CargarRecalculo(prestamo, recalculo);
                            textBox8.Text = recalculo.Monto.ToString("N2");
                            textBox10.Text = recalculo.Cuotas.ToString();
                            textBox12.Text = recalculo.Interes.ToString("N2");
                            textBox13.Text = recalculo.Total.ToString("N2");
                            decimal PagoCuota = recalculo.Total / recalculo.Cuotas;
                            textBox11.Text = PagoCuota.ToString("N2");
                            textBox16.Text = PagoCuota.ToString("N2");


                        }
                        else
                        {
                            textBox8.Text = prestamo.Monto.ToString("N2");
                            textBox16.Text = (prestamo.MontoTotal / prestamo.PlazoMeses).ToString("N2");
                            textBox10.Text = prestamo.PlazoMeses.ToString();
                            textBox12.Text = prestamo.Interes.ToString("N2");
                            textBox13.Text = prestamo.MontoTotal.ToString("N2");
                            textBox11.Text = (prestamo.MontoTotal / prestamo.PlazoMeses).ToString("N2");
                        }
                        

                    }

                    textBox2.Text = Sesion.NombreCompleto;
                    textBox4.Text = Sesion.Correo;
                    textBox6.Text = cliente.Sueldo.ToString("N2"); 
                    textBox3.Text = cliente.Direccion;
                    textBox5.Text = cliente.Telefono;
                    textBox7.Text = cliente.Garantia;
                    cuota.NumeroCuota = cuota.NumeroCuota + 1;
                    textBox14.Text = cuota.NumeroCuota.ToString();


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
        private void button2_Click(object sender, EventArgs e)
        {
            pago.MontoPagado = 0;
            pago.InteresPagado = 0;
            pago.Mora = true;
            bool resultado = clienteBLL.RegistrarPago(prestamo, pago);

            if (resultado)
            {
                MessageBox.Show("Retraso registrado correctamente.");

            }
            else
            {
                MessageBox.Show("Error al retrasar el pago.");
            }
            textBox8.Text = " ";
            textBox16.Text = " ";
            textBox10.Text = " ";
            textBox12.Text = " ";
            textBox13.Text = " ";
            textBox11.Text = " ";
            textBox2.Text = " ";
            textBox4.Text = " ";
            textBox6.Text = " ";
            textBox3.Text = " ";
            textBox5.Text = " ";
            textBox7.Text = " ";
            textBox14.Text = " ";
            textBox15.Text = " ";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                decimal InteresRetraso = 0;
                decimal a = Convert.ToDecimal(textBox12.Text);
                decimal b = Convert.ToDecimal(textBox10.Text);
                if (pago.MontoPagado == 0)
                {

                    decimal Monto = Convert.ToDecimal(textBox8.Text);
                    InteresRetraso = Monto * (10m / 100m);

                }
                pago.MontoPagado = Convert.ToDecimal(textBox16.Text) - (a / b);
                pago.InteresPagado = (a / b) + InteresRetraso;
                if (string.IsNullOrWhiteSpace(textBox15.Text))
                {
                    pago.MontoAbonado = 0;
                }
                else
                {
                    pago.MontoAbonado = Convert.ToDecimal(textBox15.Text);

                }

                pago.Mora = false;

                bool resultado = clienteBLL.RegistrarPago(prestamo, pago);

                if (resultado)
                {
                    MessageBox.Show("Pago registrado correctamente.");

                }
                else
                {
                    MessageBox.Show("Error al registrar el pago.");
                }

                decimal montoCuota = Convert.ToDecimal(textBox16.Text);
                fondo.MontoDisponible = fondo.MontoDisponible + montoCuota;
                clienteBLL.ActualizarFondoDisponible(fondo.MontoDisponible);
                textBox8.Text = " ";
                textBox16.Text = " ";
                textBox10.Text = " ";
                textBox12.Text = " ";
                textBox13.Text = " ";
                textBox11.Text = " ";
                textBox2.Text = " ";
                textBox4.Text = " ";
                textBox6.Text = " ";
                textBox3.Text = " ";
                textBox5.Text = " ";
                textBox7.Text = " ";
                textBox14.Text = " ";
                textBox15.Text = " ";
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Error de formato en uno o más campos. Verifique los valores ingresados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}
