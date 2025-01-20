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

namespace Registro
{
    public partial class FormRegistro : Form
    {
        private ClienteBLL clienteBLL = new ClienteBLL();
        public FormRegistro()
        {
           InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = new Cliente
                {
                    NombreCompleto = textBox1.Text,
                    Correo = textBox2.Text,
                    Contraseña = textBox3.Text
                };

                bool resultado = clienteBLL.RegistrarCliente(cliente);

                if (resultado)
                {
                    MessageBox.Show("Cliente registrado exitosamente.");
                }
                else
                {
                    MessageBox.Show("Error al registrar el cliente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

        }
    }
}

