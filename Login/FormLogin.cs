using Microsoft.Win32;
using System;
using System.Windows.Forms;
using Registro;
using ClassLibrary1;
using ClassLibrary2;
using Menu;
namespace Login
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Registro.FormRegistro formRegistro = new Registro.FormRegistro();
            formRegistro.ShowDialog();
        }

        ClienteBLL clienteBLL = new ClienteBLL();
        Cliente cliente = new Cliente();
        private void button2_Click(object sender, EventArgs e)
        {
            string correo = textBox1.Text;
            string contraseña = textBox2.Text;

            if (string.IsNullOrWhiteSpace(correo) || string.IsNullOrWhiteSpace(contraseña))
            {
                MessageBox.Show("Por favor, ingresa el correo y la contraseña.");
                return;
            }

            if (clienteBLL.IniciarSesion(correo, contraseña))
            {
                MessageBox.Show($"Bienvenido, {Sesion.NombreCompleto}!");
                Sesion.Correo = correo;
                Menu.Form1 formPrincipal = new Menu.Form1();
                formPrincipal.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Credenciales inválidas. Inténtalo de nuevo.");
            }
        }
    }
}
