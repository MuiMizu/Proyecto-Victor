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

namespace PerfilCliente
{
    public partial class Perfil : Form
    {
        public Perfil()
        {
            InitializeComponent();
        }
        ClienteBLL clienteBLL  = new ClienteBLL();
        Cliente cliente = new Cliente();
        private void Perfil_Load(object sender, EventArgs e)
        {
            bool resultado = clienteBLL.ObtenerClienteID(cliente);
            if (resultado) 
            {
                textBox2.Text = Sesion.NombreCompleto;
                textBox4.Text = Sesion.Correo;
                textBox3.Text = cliente.Direccion;
                textBox7.Text = cliente.Garantia;
                textBox5.Text = cliente.Telefono;
                textBox6.Text = cliente.Sueldo.ToString("N2");
                textBox1.Text = cliente.Contraseña;

                if (cliente.Sueldo == 0.00m)
                {
                    textBox6.Text = "Realiza un prestamo para rellenar el campo";
                }

            }
            else
            {
                MessageBox.Show("Ocurrio un error al buscar el cliente");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sesion.NombreCompleto = textBox2.Text;
            Sesion.Correo = textBox4.Text;
            cliente.Contraseña = textBox1.Text;

            if (textBox3.Text == "Realiza un prestamo para rellenar el campo")
            {
                cliente.Direccion = null;
            }
            else
            {
                cliente.Direccion = textBox3.Text;
            }

            if (textBox7.Text == "Realiza un prestamo para rellenar el campo")
            {
                cliente.Garantia = null;
            }
            else
            {
                cliente.Garantia = textBox7.Text;
            }
            if (textBox5.Text == "Realiza un prestamo para rellenar el campo")
            {
                cliente.Telefono = null;
            }
            else
            {
                cliente.Telefono = textBox5.Text;
            }
            if (textBox6.Text == "Realiza un prestamo para rellenar el campo")
            {
                cliente.Sueldo = 0.00m;
            }
            else
            {
                cliente.Sueldo = Convert.ToDecimal(textBox6.Text);
            }



            bool resultado = clienteBLL.ActualizarCliente(cliente);
            if (resultado)
            {
                MessageBox.Show("Se han actualizado correctamente los datos");
            }
            else
            {
                MessageBox.Show("Hubo un error al intentar actualizar los datos");

            }
        }
    }
}
