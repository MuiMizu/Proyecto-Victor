using Microsoft.Win32;
using System;
using System.Windows.Forms;
using Registro;

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
    }
}
