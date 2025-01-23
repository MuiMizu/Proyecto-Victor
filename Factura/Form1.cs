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
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.Text = Sesion.NombreCompleto.ToString();
            textBox4.Text = Sesion.Correo.ToString();
        }
    }
}
