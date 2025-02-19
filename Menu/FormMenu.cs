﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Menu
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void AbrirForm (object formAlt)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fa = formAlt as Form;
            fa.TopLevel = false;
            fa.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fa);
            this.panelContenedor.Tag = fa;
            fa.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirForm(new Factura.FormFactura());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbrirForm(new Formulario_Pago.FormPago());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbrirForm(new Amortizacion.FormAmortizacion());
        }
    }
}
