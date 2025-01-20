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

        private void button2_Click(object sender, EventArgs e)
        {
            string nombreCompleto = textBox1.Text;
            string contraseña = textBox2.Text;

            bool esValido = ClassLibrary1.ValidarCredenciales(nombreCompleto, contraseña);

            if (esValido)
            {
                MessageBox.Show("Inicio de sesión exitoso.");

                Form1 formPrincipal = new Form1();
                formPrincipal.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas. Inténtalo nuevamente.");
            }
        }
    }
}
